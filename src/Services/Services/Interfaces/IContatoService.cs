using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicies.Interfaces
{
    public interface IContatoService
    {
        Task<List<ContatoDTO>> GetAllAsync();
        Task<ContatoDTO> CreateAsync(ContatoDTO contatoDTO);

        Task<ContatoDTO> UpdateAsync(ContatoDTO contatoDTO);

        Task<bool> RemoveAsync(int id);

        Task<ContatoDTO> GetAsync(int id);
    }
}
