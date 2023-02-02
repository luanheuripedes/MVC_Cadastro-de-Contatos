using ControleDeContatos.Helper.Criptografia;
using Data.Entities.Enuns;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models.Usuario
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome precisa ser informado!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login precisa ser informado!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O email precisa ser informado!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O perfil precisa ser informado!")]
        public EnumPerfil Perfil { get; set; }

        [Required(ErrorMessage = "A senha precisa ser informada!")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

        /*
        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
        */
        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
