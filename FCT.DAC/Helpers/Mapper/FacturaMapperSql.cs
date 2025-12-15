using FCT.BE.Commons.Dtos.Resp.Factura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.DAC.Helpers.Mapper
{
    public class FacturaMapperSql
    {

        public static DtoFacturaResp MapperCab(DataTable dataTable)
        {
            DtoFacturaResp Factura = new();
            
            foreach (DataRow row in dataTable.Rows)
            {
                if(Factura.FechaCreacion == DateTime.MinValue)
                {
                    Factura.FechaCreacion = row["FechaCreacion"] != DBNull.Value ? Convert.ToDateTime(row["FechaCreacion"]) : DateTime.MinValue;
                    Factura.Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty;
                    Factura.Telefono = row["Telefono"] != DBNull.Value ? row["Telefono"].ToString() : string.Empty;
                    Factura.Correo = row["Correo"] != DBNull.Value ? row["Correo"].ToString() : string.Empty;
                    Factura.Vendedor = row["Vendedor"] != DBNull.Value ? row["Vendedor"].ToString() : string.Empty;
                    Factura.TipoPago = row["TipoPago"] != DBNull.Value ? row["TipoPago"].ToString() : string.Empty;
                    Factura.EstadoPago = row["EstadoPago"] != DBNull.Value ? row["EstadoPago"].ToString() : string.Empty;
                }
            }
            return Factura;
        }

        public static List<DtoDetalleFactura> MapearDeta(DataTable dataTable)
        {
            List<DtoDetalleFactura> lista = new List<DtoDetalleFactura>();
            foreach (DataRow row in dataTable.Rows)
            {
                DtoDetalleFactura Detalles = new DtoDetalleFactura
                {
                    FacturaDetalleId = row["DetalleId"] != DBNull.Value ? Convert.ToInt32(row["DetalleId"]) : 0,
                    Codigo = row["Codigo"] != DBNull.Value ? row["Codigo"].ToString() : string.Empty,
                    Cantidad = row["Cantidad"] != DBNull.Value ? Convert.ToInt32(row["Cantidad"]) : 0,
                    Descripcion = row["Descripcion"] != DBNull.Value ? row["Descripcion"].ToString() : string.Empty,
                    PrecioUnitario = row["PrecioUnitario"] != DBNull.Value ? Convert.ToDecimal(row["PrecioUnitario"]) : 0m,
                    PrecioSubtotal = row["PrecioSubtotal"] != DBNull.Value ? Convert.ToDecimal(row["PrecioSubtotal"]) : 0m
                };
                lista.Add(Detalles);
            } 

            return lista;
        }

        public static List<DtoFacturaCab> MapearLista(DataTable dataTable )
        {
            List<DtoFacturaCab> dtoFacturaCabs = new List<DtoFacturaCab>();
            foreach (DataRow row in dataTable.Rows)
            {
                DtoFacturaCab Detalles = new DtoFacturaCab
                {
                    FacturaId = row["FacturaId"] != DBNull.Value ? Convert.ToInt32(row["FacturaId"]) : 0,
                    FechaModificacion = row["FechaModificacion"] != DBNull.Value ? Convert.ToDateTime(row["FechaModificacion"]) : DateTime.MinValue,
                    NombreCliente = row["NombreCliente"] != DBNull.Value ? row["NombreCliente"].ToString() : string.Empty,
                    NombresCompleto = row["NombresCompleto"] != DBNull.Value ? row["NombresCompleto"].ToString() : string.Empty,
                    EstadoFactura = row["EstadoFactura"] != DBNull.Value ? row["EstadoFactura"].ToString() : string.Empty,
                    TotalFactura = row["TotalFactura"] != DBNull.Value ? Convert.ToDecimal(row["TotalFactura"]) : 0m,
                    Activo = row["Activo"] != DBNull.Value && Convert.ToBoolean(row["Activo"])
                };
                dtoFacturaCabs.Add( Detalles );
            }

            return dtoFacturaCabs;
        }
    }
}
