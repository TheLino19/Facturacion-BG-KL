using FCT.BL.Services.Cliente;
using FCT.BL.Services.Factura;
using FCT.BL.Services.Usuario;
using FCT.BL.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FCT.BL.Extensions
{
    public static class InjectionExtensionsBL
    {
        public static IServiceCollection AddInjectionBL(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<UsuarioRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UsuarioEditValidator>();
            services.AddValidatorsFromAssemblyContaining<ClienteEditValidator>();
            services.AddValidatorsFromAssemblyContaining<ClienteReqValidator>();

            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IClienteServices, ClienteServices>();
            services.AddTransient<IFacturaServices, FacturaServices>();
            return services;
        }
    }
}
