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
        Task<UsuarioDTO> GetAsync(int id);
        Task<UsuarioDTO> UpdateAsync(UsuarioDTO usuarioDTO);
        Task<bool> RemoveAsync(int id);

        Task<UsuarioDTO> AlterarSenhaAsync(AlterarSenhaDTO alterarSenhaDTO);


    }
}
