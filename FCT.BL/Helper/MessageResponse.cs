using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BL.Helper
{
    public static class MessageResponse
    {
        public const string ErrorCampos = "Error de validacion";
        public const string OcurrioError = "Ocurrio un error en el sistema";


        public const string UsuarioCorrecto = "Usuario Registrado";
        public const string UsuarioModificado = "Usuario Modificado";
        public const string UsuarioEliminado = "Usuario Eliminado";
        public const string UsuarioError = "Usuario fuera del Rango";

        public const string FacturaCorrecto = "Factura Registrada";
        public const string FacturaError = "Factura fuera del Rango";
        public const string FacturaEmpty = "Factura no se encuentra en la BD";
        public const string FacturaEliminada = "Factura Eliminada";

        public const string DetallesCorrecto = "Detalles Registrada";
        public const string DetallesError = "Detalles fuera del Rango";
        public const string DetallesEmpty = "Detalles no se encuentra en la BD";
        public const string DetallesEliminada = "Detalles Eliminada";

        public const string SinDetalles = "No existen detalles por actualizar";

        public const string ProductoCorrecto = "Producto Registrado";
        public const string ProductoModificado = "Producto Modificado";
        public const string ProductoEliminado = "Producto Eliminado";
        public const string ProductoError = "Producto fuera del Rango";

    }
}
