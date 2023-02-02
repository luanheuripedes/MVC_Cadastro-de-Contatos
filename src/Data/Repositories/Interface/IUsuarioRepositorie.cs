using Data.Entities;
using Infrastructure.Repositories.Interface;

namespace Data.Repositories.Interface
{
    public interface IUsuarioRepositorie : IBaseRepositorie<Usuario>
    {
        Task<Usuario> BuscarPorEmailLoginAsync(string login, string email);
        Task<Usuario> BuscarPorLoginSenha(string login, string senha);
    }
}
