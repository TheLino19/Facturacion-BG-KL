using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Resp.cliente
{
    public class DtoClienteResp
    {
        public DtoClienteResp()
        {
            
        }
        public DtoClienteResp(int clienteId, string nombre, string telefono, string correo, string direccion)
        {
            ClienteId = clienteId;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
        }
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion {  get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }


    }
}
