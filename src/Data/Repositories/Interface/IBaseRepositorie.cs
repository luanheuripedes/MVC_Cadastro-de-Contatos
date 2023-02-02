using Domain.Entities;

namespace Infrastructure.Repositories.Interface
{
    public interface IBaseRepositorie<T> where T : Base
    {
        Task<T> CreateAsync(T obj);
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);


    }
}
