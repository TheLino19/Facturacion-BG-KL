using FCT.BL.Services.Usuario;
using FCT.BL.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BL.Extensions
{
    public static class InjectionExtensionsBL
    {
        public static IServiceCollection AddInjectionBL(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<UsuarioRequestValidator>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            return services;
        }
    }
}
