using Data.Context;
using Data.Repositories.Interface;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Interface;
using Infrastructure.Repositories;
using Services.Servicies.Interfaces;
using Services.Servicies;

namespace ControleDeContatos.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static WebApplicationBuilder ResolveDependencies(this WebApplicationBuilder builder)
        {
            // Add context Bd EF
            var connectionString = builder.Configuration.GetConnectionString("ContatoConnectionString");
            builder.Services.AddDbContext<BancoContext>(options => options.UseMySql(connectionString,
                                                                         ServerVersion.AutoDetect(connectionString)));

            //Injeção Repositories
            builder.Services.AddScoped<IContatoRepositorie, ContatoRepositorie>();
            builder.Services.AddScoped<IUsuarioRepositorie, UsuarioRepositorie>();
            

            //Services
            builder.Services.AddScoped<IContatoService, ContatoService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();


            return builder;
        }
    }
}
