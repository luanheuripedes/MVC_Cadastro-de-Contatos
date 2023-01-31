using Data.Context;
using Data.Repositories.Interface;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Interface;
using Infrastructure.Repositories;
using Services.Servicies.Interfaces;
using Services.Servicies;
using Microsoft.AspNetCore.Http;
using ControleDeContatos.Helper.Session;

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

            //INJETANDO A CLASSE HTTPcONTEXT
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //aDICIONADO A SESSAO
            builder.Services.AddScoped<ISessao, Sessao>();

            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential= true;
            });



            //Injeção Repositories
            builder.Services.AddScoped<IContatoRepositorie, ContatoRepositorie>();
            builder.Services.AddScoped<IUsuarioRepositorie, UsuarioRepositorie>();
            

            //Services
            builder.Services.AddScoped<IContatoService, ContatoService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<ILoginService, LoginService>();




            return builder;
        }
    }
}
