using FCT.BE.Commons.Dtos.Req;
using FCT.BE.Commons.Dtos.Resp.Usuario;
using FCT.BE.Commons.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.DAC.Repositorios.Usuario
{
    public interface IUsuarioRepository
    {
        Task<string> CrearUsuario(UsurarioDtoReq usuarioDtoReq);
        Task<string> EditarUsuario(DtoUsuarioEdit dtoUsuarioEdit);
        Task<DtoUsuarioResp> ObtenerUsuario(int Id);
        Task<List<DtoUsuarioResp>> ObtenerUsuarios(FiltrosUsuario filtrosUsuario);
        Task<int> EliminarUsuario(int Id);
    }
}
