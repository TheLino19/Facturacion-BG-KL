using FCT.BE.Model.Respuesta;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BL.Helper.Response
{
    public static class ResponseResult<T>
    {
        public static ResponseModel<T> BuildValidationErrorResponse(ValidationResult validationResult)
        {
            return new ResponseModel<T>
            {
                Success = false,
                Message = MessageResponse.ErrorCampos,
                Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
            };
        }
    }
}
