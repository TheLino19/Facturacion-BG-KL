using FCT.BE.Commons.Dtos.Req.Factura;
using FCT.BE.Commons.Dtos.Resp.Factura;
using FCT.BE.Commons.Helpers;

namespace FCT.DAC.Repositorios.Factura
{
    public interface IFacturaRepository
    {
        Task<string> CrearFactura(DtoFacturaIns dtoFacturaIns);
        Task<int> EliminarFactura(int Id);
        Task<DtoFacturaResp> ObtenerFactura(int Id);
        Task<List<DtoFacturaCab>> ObtenerFacturas(FiltroFactura filtroFactura);
        Task<int> EliminarDetalleFactura(int Id);
        Task<int> InsertarDetalleFactura(DtoFacturaEdit dtoFacturaEdit);


    }
}
