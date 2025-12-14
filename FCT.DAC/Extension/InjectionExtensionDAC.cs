using FCT.DAC.Repositorios.Cliente;
using FCT.DAC.Repositorios.Factura;
using FCT.DAC.Repositorios.Usuario;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.DAC.Extension
{
    public static class InjectionExtensionDAC
    {
        public static IServiceCollection AddInjectionDAC(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IFacturaRepository, FacturaRepository>();
            return services;
        }
    }
}
