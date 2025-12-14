using FCT.BE.Commons.Dtos.Req.Factura;
using FCT.BE.Commons.Dtos.Resp.Factura;
using FCT.BE.Commons.Helpers;
using FCT.BE.Model.Respuesta;

namespace FCT.BL.Services.Factura
{
    public interface IFacturaServices
    {
        Task<ResponseModel<string>> CrearFactura(DtoFacturaIns dtoFacturaIns);
        Task<ResponseModel<DtoFacturaResp>> ObtenerFactura(int Id);
        Task<ResponseModel<List<DtoFacturaCab>>> ObtenerFacturas(FiltroFactura filtroFactura);
        Task<ResponseModel<int>> EliminarFactura(int Id);
        Task<ResponseModel<string>> InsertarDetalleFactura(List<DtoFacturaEdit> dtoFacturaEdit);
        Task<ResponseModel<int>> EliminarDetalleFactura(int Id);
    }
}
