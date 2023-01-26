using Data.Entities.Enuns;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Usuario: Base
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public EnumPerfil Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
