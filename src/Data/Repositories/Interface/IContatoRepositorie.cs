using ControleDeContatos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IContatoRepositorie
    {
        Task AdicionarAsync(ContatoEntitie contato);
        Task<List<ContatoEntitie>> BuscarTodosAsync();
    }
}
