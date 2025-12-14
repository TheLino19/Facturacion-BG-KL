using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Req.Factura
{
    public class DtoFacturaEdit
    {
        public DtoFacturaEdit() { }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public  decimal PrecioUnitario { get; set; }
        public decimal @SubTotal { get; set; }
    }
}
