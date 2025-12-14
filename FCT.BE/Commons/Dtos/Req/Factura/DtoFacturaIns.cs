using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Req.Factura
{
    public class DtoFacturaIns
    {
        public DtoFacturaIns() { }

        public string  NumeroFactura { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public decimal Total {  get; set; }
        public string TipoPago { get; set; }
        public string EstadoPago { get; set; }

    }
}
