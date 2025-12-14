using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Helpers
{
    public class FiltroFactura
    {
        public FiltroFactura() { }

        public string FiltroNumeroFactura { get; set; }
        public DateTime FiltroFecha { get; set; }
        public decimal FiltroMonto { get; set; }
        public bool FiltroEstado { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
