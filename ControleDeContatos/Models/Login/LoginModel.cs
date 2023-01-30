using ControleDeContatos.Helper;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o nome do usuário", AllowEmptyStrings = false)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
    }
}
