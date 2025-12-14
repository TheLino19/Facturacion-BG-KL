using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Req
{
    public class ClienteDtoReq
    {
        public ClienteDtoReq(
            string identificacion,
            string tipoIdentificacion,
            string nombre,
            string telefono,
            string email,
            string direccion) 
        {
            Identificacion = identificacion;
            TipoIdentifiacion = tipoIdentificacion;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
        }

        public string Identificacion { get; set; }
        public string TipoIdentifiacion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

    }
}
