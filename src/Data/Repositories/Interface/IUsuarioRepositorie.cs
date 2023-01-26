using Data.Entities;
using Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IUsuarioRepositorie: IBaseRepositorie<Usuario>
    {
        //Task AdicionarAsync(Usuario entite);
        //Task<List<Usuario>> BuscarTodosAsync();
        //Task<Usuario> BuscarPorIdAsync(int id);
        //Task AtualizarAsync(Usuario entitie);
        //Task<bool> ApagarAsync(int id);
    }
}
