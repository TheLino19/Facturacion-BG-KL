using FCT.BE.Commons.Dtos.Resp.cliente;
using FCT.BE.Commons.Dtos.Resp.Usuario;
using System.Data;

namespace FCT.DAC.Helpers.Mapper
{
    public class ClienteMapperSql
    {
        public static DtoClienteResp? MapperCliente(DataTable dataTable)
        {
            return dataTable.Rows.Count > 0 ? MapearFila(dataTable.Rows[0]) : null;
        }

        public static List<DtoClienteResp> MapperTodoCliente(DataTable dataTable)
        {
            List<DtoClienteResp> clientes = new();
            foreach (DataRow row in dataTable.Rows)
            {
                clientes.Add(MapearFila(row));
            }
            return clientes;
        }

        public static DtoClienteResp MapearFila(DataRow row)
        {
            var usuario = new DtoClienteResp
            {
                ClienteId = row["ClienteId"] != DBNull.Value ? Convert.ToInt32(row["ClienteId"]) : 0,
                Nombre = row["Nombre"] != DBNull.Value ? row["Nombre"].ToString() : string.Empty,
                Telefono = row["Telefono"] != DBNull.Value ? row["Telefono"].ToString() : string.Empty,
                Correo = row["Correo"] != DBNull.Value ? row["Correo"].ToString() : string.Empty,
                Direccion = row["Direccion"] != DBNull.Value ? row["Direccion"].ToString() : string.Empty,
                Activo = row["Activo"] != DBNull.Value && Convert.ToBoolean(row["Activo"]),
                FechaRegistro = row["FechaRegistro"] != DBNull.Value ? Convert.ToDateTime(row["FechaRegistro"]) : DateTime.MinValue
            };

            return usuario;
        }
    }
}
