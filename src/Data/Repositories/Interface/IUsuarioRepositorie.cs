using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IUsuarioRepositorie
    {
        Task AdicionarAsync(UsuarioEntitie entite);
        Task<List<UsuarioEntitie>> BuscarTodosAsync();
        Task<UsuarioEntitie> BuscarPorIdAsync(int id);
        Task AtualizarAsync(UsuarioEntitie entitie);
        Task<bool> ApagarAsync(int id);
    }
}
