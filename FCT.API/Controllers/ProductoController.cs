using FCT.BE.Commons.Dtos.Req.Producto;
using FCT.BE.Commons.Dtos.Resp.Producto;
using FCT.BE.Model.Respuesta;
using FCT.BL.Services.Producto;
using Microsoft.AspNetCore.Mvc;

namespace FCT.API.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoServices _ProductoServices;
        public ProductoController(
            IProductoServices ProductoServices)
        {
            _ProductoServices = ProductoServices;
        }

        [HttpPost("CrearProducto")]
        public async Task<ResponseModel<string>> CrearProducto([FromBody] DtoProductoIns dtoProductoEdit)
        {
            return await _ProductoServices.CrearProducto(dtoProductoEdit);
        }

        [HttpPost("EditarProducto")]
        public async Task<ResponseModel<string>> EditarProducto([FromBody] DtoProductoEdit dtoProductoEdit)
        {
            return await _ProductoServices.EditarProducto(dtoProductoEdit);
        }

        [HttpPost("ObtenerProducto")]
        public async Task<ResponseModel<DtoProductoResp>> ObtenerProducto(int Id)
        {
            return await _ProductoServices.ObtenerProducto(Id);
        }

        [HttpGet("ObtenerProductos")]
        public async Task<ResponseModel<List<DtoProductoResp>>> ObtenerProductos()
        {
            return await _ProductoServices.ObtenerProductos();
        }
        [HttpPost("EliminarProductos")]
        public async Task<ResponseModel<int>> EliminarProducto(int Id)
        {
            return await _ProductoServices.EliminarProductos(Id);
        }
    }
}
