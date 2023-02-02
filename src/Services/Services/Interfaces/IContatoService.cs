using Services.DTO;

namespace Services.Servicies.Interfaces
{
    public interface IContatoService
    {
        Task<List<ContatoDTO>> GetAllAsync();

        Task<List<ContatoDTO>> BuscarContatosPorUsuarioAsync(int id);
        Task<ContatoDTO> CreateAsync(ContatoDTO contatoDTO);

        Task<ContatoDTO> UpdateAsync(ContatoDTO contatoDTO);

        Task<bool> RemoveAsync(int id);

        Task<ContatoDTO> GetAsync(int id);
    }
}
