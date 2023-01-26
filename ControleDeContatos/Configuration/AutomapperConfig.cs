using AutoMapper;
using Data.Entities;
using Services.DTO;
using ControleDeContatos.Models.Contato;
using ControleDeContatos.Models.Usuario;

namespace ControleDeContatos.Configuration
{
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<UsuarioModel, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            CreateMap<UsuarioDTO, EditarUsuarioModel>().ReverseMap();




            CreateMap<ContatoDTO, ContatoModel>().ReverseMap();
            CreateMap<ContatoDTO, Contato>().ReverseMap();
        }
    }
}
