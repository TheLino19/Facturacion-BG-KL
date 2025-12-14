using FCT.BE.Commons.Dtos.Req;
using FCT.BE.Commons.Dtos.Req.Cliente;
using FCT.BE.Commons.Dtos.Resp.cliente;
using FCT.BE.Commons.Dtos.Resp.Usuario;
using FCT.BE.Commons.Helpers;
using FCT.BE.Model.Respuesta;
using FCT.BL.Helper;
using FCT.BL.Helper.Response;
using FCT.DAC.Repositorios.Cliente;
using FluentValidation;

namespace FCT.BL.Services.Cliente
{
    public class ClienteServices : IClienteServices
    {
        private readonly IValidator<DtoClienteIns> _validator;
        private readonly IValidator<DtoClienteEdit> _validatorEdit;
        private readonly IClienteRepository _clienteRepository;
        public ClienteServices(
            IValidator<DtoClienteIns> validator,
            IValidator<DtoClienteEdit> validatorEdit,
            IClienteRepository clienteRepository)
        {
            _validator = validator;
            _validatorEdit = validatorEdit;
            _clienteRepository = clienteRepository;
        }
        public async Task<ResponseModel<string>> CrearCliente(DtoClienteIns dtoClienteIns)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {
                var validationResult = await _validator.ValidateAsync(dtoClienteIns);
                if (!validationResult.IsValid)
                    return ResponseResult<string>.BuildValidationErrorResponse(validationResult);

                responseModel.Data = await _clienteRepository.CrearCliente(dtoClienteIns);
                responseModel.Message = MessageResponse.UsuarioCorrecto;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<string>> EditarCliente(DtoClienteEdit dtoClienteEdit)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {
                var validationResult = await _validatorEdit.ValidateAsync(dtoClienteEdit);
                if (!validationResult.IsValid)
                    return ResponseResult<string>.BuildValidationErrorResponse(validationResult);

                responseModel.Data = await _clienteRepository.EditarCliente(dtoClienteEdit);
                responseModel.Message = MessageResponse.UsuarioModificado;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<DtoClienteResp>> ObtenerCliente(int Id)
        {
            ResponseModel<DtoClienteResp> responseModel = new();
            try
            {
                if (Id == -1)
                    return new ResponseModel<DtoClienteResp>(false, MessageResponse.UsuarioError);

                DtoClienteResp usuario = await _clienteRepository.ObtenerCliente(Id);
                if (usuario == null)
                    return new ResponseModel<DtoClienteResp>(false, MessageResponse.UsuarioError);

                responseModel.Data = usuario;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<DtoClienteResp>>> ObtenerClientes(FiltrosUsuario filtrosCliente)
        {
            ResponseModel<List<DtoClienteResp>> responseModel = new();
            try
            {
                responseModel.Data = await _clienteRepository.ObtenerClientes(filtrosCliente);
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<int>> EliminarClientes(int Id)
        {
            ResponseModel<int> responseModel = new();
            try
            {
                if (Id == -1)
                    return new ResponseModel<int>(false, MessageResponse.UsuarioError);

                int resp = await _clienteRepository.EliminarCliente(Id);
                if (resp == 0)
                    return new ResponseModel<int>(false, MessageResponse.UsuarioError);

                responseModel.Message = MessageResponse.UsuarioEliminado;
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
