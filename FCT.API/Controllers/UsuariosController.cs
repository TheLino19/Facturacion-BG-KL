using FCT.BE.Commons.Dtos.Req;
using FCT.BE.Commons.Dtos.Resp.Usuario;
using FCT.BE.Model.Respuesta;
using FCT.BL.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace FCT.API.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuariosController(
            IUsuarioServices usuarioServices) 
        { 
            _usuarioServices = usuarioServices;
        }

        [HttpPost("CrearUsuario")]
        public async Task<ResponseModel<string>> CrearUsuario([FromBody] UsurarioDtoReq usurarioDto)
        {
            return await _usuarioServices.CrearUsuario(usurarioDto);
        }

        [HttpPost("EditarUsuario")]
        public async Task<ResponseModel<string>> EditarUsuario([FromBody] DtoUsuarioEdit dtoUsuarioEdit)
        {
            return await _usuarioServices.EditarUsuario(dtoUsuarioEdit);
        }

        [HttpPost("ObtenerUsuario")]
        public async Task<ResponseModel<DtoUsuarioResp>> ObtenerUsuario(int Id)
        {
            return await _usuarioServices.ObtenerUsuario(Id);
        }
    }
}
