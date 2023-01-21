using AutoMapper;
using ControleDeContatos.Entities;
using ControleDeContatos.Models;

namespace ControleDeContatos.Configuration
{
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ContatoModel, ContatoEntitie>().ReverseMap();
        }
    }
}
