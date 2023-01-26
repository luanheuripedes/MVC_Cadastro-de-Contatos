using Data.Entities;
using Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IContatoRepositorie:IBaseRepositorie<Contato>
    {
        //Task AdicionarAsync(Contato contato);
        //Task<List<Contato>> BuscarTodosAsync();
        //Task<Contato> BuscarPorIdAsync(int id);
        //Task AtualizarAsync(Contato contatoEntite);
        //Task<bool> ApagarAsync(int id);
    }
}
