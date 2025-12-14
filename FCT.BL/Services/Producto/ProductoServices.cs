using FCT.BE.Commons.Dtos.Req.Producto;
using FCT.BE.Commons.Dtos.Resp.Producto;
using FCT.BE.Model.Respuesta;
using FCT.BL.Helper;
using FCT.DAC.Repositorios.Producto;

namespace FCT.BL.Services.Producto
{
    public class ProductoServices : IProductoServices
    {

        private readonly IProductoRepository _ProductoRepository;
        public ProductoServices(
            IProductoRepository ProductoRepository)
        {
            _ProductoRepository = ProductoRepository;
        }
        public async Task<ResponseModel<string>> CrearProducto(DtoProductoIns dtoProductoIns)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {

                responseModel.Data = await _ProductoRepository.CrearProducto(dtoProductoIns);
                responseModel.Message = MessageResponse.ProductoCorrecto;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<string>> EditarProducto(DtoProductoEdit dtoProductoEdit)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {
                responseModel.Data = await _ProductoRepository.EditarProducto(dtoProductoEdit);
                responseModel.Message = MessageResponse.ProductoModificado;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<DtoProductoResp>> ObtenerProducto(int Id)
        {
            ResponseModel<DtoProductoResp> responseModel = new();
            try
            {
                if (Id == -1)
                    return new ResponseModel<DtoProductoResp>(false, MessageResponse.ProductoError);

                DtoProductoResp Producto = await _ProductoRepository.ObtenerProducto(Id);
                if (Producto == null)
                    return new ResponseModel<DtoProductoResp>(false, MessageResponse.ProductoError);

                responseModel.Data = Producto;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<DtoProductoResp>>> ObtenerProductos()
        {
            ResponseModel<List<DtoProductoResp>> responseModel = new();
            try
            {
                responseModel.Data = await _ProductoRepository.ObtenerProductos();
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<int>> EliminarProductos(int Id)
        {
            ResponseModel<int> responseModel = new();
            try
            {
                if (Id == -1)
                    return new ResponseModel<int>(false, MessageResponse.ProductoError);

                int resp = await _ProductoRepository.EliminarProductos(Id);
                if (resp == 0)
                    return new ResponseModel<int>(false, MessageResponse.ProductoError);

                responseModel.Message = MessageResponse.ProductoEliminado;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }
    }
}
