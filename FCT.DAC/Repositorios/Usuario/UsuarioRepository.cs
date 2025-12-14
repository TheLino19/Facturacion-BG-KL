using FCT.BE.Commons.Dtos.Req;
using FCT.DAC.Helpers.Utils;
using FCT.DAC.Repositorios.Queries;
using Microsoft.Data.SqlClient;

namespace FCT.DAC.Repositorios.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public async Task<string> CrearUsuario(UsurarioDtoReq usuarioDtoReq)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.Username, usuarioDtoReq.UserName),
                new SqlParameter(Parameters.PasswordHash, usuarioDtoReq.PasswordHash),
                new SqlParameter(Parameters.Nombre, usuarioDtoReq.Nombre),
                new SqlParameter(Parameters.Apellidos, usuarioDtoReq.Apellido),
                new SqlParameter(Parameters.Email, usuarioDtoReq.Email),
                new SqlParameter(Parameters.Rol, usuarioDtoReq.Rol),
            };
            int rows = await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_InsertarUsuario);
            return rows == 0 ? string.Empty : usuarioDtoReq.Nombre;
        }

        public async Task<string> EditarUsuario(DtoUsuarioEdit dtoUsuarioEdit)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.Id, dtoUsuarioEdit.Id),
                new SqlParameter(Parameters.Nombre, dtoUsuarioEdit.Nombre),
                new SqlParameter(Parameters.Apellidos, dtoUsuarioEdit.Apellidos),
                new SqlParameter(Parameters.Email, dtoUsuarioEdit.Email),
                new SqlParameter(Parameters.Rol, dtoUsuarioEdit.Rol),

            };
            int rows = await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_EditarUsuarios);
            return rows == 0 ? string.Empty : dtoUsuarioEdit.Nombre;
        }

    }
}
