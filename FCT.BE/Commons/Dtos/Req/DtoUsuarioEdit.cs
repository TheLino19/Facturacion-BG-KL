using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Req
{
    public class DtoUsuarioEdit
    {
        public DtoUsuarioEdit(
            string id,
            string nombre,
            string apellidos,
            string email,
            string rol)
        {
            Id= id;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Rol = rol;
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
