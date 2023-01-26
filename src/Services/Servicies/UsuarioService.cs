using AutoMapper;
using Data.Entities;
using Data.Repositories.Interface;
using Services.DTO;
using Services.Servicies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicies
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorie _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepositorie usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> CreateAsync(UsuarioDTO usuarioDTO)
        {
            usuarioDTO.DataCadastro = DateTime.Now;

            var entitie = _mapper.Map<Usuario>(usuarioDTO);

            var obj = await _usuarioRepository.CreateAsync(entitie);

            return _mapper.Map<UsuarioDTO>(obj);
        }

        public async Task<List<UsuarioDTO>> GetAllAsync()
        {
            var allUsers = await _usuarioRepository.GetAllAsync();

            var usersDto = _mapper.Map<List<UsuarioDTO>>(allUsers);

            return usersDto;
        }

        public async Task<UsuarioDTO> GetAsync(int id)
        {
            var entitieExiste = await _usuarioRepository.GetAsync(id);

            if (entitieExiste == null)
            {
                throw new Exception("Não existe nenhum Usuario com o id Informado");
            }

            var entitieDTO = _mapper.Map<UsuarioDTO>(entitieExiste);

            return entitieDTO;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var usuario = await _usuarioRepository.GetAsync(id);
            if (usuario == null)
            {
                return false;
            }

            await _usuarioRepository.DeleteAsync(id);

            return true;
        }

        public async Task<UsuarioDTO> UpdateAsync(UsuarioDTO usuarioDTO)
        {
            var usuario = await _usuarioRepository.GetAsync(usuarioDTO.Id);

            if (usuario == null)
            {
                throw new Exception("Houve um erro na atualização do usuario!");
            }

            usuario.Nome = usuarioDTO.Nome;
            usuario.Login = usuarioDTO.Login;
            usuario.Email = usuarioDTO.Email;
            usuario.Perfil = usuarioDTO.Perfil;
            usuario.DataAtualizacao = DateTime.Now;

            await _usuarioRepository.UpdateAsync(usuario);
            
            return _mapper.Map<UsuarioDTO>(usuario);
        }
    }
}
