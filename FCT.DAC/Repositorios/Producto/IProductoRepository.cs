using FCT.BE.Commons.Dtos.Req.Producto;
using FCT.BE.Commons.Dtos.Resp.Producto;
using FCT.BE.Model.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.DAC.Repositorios.Producto
{
    public interface IProductoRepository
    {
        Task<string> CrearProducto(DtoProductoIns dtoProductoIns);
        Task<string> EditarProducto(DtoProductoEdit dtoProductoEdit);
        Task<DtoProductoResp> ObtenerProducto(int Id);
        Task<List<DtoProductoResp>> ObtenerProductos();
        Task<int> EliminarProductos(int Id);
    }
}
