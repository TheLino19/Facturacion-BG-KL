using FCT.BE.Commons.Dtos.Req;
using FCT.BL.Helper;
using FluentValidation;

namespace FCT.BL.Validator
{
    public class UsuarioRequestValidator : AbstractValidator<UsurarioDtoReq>
    {
        public UsuarioRequestValidator() 
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(MessageValidator.UsuarioObligatorio);

            RuleFor(x => x.Email)
               .NotEmpty().EmailAddress()
               .WithMessage(MessageValidator.EmailInvalido);

            RuleFor(x => x.Nombre)
               .NotEmpty()
               .WithMessage(MessageValidator.NombreInvalido);

            RuleFor(x => x.Apellido)
               .NotEmpty()
               .WithMessage(MessageValidator.ApellidoObligatorio);

            RuleFor(x => x.Rol)
               .NotEmpty()
               .WithMessage(MessageValidator.RolObligatorio);
        }
    }
}
