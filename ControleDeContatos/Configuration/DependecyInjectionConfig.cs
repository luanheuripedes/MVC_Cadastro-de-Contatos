using Data.Context;
using Data.Repositories.Interface;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

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

            return builder;
        }
    }
}
