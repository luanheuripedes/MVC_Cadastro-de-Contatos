using ControleDeContatos.Models.Usuario;

namespace ControleDeContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuarioModel);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
