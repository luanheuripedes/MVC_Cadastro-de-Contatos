using Data.Entities;
using Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interface
{
    public interface IContatoRepositorie:IBaseRepositorie<Contato>
    {
        Task<List<Contato>> BuscarContatosPorUsuarioAsync(int id);
    }
}
