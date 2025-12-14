using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Resp.Factura
{
    public class DtoFacturaResp
    {
        public DtoFacturaResp() { }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Vendedor { get; set; }
        public DateTime FechaCreacion { get; set; } 
        public string TipoPago { get; set; }
        public string EstadoPago { get; set; }
        public List<DtoDetalleFactura> dtoDetalleFacturas { get; set; } = new List<DtoDetalleFactura>();

    }
}
