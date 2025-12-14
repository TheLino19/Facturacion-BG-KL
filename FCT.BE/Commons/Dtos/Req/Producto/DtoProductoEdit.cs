using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Req.Producto
{
    public class DtoProductoEdit
    {
        public DtoProductoEdit() { }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Decimal PrecioUnitario { get; set; }
    }
}
