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
    }
}
