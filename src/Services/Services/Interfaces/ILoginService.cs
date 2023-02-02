using Services.DTO;

namespace Services.Servicies.Interfaces
{
    public interface ILoginService
    {
        Task<UsuarioDTO> BuscarPorEmailLoginAsync(string login, string email);
        Task<UsuarioDTO> LoginAsync(LoginDTO loginDto);
    }
}
