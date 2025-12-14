using FCT.BE.Commons.Dtos.Resp.Factura;
using FCT.BE.Commons.Dtos.Resp.Producto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.DAC.Helpers.Mapper
{
    public static class ProductoMapperSql
    {
        public static List<DtoProductoResp> MapearProd(DataTable dataTable)
        {
            List<DtoProductoResp> lista = new List<DtoProductoResp>();
            foreach (DataRow row in dataTable.Rows)
            {
                DtoProductoResp Detalles = new DtoProductoResp
                {
                    ProductoId = row["ProductoId"] != DBNull.Value ? Convert.ToInt32(row["ProductoId"]) : 0,
                    Codigo = row["Codigo"] != DBNull.Value ? row["Codigo"].ToString() : string.Empty,
                    PrecioUnitario = row["PrecioUnitario"] != DBNull.Value ? Convert.ToDecimal(row["PrecioUnitario"]) : 0m,
                    Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                };
                lista.Add(Detalles);
            }

            return lista;
        }

        public static DtoProductoResp MapearOnlyProd(DataTable dataTable)
        {
            DtoProductoResp Detalles = null;
            foreach (DataRow row in dataTable.Rows)
            {
                Detalles = new DtoProductoResp
                {
                    ProductoId = row["ProductoId"] != DBNull.Value ? Convert.ToInt32(row["ProductoId"]) : 0,
                    Codigo = row["Codigo"] != DBNull.Value ? row["Codigo"].ToString() : string.Empty,
                    PrecioUnitario = row["PrecioUnitario"] != DBNull.Value ? Convert.ToDecimal(row["PrecioUnitario"]) : 0m,
                    Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                };

            }
            return Detalles;
        }
    }
}
