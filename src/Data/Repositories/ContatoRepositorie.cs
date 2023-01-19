using ControleDeContatos.Entities;
using Data.Context;
using Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task ApagarAsync(int id)
        {
            var contato = await BuscarPorIdAsync(id);
            if (contato == null)
            {
                throw new Exception("Houve um erro na deleção do contato!");
            }

            _bancoContext.Contatos.Remove(contato);
            await _bancoContext.SaveChangesAsync();

        }

        public async Task AtualizarAsync(ContatoEntitie contatoEntite)
        {
            var contato = await BuscarPorIdAsync(contatoEntite.Id);

            if(contato == null)
            {
                throw new Exception("Houve um erro na atualização do contato!");
            }

            contato.Nome = contatoEntite.Nome;
            contato.Email = contatoEntite.Email;
            contato.Celular = contatoEntite.Celular;

             _bancoContext.Contatos.Update(contato);
            await _bancoContext.SaveChangesAsync();


        }

        public async Task<ContatoEntitie> BuscarPorIdAsync(int id)
        {
            return await _bancoContext.Contatos.AsNoTracking().FirstOrDefaultAsync(x =>x.Id == id);
        }

        public async Task<List<ContatoEntitie>> BuscarTodosAsync()
        {
           return await _bancoContext.Contatos.AsNoTracking().ToListAsync();
        }
    }
}
