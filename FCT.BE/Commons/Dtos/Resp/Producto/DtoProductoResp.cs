using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Dtos.Resp.Producto
{
    public class DtoProductoResp
    {
        public DtoProductoResp()
        {
            
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public Decimal PrecioUnitario { get; set; }
    }
}
