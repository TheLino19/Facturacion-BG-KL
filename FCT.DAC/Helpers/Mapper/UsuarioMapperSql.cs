using FCT.BE.Commons.Dtos.Resp.Usuario;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Data;

namespace FCT.DAC.Helpers.Mapper
{
    public static class UsuarioMapperSql
    {
        public static DtoUsuarioResp? MapperUsuario(DataTable dataTable)
        {
            return dataTable.Rows.Count > 0 ? MapearFila(dataTable.Rows[0]) : null;
        }

        public static List<DtoUsuarioResp> MapperTodoUsuario(DataTable dataTable)
        {
            List<DtoUsuarioResp> usuarios = new();
            foreach (DataRow row in dataTable.Rows)
            {
                usuarios.Add(MapearFila(row));
            }
            return usuarios;
        }

        public static DtoUsuarioResp MapearFila(DataRow row)
        {
            var usuario = new DtoUsuarioResp
            {
                IdUsuario = row["UsuarioId"] != DBNull.Value ? Convert.ToInt32(row["UsuarioId"]) : 0,
                Nombres = row["Nombres"] != DBNull.Value ? row["Nombres"].ToString() : string.Empty,
                UserName = row["Username"] != DBNull.Value ? row["Username"].ToString() : string.Empty,
                Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : string.Empty,
                Rol = row["Rol"] != DBNull.Value ? row["Rol"].ToString() : string.Empty,
                Activo = row["Activo"] != DBNull.Value && Convert.ToBoolean(row["Activo"]),
                FechaCreacion = row["FechaCreacion"] != DBNull.Value ? Convert.ToDateTime(row["FechaCreacion"]) : DateTime.MinValue
            };

            return usuario;
        }
    }
}
