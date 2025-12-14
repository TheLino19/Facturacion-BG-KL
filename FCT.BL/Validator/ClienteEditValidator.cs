using FCT.BE.Commons.Dtos.Req.Cliente;
using FCT.BL.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BL.Validator
{
    public class ClienteEditValidator : AbstractValidator<DtoClienteEdit>
    {
        public ClienteEditValidator()
        {
            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage(MessageValidator.TelefonoObligatorio);

            RuleFor(x => x.Email)
               .NotEmpty().EmailAddress()
               .WithMessage(MessageValidator.EmailInvalido);

            RuleFor(x => x.Nombre)
               .NotEmpty()
               .WithMessage(MessageValidator.NombreInvalido);

            RuleFor(x => x.Direccion)
               .NotEmpty()
               .WithMessage(MessageValidator.DireccionObligatorio);

        }
    }
}
