using FCT.BE.Commons.Dtos.Req.Factura;
using FCT.BE.Commons.Dtos.Resp.Factura;
using FCT.BE.Commons.Helpers;
using FCT.BE.Model.Respuesta;
using FCT.BL.Services.Factura;
using Microsoft.AspNetCore.Mvc;

namespace FCT.API.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IFacturaServices _facturaServices;
        public FacturaController(
            IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }

        [HttpPost("CrearFactura")]
        public async Task<ResponseModel<string>> CrearFactura([FromBody] DtoFacturaIns dtoFactura)
        {
            return await _facturaServices.CrearFactura(dtoFactura);
        }

        [HttpPost("EditarFactura")]
        public async Task<ResponseModel<string>> InsertarDetalleFactura([FromBody] DtoFacturaEdit dtoFacturaEdit)
        {
            return await _facturaServices.InsertarDetalleFactura(dtoFacturaEdit);
        }

        [HttpPost("ObtenerFactura")]
        public async Task<ResponseModel<DtoFacturaResp>> ObtenerFactura(int Id)
        {
            return await _facturaServices.ObtenerFactura(Id);
        }

        [HttpPost("ObtenerFacturas")]
        public async Task<ResponseModel<List<DtoFacturaCab>>> ObtenerFacturas(FiltroFactura filtroFactura)
        {
            return await _facturaServices.ObtenerFacturas(filtroFactura);
        }
        [HttpPost("EliminarFactura")]
        public async Task<ResponseModel<int>> EliminarFactura(int Id)
        {
            return await _facturaServices.EliminarFacturas(Id);
        }
    }
}
