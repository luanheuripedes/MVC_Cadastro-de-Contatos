using Data.Entities;
using Data.Context;
using Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;

namespace Data.Repositories
{
    public class UsuarioRepositorie : BaseRepositorie<Usuario>, IUsuarioRepositorie
    {
        private readonly BancoContext _context;
        public UsuarioRepositorie(BancoContext bancoContext) : base(bancoContext)
        {
            _context = bancoContext;
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
