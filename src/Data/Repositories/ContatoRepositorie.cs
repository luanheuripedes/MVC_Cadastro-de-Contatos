using ControleDeContatos.Entities;
using Data.Context;
using Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ContatoRepositorie : IContatoRepositorie
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorie(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task AdicionarAsync(ContatoEntitie contato)
        {
            await _bancoContext.Contatos.AddAsync(contato);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<List<ContatoEntitie>> BuscarTodosAsync()
        {
           return await _bancoContext.Contatos.ToListAsync();
        }
    }
}
