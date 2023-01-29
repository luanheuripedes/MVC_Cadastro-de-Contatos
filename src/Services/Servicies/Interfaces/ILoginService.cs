using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicies.Interfaces
{
    public interface ILoginService
    {
        Task<UsuarioDTO> LoginAsync(LoginDTO loginDto);
    }
}
