using AutoMapper;
using Data.Entities;
using ControleDeContatos.Models;
using Services.DTO;

namespace ControleDeContatos.Configuration
{
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<UsuarioModel, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();




            CreateMap<ContatoDTO, ContatoModel>().ReverseMap();
            CreateMap<ContatoDTO, Contato>().ReverseMap();
        }
    }
}
