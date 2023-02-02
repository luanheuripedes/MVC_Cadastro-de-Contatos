using Data.Context;
using Data.Entities;
using Data.Repositories.Interface;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ContatoRepositorie : BaseRepositorie<Contato>, IContatoRepositorie
    {

        private readonly BancoContext _context;

        public ContatoRepositorie(BancoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Contato>> BuscarContatosPorUsuarioAsync(int id)
        {
            return await _context.Contatos.Where(x => x.UsuarioId == id).AsNoTracking().ToListAsync();
        }
    }
}
