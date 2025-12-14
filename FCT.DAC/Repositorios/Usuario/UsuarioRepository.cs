using FCT.BE.Commons.Dtos.Req;
using FCT.BE.Commons.Dtos.Resp.Usuario;
using FCT.BE.Commons.Helpers;
using FCT.DAC.Helpers.Mapper;
using FCT.DAC.Helpers.Utils;
using FCT.DAC.Repositorios.Queries;
using Microsoft.Data.SqlClient;
using System.Data;

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

        public async Task<DtoUsuarioResp> ObtenerUsuario(int Id)
        {
            List<SqlParameter> parameters = new(){ new SqlParameter(Parameters.Id, Id)};
            DataTable sqlDataReader = await ExecuteQuery.ExecuteRawAsync(parameters, StoredProcedure.SP_ObtenerUsuarioId);
            return UsuarioMapperSql.MapperUsuario(sqlDataReader);    
        }

        public async Task<List<DtoUsuarioResp>> ObtenerUsuarios(FiltrosUsuario filtrosUsuario)
        {
            List<SqlParameter> parameters = new() 
            { 
                new SqlParameter(Parameters.FiltroEstado, (object)filtrosUsuario.Estado ?? DBNull.Value),
                new SqlParameter(Parameters.Nombre, (object)filtrosUsuario.Nombre ?? DBNull.Value),
                new SqlParameter(Parameters.PageNumber, filtrosUsuario.PageNumber),
                new SqlParameter(Parameters.PageSize, filtrosUsuario.PageSize),
            };
            DataTable sqlDataReader = await ExecuteQuery.ExecuteRawAsync(parameters, StoredProcedure.SP_ObtenerUsuarios);
            return UsuarioMapperSql.MapperTodoUsuario(sqlDataReader);

        }


        public async Task<int> EliminarUsuario(int Id)
        {
            List<SqlParameter> parameters = new() { new SqlParameter(Parameters.Id, Id) };
            return await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_EliminarUsuario);
        }
    }
}
