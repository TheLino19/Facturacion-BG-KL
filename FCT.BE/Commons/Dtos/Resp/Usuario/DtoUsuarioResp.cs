using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Resp.Usuario
{
    public class DtoUsuarioResp
    {
        public DtoUsuarioResp(int idUsuario, string nombres, string userName, string email, string rol, bool activo, DateTime fechaCreacion)
        {
            IdUsuario = idUsuario;
            Nombres = nombres;
            UserName = userName;
            Email = email;
            Rol = rol;
            Activo = activo;
            FechaCreacion = fechaCreacion;
        }

        public int IdUsuario {  get; set; }
        public string Nombres { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Rol {  get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
