using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models.Alterar
{
    public class AlterarSenhaModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Digite a senha atual do usuário")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Digite a nova senha.")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NovaSenha",ErrorMessage = "Senha não confere com nova senha.")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
