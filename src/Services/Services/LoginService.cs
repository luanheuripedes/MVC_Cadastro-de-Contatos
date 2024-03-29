﻿using AutoMapper;
using Data.Repositories.Interface;
using Services.DTO;
using Services.Servicies.Interfaces;

namespace Services.Servicies
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepositorie _usuarioRepositorie;
        private readonly IMapper _mapper;

        public LoginService(IUsuarioRepositorie usuarioRepositorie, IMapper mapeer)
        {
            _usuarioRepositorie = usuarioRepositorie;
            _mapper = mapeer;
        }

        public async Task<UsuarioDTO> BuscarPorEmailLoginAsync(string login, string email)
        {
            var usuario = await _usuarioRepositorie.BuscarPorEmailLoginAsync(login, email);

            var resultDTO = _mapper.Map<UsuarioDTO>(usuario);

            return resultDTO;
        }

        public async Task<UsuarioDTO> LoginAsync(LoginDTO loginDto)
        {
            var user = await _usuarioRepositorie.BuscarPorLoginSenha(loginDto.Login, loginDto.Senha);

            if (user != null)
            {
                return _mapper.Map<UsuarioDTO>(user);
            }

            return null;

        }
    }
}
