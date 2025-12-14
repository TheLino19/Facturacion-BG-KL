using FCT.BE.Commons.Dtos.Req;
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
        Task<string> EditarUsuario(DtoUsuarioEdit dtoUsuarioEdit)
    }
}
