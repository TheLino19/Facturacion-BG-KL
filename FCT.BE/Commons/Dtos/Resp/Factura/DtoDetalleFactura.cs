using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Resp.Factura
{
    public  class DtoDetalleFactura
    {
        public int FacturaDetalleId { get; set; }
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioSubtotal { get; set; }

    }
}
