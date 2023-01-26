using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models.Contato
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome precisa ser informado!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email precisa ser informado!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O celular precisa ser informado!")]
        [Phone(ErrorMessage = "O celular informado não é valido"!)]
        public string Celular { get; set; }
    }
}
