using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Req
{
    public class UsurarioDtoReq
    {
        public UsurarioDtoReq(
            string username,
            string passwordHash,
            string nombre,
            string apellido,
            string email,
            string rol)
        {
            UserName = username;
            PasswordHash = passwordHash;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Rol = rol;
        }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

    }
}
