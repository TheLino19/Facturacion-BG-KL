using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.DAC.Helpers.Utils
{
    public static class StoredProcedure
    {
        public const string SP_InsertarUsuario = "SP_InsertarUsuarios";
        public const string SP_EditarUsuarios = "SP_EditarUsuarios";
        public const string SP_EliminarUsuario = "SP_EliminarUsuario";
        public const string SP_ObtenerUsuarioId = "SP_ObtenerUsuarioId";
        public const string SP_ObtenerUsuarios = "SP_ObtenerUsuarios";

        public const string SP_InsertarCliente = "SP_InsertarClientes";
        public const string SP_EditarClientes = "SP_EditarCliente";
        public const string SP_EliminarCliente = "SP_EliminarCliente";
        public const string SP_ObtenerClienteId = "SP_ObtenerClienteId";
        public const string SP_ObtenerClientes = "SP_ObtenerClientes";

        public const string SP_EliminarFacturasDetalles = "SP_EliminarFacturasDetalles";
        public const string SP_InsertarFacturas = "SP_InsertarFacturas";
        public const string SP_InsertarFacturasDetalles = "SP_InsertarFacturasDetalles";
        public const string SP_ObtenerFacturaCabId = "SP_ObtenerFacturaCabId";
        public const string SP_ObtenerFacturaDetaId = "SP_ObtenerFacturaDetaId";
        public const string SP_ObtenerFacturas = "SP_ObtenerFacturas";
        public const string SP_EliminarFactura = "SP_EliminarFactura";


        public const string SP_InsertarProducto = "SP_InsertarProducto";
        public const string SP_EditarProducto = "SP_EditarProducto";
        public const string SP_EliminarProducto = "SP_EliminarProducto";
        public const string SP_ObtenerProductoId = "SP_ObtenerProductoId";
        public const string SP_ObtenerProductos = "SP_ObtenerProductos";
    }
}
