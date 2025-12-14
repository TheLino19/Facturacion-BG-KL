using FCT.BE.Commons.Dtos.Req.Factura;
using FCT.BE.Commons.Dtos.Resp.Factura;
using FCT.BE.Commons.Helpers;
using FCT.BE.Model.Respuesta;
using FCT.BL.Helper;
using FCT.DAC.Repositorios.Factura;

namespace FCT.BL.Services.Factura
{
    public class FacturaServices : IFacturaServices
    {
        private readonly IFacturaRepository _facturaRepository;
        public FacturaServices(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }
        public async Task<ResponseModel<string>> CrearFactura(DtoFacturaIns dtoFacturaIns)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {
                responseModel.Data = await _facturaRepository.CrearFactura(dtoFacturaIns);
                responseModel.Message = MessageResponse.FacturaCorrecto;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError + ex.Message.ToString();
            }
            return responseModel;
        }

        public async Task<ResponseModel<int>> EliminarFactura(int Id)
        {
            ResponseModel<int> responseModel = new();
            try
            {
                if (Id == -1)
                    return new ResponseModel<int>(false, MessageResponse.FacturaError);

                int resp = await _facturaRepository.EliminarFactura(Id);
                if (resp == 0)
                    return new ResponseModel<int>(false, MessageResponse.FacturaEmpty);

                responseModel.Message = MessageResponse.FacturaEliminada;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError + ex.Message.ToString();
            }
            return responseModel;
        }
        public async Task<ResponseModel<DtoFacturaResp>> ObtenerFactura(int Id)
        {
            ResponseModel<DtoFacturaResp> responseModel = new();
            try
            {
                if (Id == -1)
                    return new ResponseModel<DtoFacturaResp>(false, MessageResponse.FacturaError);

                DtoFacturaResp factura = await _facturaRepository.ObtenerFactura(Id);
                if (factura == null)
                    return new ResponseModel<DtoFacturaResp>(false, MessageResponse.FacturaEmpty);

                responseModel.Data = factura;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError + ex.Message.ToString();
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<DtoFacturaCab>>> ObtenerFacturas(FiltroFactura filtroFactura)
        {
            ResponseModel<List<DtoFacturaCab>> responseModel = new();
            try
            {
                responseModel.Data = await _facturaRepository.ObtenerFacturas(filtroFactura);
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError + ex.Message.ToString();
            }
            return responseModel;
        }

        public async Task<ResponseModel<int>> EliminarDetalleFactura(int Id)
        {
            ResponseModel<int> responseModel = new();
            try
            {
                if (Id == -1)
                    return new ResponseModel<int>(false, MessageResponse.DetallesError);

                int resp = await _facturaRepository.EliminarDetalleFactura(Id);
                if (resp == 0)
                    return new ResponseModel<int>(false, MessageResponse.DetallesEmpty);

                responseModel.Message = MessageResponse.DetallesEliminada;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError + ex.Message.ToString();
            }
            return responseModel;
        }

        public async Task<ResponseModel<string>> InsertarDetalleFactura(List<DtoFacturaEdit> dtoFacturaEdit)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {
                if(dtoFacturaEdit.Count > 0)
                    return new ResponseModel<string>(false, MessageResponse.SinDetalles);
                
                foreach(DtoFacturaEdit dtoFactura in dtoFacturaEdit)
                {
                    await _facturaRepository.InsertarDetalleFactura(dtoFactura);
                }
                responseModel.Message = MessageResponse.DetallesCorrecto;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError + ex.Message.ToString();
            }
            return responseModel;
        }
    }
}
