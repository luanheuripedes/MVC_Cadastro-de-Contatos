using AutoMapper;
using Data.Entities;
using ControleDeContatos.Models;

namespace ControleDeContatos.Configuration
{
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ContatoModel, UsuarioEntitie>().ReverseMap();
            CreateMap<UsuarioModel, UsuarioEntitie>().ReverseMap();
        }
    }
}
