using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicies.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO> CreateAsync(UsuarioDTO usuarioDTO);

        //Task<UserDTO> UpdateAsync(UserDTO usuarioDTO);
        //Task Remove(int id);
        //Task<UserDTO> Get(int id);
        
    }
}
