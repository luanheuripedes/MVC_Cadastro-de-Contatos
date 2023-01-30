using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models.Login
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "O email precisa ser informado!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O login precisa ser informado!")]
        public string Login { get; set; }
    }
}
