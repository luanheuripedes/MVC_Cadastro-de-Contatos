using Data.Entities;
using Infrastructure.Repositories.Interface;

namespace Data.Repositories.Interface
{
    public interface IContatoRepositorie : IBaseRepositorie<Contato>
    {
        Task<List<Contato>> BuscarContatosPorUsuarioAsync(int id);
    }
}
