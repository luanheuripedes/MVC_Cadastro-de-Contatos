using Data.Entities.Enuns;
using Domain.Entities;

namespace Data.Entities
{
    public class Usuario : Base
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public EnumPerfil Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual List<Contato> Contatos { get; set; }
    }
}
