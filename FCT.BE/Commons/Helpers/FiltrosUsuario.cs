using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BE.Commons.Helpers
{
    public class FiltrosUsuario
    {
        public bool? Estado { get; set; } 
        public string Nombre { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;


    }
}
