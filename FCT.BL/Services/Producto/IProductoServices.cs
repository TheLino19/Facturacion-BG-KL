using FCT.BE.Commons.Dtos.Req.Producto;
using FCT.BE.Commons.Dtos.Resp.Producto;
using FCT.BE.Model.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BL.Services.Producto
{
    public interface IProductoServices
    {
        Task<ResponseModel<string>> CrearProducto(DtoProductoIns dtoProductoIns);
        Task<ResponseModel<string>> EditarProducto(DtoProductoEdit dtoProductoEdit);
        Task<ResponseModel<DtoProductoResp>> ObtenerProducto(int Id);
        Task<ResponseModel<List<DtoProductoResp>>> ObtenerProductos();
        Task<ResponseModel<int>> EliminarProductos(int Id);
    }
}
