using FCT.BE.Commons.Dtos.Req;
using FCT.BL.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BL.Validator
{
    public class UsuarioEditValidator : AbstractValidator<DtoUsuarioEdit>
    {
        public UsuarioEditValidator()
        {

            RuleFor(x => x.Email)
               .NotEmpty().EmailAddress()
               .WithMessage(MessageValidator.EmailInvalido);

            RuleFor(x => x.Nombre)
               .NotEmpty()
               .WithMessage(MessageValidator.NombreInvalido);

            RuleFor(x => x.Rol)
               .NotEmpty()
               .WithMessage(MessageValidator.RolObligatorio);
        }
    }
}
