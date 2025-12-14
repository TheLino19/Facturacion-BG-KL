using FCT.BE.Commons.Dtos.Req.Cliente;
using FCT.BE.Commons.Dtos.Req.Factura;
using FCT.BE.Commons.Dtos.Resp.Factura;
using FCT.BE.Commons.Helpers;
using FCT.DAC.Helpers.Mapper;
using FCT.DAC.Helpers.Utils;
using FCT.DAC.Repositorios.Queries;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.DAC.Repositorios.Factura
{
    public class FacturaRepository : IFacturaRepository
    {
        public async Task<string> CrearFactura(DtoFacturaIns dtoFacturaIns)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.NumeroFactura, dtoFacturaIns.NumeroFactura),
                new SqlParameter(Parameters.ClienteId, dtoFacturaIns.ClienteId),
                new SqlParameter(Parameters.UsuarioId, dtoFacturaIns.UsuarioId),
                new SqlParameter(Parameters.Total, dtoFacturaIns.Total),
                new SqlParameter(Parameters.TipoPago, dtoFacturaIns.TipoPago),
                new SqlParameter(Parameters.EstadoPago, dtoFacturaIns.EstadoPago),
            };
            int rows = await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_InsertarFacturas);
            return rows == 0 ? string.Empty : dtoFacturaIns.NumeroFactura;
        }

        public async Task<int> EliminarDetalleFactura(int Id)
        {
            List<SqlParameter> parameters = new() { new SqlParameter(Parameters.FacturaDetalleId, Id) };
            return await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_EliminarFacturasDetalles);
        }

        public async Task<int> EliminarFactura(int Id)
        {
            List<SqlParameter> parameters = new() { new SqlParameter(Parameters.Id, Id) };
            return await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_EliminarFactura);
        }

        public async Task<int> InsertarDetalleFactura(DtoFacturaEdit dtoFacturaEdit)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.FacturaId, dtoFacturaEdit.FacturaId),
                new SqlParameter(Parameters.ProductoId, dtoFacturaEdit.ProductoId),
                new SqlParameter(Parameters.Cantidad, dtoFacturaEdit.Cantidad), 
                new SqlParameter(Parameters.PrecioUnitario, dtoFacturaEdit.PrecioUnitario),
                new SqlParameter(Parameters.SubTotal, dtoFacturaEdit.SubTotal),
            };
            return await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_InsertarFacturasDetalles);
        }

        public async Task<DtoFacturaResp> ObtenerFactura(int Id)
        {
            DtoFacturaResp dtoFacturaResp = null;
            List<SqlParameter> parameters = new() { new SqlParameter(Parameters.FiltroIDFactura, Id) };
            DataTable dataTableCab = await ExecuteQuery.ExecuteRawAsync(parameters, StoredProcedure.SP_ObtenerFacturaCabId);
            List<SqlParameter> parameters2 = new() { new SqlParameter(Parameters.FiltroIDFactura, Id) };
            DataTable dataTableDet = await ExecuteQuery.ExecuteRawAsync(parameters2, StoredProcedure.SP_ObtenerFacturaDetaId);
            dtoFacturaResp = FacturaMapperSql.MapperCab(dataTableCab);
            dtoFacturaResp.dtoDetalleFacturas = FacturaMapperSql.MapearDeta(dataTableDet);
            return dtoFacturaResp;
        }

        public async Task<List<DtoFacturaCab>> ObtenerFacturas(FiltroFactura filtroFactura)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.FiltroNumeroFactura, SqlDbType.NVarChar, 200)
                { Value = string.IsNullOrEmpty(filtroFactura.FiltroNumeroFactura) ? DBNull.Value : filtroFactura.FiltroNumeroFactura},
                new SqlParameter(Parameters.FiltroFecha, SqlDbType.DateTime2){ Value = filtroFactura.FiltroFecha ?? (object)DBNull.Value},
                new SqlParameter(Parameters.FiltroMonto, filtroFactura.FiltroMonto ?? (object)DBNull.Value),
                new SqlParameter(Parameters.FiltroEstado, filtroFactura.FiltroEstado ?? (object)DBNull.Value),  
                new SqlParameter(Parameters.PageNumber, filtroFactura.PageNumber),
                new SqlParameter(Parameters.PageSize, filtroFactura.PageSize),
            };
            DataTable dataTable = await ExecuteQuery.ExecuteRawAsync(parameters, StoredProcedure.SP_ObtenerFacturas);
            return FacturaMapperSql.MapearLista(dataTable);
        }
    }
}
