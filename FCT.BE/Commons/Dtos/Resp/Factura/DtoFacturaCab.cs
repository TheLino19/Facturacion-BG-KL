using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Resp.Factura
{
    public class DtoFacturaCab
    {
        public DtoFacturaCab() { }

        public int FacturaId { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string NombreCliente { get; set; }
        public string NombresCompleto { get; set; }
        public string EstadoFactura { get; set; }
        public decimal TotalFactura { get; set; }
        public bool Activo {  get; set; }

    }
}
