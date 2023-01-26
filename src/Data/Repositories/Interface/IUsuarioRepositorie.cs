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
        Task<Usuario> BuscarPorLoginSenha(string login, string senha);
    }
}
