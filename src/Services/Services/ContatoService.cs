using AutoMapper;
using Data.Entities;
using Data.Repositories.Interface;
using Services.DTO;
using Services.Servicies.Interfaces;

namespace Services.Servicies
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepositorie _repositorie;
        private readonly IMapper _mapper;

        public ContatoService(IContatoRepositorie repositorie, IMapper mapper)
        {
            _repositorie = repositorie;
            _mapper = mapper;
        }

        public async Task<List<ContatoDTO>> BuscarContatosPorUsuarioAsync(int id)
        {
            var allContatos = await _repositorie.BuscarContatosPorUsuarioAsync(id);

            var contatosDTO = _mapper.Map<List<ContatoDTO>>(allContatos);

            return contatosDTO;
        }

        public async Task<ContatoDTO> CreateAsync(ContatoDTO contatoDTO)
        {

            var contato = _mapper.Map<Contato>(contatoDTO);

            var contatoCriado = await _repositorie.CreateAsync(contato);

            return _mapper.Map<ContatoDTO>(contatoCriado);
        }

        public async Task<List<ContatoDTO>> GetAllAsync()
        {
            var allContatos = await _repositorie.GetAllAsync();

            var contatosDTO = _mapper.Map<List<ContatoDTO>>(allContatos);

            return contatosDTO;
        }

        public async Task<ContatoDTO> GetAsync(int id)
        {
            var entitieExiste = await _repositorie.GetAsync(id);

            if (entitieExiste == null)
            {
                throw new Exception("Não existe nenhum User com o id Informado");
            }

            var entitieDTO = _mapper.Map<ContatoDTO>(entitieExiste);

            return entitieDTO;
        }

        public async Task<bool> RemoveAsync(int id)
        {

            var contato = await _repositorie.GetAsync(id);
            if (contato == null)
            {
                return false;
            }

            await _repositorie.DeleteAsync(id);

            return true;

        }

        public async Task<ContatoDTO> UpdateAsync(ContatoDTO contatoDTO)
        {
            var contato = await _repositorie.GetAsync(contatoDTO.Id);

            if (contato == null)
            {
                throw new Exception("Houve um erro na atualização do contato!");
            }

            contato.Nome = contatoDTO.Nome;
            contato.Email = contatoDTO.Email;
            contato.Celular = contatoDTO.Celular;

            var contatoAtualizado = await _repositorie.UpdateAsync(contato);

            return _mapper.Map<ContatoDTO>(contatoAtualizado);
        }
    }
}
