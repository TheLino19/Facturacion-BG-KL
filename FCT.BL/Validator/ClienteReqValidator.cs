using FCT.BE.Commons.Dtos.Req.Cliente;
using FCT.BL.Helper;
using FluentValidation;

namespace FCT.BL.Validator
{
    public class ClienteReqValidator : AbstractValidator<DtoClienteIns>
    {
        public ClienteReqValidator()
        {
            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage(MessageValidator.TelefonoObligatorio);

            RuleFor(x => x.Email)
               .NotEmpty().EmailAddress()
               .WithMessage(MessageValidator.EmailInvalido);

            RuleFor(x => x.Nombre)
               .NotEmpty()
               .WithMessage(MessageValidator.NombreInvalido);

            RuleFor(x => x.Identificacion)
               .NotEmpty()
               .WithMessage(MessageValidator.IdentificacionObligatorio);

            RuleFor(x => x.TipoIdentifiacion)
               .NotEmpty()
               .WithMessage(MessageValidator.TipoIdentifiacionObligatorio);
        }
    }
}
