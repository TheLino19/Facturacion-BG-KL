using FCT.BE.Commons.Dtos.Req;
using FCT.BE.Commons.Dtos.Req.Cliente;
using FCT.BE.Commons.Dtos.Resp.cliente;
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

namespace FCT.DAC.Repositorios.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        public async Task<string> CrearCliente(DtoClienteIns dtoClienteIns)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.Idenntificacion, dtoClienteIns.Identificacion),
                new SqlParameter(Parameters.TipoIdenntificacion, dtoClienteIns.TipoIdentifiacion),
                new SqlParameter(Parameters.Nombre, dtoClienteIns.Nombre),
                new SqlParameter(Parameters.Telefono, dtoClienteIns.Telefono),
                new SqlParameter(Parameters.Email, dtoClienteIns.Email),
                new SqlParameter(Parameters.Direccion, dtoClienteIns.Direccion),
            };
            int rows = await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_InsertarCliente);
            return rows == 0 ? string.Empty : dtoClienteIns.Nombre;
        }

        public async Task<string> EditarCliente(DtoClienteEdit dtoClienteEdit)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.Id, dtoClienteEdit.Id),
                new SqlParameter(Parameters.Nombre, dtoClienteEdit.Nombre),
                new SqlParameter(Parameters.Telefono, dtoClienteEdit.Telefono),
                new SqlParameter(Parameters.Email, dtoClienteEdit.Email),
                new SqlParameter(Parameters.Direccion, dtoClienteEdit.Direccion),

            };
            int rows = await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_EditarClientes);
            return rows == 0 ? string.Empty : dtoClienteEdit.Nombre;
        }

        public async Task<DtoClienteResp> ObtenerCliente(int Id)
        {
            List<SqlParameter> parameters = new() { new SqlParameter(Parameters.Id, Id) };
            DataTable sqlDataReader = await ExecuteQuery.ExecuteRawAsync(parameters, StoredProcedure.SP_ObtenerClienteId);
            return ClienteMapperSql.MapperCliente(sqlDataReader);
        }

        public async Task<List<DtoClienteResp>> ObtenerClientes(FiltrosUsuario filtrosUsuario)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.FiltroEstado, (object)filtrosUsuario.Estado ?? DBNull.Value),
                new SqlParameter(Parameters.Nombre, (object)filtrosUsuario.Nombre ?? DBNull.Value),
                new SqlParameter(Parameters.PageNumber, filtrosUsuario.PageNumber),
                new SqlParameter(Parameters.PageSize, filtrosUsuario.PageSize),
            };
            DataTable sqlDataReader = await ExecuteQuery.ExecuteRawAsync(parameters, StoredProcedure.SP_ObtenerClientes);
            return ClienteMapperSql.MapperTodoCliente(sqlDataReader);
        }

        public async Task<int> EliminarCliente(int Id)
        {
            List<SqlParameter> parameters = new() { new SqlParameter(Parameters.Id, Id) };
            return await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_EliminarCliente);
        }
    }
}
