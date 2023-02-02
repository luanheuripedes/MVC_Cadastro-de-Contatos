using Domain.Entities;

namespace Data.Entities
{
    public class Contato : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
