using Data.Context;
using Data.Entities;
using Data.Repositories.Interface;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UsuarioRepositorie : BaseRepositorie<Usuario>, IUsuarioRepositorie
    {
        private readonly BancoContext _context;
        public UsuarioRepositorie(BancoContext bancoContext) : base(bancoContext)
        {
            _context = bancoContext;
        }

        public async override Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.Include(x => x.Contatos).ToListAsync();
        }

        public async Task<Usuario> BuscarPorEmailLoginAsync(string login, string email)
        {
            return await _context.Usuarios.AsNoTracking()
                .FirstOrDefaultAsync(predicate: x => x.Login == login && x.Email == email);
        }

        public async Task<Usuario> BuscarPorLoginSenha(string login, string senha)
        {
            return await _context.Usuarios.AsNoTracking()
                .FirstOrDefaultAsync(predicate: x => x.Login == login && x.Senha == senha);
        }
    }
}
