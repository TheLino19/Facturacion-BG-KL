using FCT.BE.Commons.Dtos.Req;
using FCT.BE.Commons.Dtos.Resp.Usuario;
using FCT.BE.Commons.Helpers;
using FCT.BE.Model.Respuesta;
using FCT.BL.Helper;
using FCT.BL.Helper.Response;
using FCT.DAC.Repositorios.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BL.Services.Usuario
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidator<UsurarioDtoReq> _validator;
        private readonly IValidator<DtoUsuarioEdit> _validatorEdit;
        public UsuarioServices(
            IUsuarioRepository usuarioRepository,
            IValidator<UsurarioDtoReq> validator,
            IValidator<DtoUsuarioEdit> validatorEdit)
        {
            _usuarioRepository = usuarioRepository;
            _validator = validator;
            _validatorEdit = validatorEdit;
        }
        public async Task<ResponseModel<string>> CrearUsuario(UsurarioDtoReq usuarioDtoReq)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {
                var validationResult = await _validator.ValidateAsync(usuarioDtoReq);
                if (!validationResult.IsValid)
                    return ResponseResult<string>.BuildValidationErrorResponse(validationResult); 
                        
                responseModel.Data = await _usuarioRepository.CrearUsuario(usuarioDtoReq);
                responseModel.Message = MessageResponse.UsuarioCorrecto;
            }catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<string>> EditarUsuario(DtoUsuarioEdit dtoUsuarioEdit)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            try
            {
                var validationResult = await _validatorEdit.ValidateAsync(dtoUsuarioEdit);
                if (!validationResult.IsValid)
                    return ResponseResult<string>.BuildValidationErrorResponse(validationResult);

                responseModel.Data = await _usuarioRepository.EditarUsuario(dtoUsuarioEdit);
                responseModel.Message = MessageResponse.UsuarioModificado;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<DtoUsuarioResp>> ObtenerUsuario(int Id)
        {
            ResponseModel<DtoUsuarioResp> responseModel = new();
            try
            {
                if(Id == -1)
                  return new ResponseModel<DtoUsuarioResp>( false ,MessageResponse.UsuarioError);

                DtoUsuarioResp usuario = await _usuarioRepository.ObtenerUsuario(Id);
                if (usuario == null)
                    return new ResponseModel<DtoUsuarioResp>(false , MessageResponse.UsuarioError);

                responseModel.Data = usuario;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<DtoUsuarioResp>>> ObtenerUsuarios(FiltrosUsuario filtrosUsuario)
        {
            ResponseModel<List<DtoUsuarioResp>> responseModel = new();
            try
            {
                responseModel.Data = await _usuarioRepository.ObtenerUsuarios(filtrosUsuario);
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = MessageResponse.OcurrioError;
            }
            return responseModel;
        }
        public async Task<ResponseModel<int>> EliminarUsuarios(int Id)
        {
            ResponseModel<int> responseModel = new();
            try
            {
                if (Id == -1)
                    return new ResponseModel<int>(false, MessageResponse.UsuarioError);

                int resp = await _usuarioRepository.EliminarUsuario(Id);
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
