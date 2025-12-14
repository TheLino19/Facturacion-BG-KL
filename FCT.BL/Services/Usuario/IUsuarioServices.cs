using FCT.BE.Commons.Dtos.Req;
using FCT.BE.Commons.Dtos.Resp.Usuario;
using FCT.BE.Commons.Helpers;
using FCT.BE.Model.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BL.Services.Usuario
{
    public interface IUsuarioServices
    {
        Task<ResponseModel<string>> CrearUsuario(UsurarioDtoReq usuarioDtoReq);
        Task<ResponseModel<string>> EditarUsuario(DtoUsuarioEdit dtoUsuarioEdit);
        Task<ResponseModel<DtoUsuarioResp>> ObtenerUsuario(int Id);
        Task<ResponseModel<List<DtoUsuarioResp>>> ObtenerUsuarios(FiltrosUsuario filtrosUsuario);
        Task<ResponseModel<int>> EliminarUsuarios(int Id);

    }
}
