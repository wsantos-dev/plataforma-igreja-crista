using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a membros.
    /// </summary>
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _membroRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="MemberService"/>.
        /// </summary>
        public MemberService(IMemberRepository membroRepository, IMapper mapper)
        {
            _membroRepository = membroRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os membros.
        /// </summary>
        public async Task<IReadOnlyCollection<MemberDTO>> GetMembersAsync()
        {
            var membros = await _membroRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<MemberDTO>>(membros);
        }

        /// <summary>
        /// Obtém um membro pelo identificador.
        /// </summary>
        public async Task<MemberDTO> GetById(int? id)
        {
            var membro = await _membroRepository.GetByIdAsync(id);
            return _mapper.Map<MemberDTO>(membro);
        }

        /// <summary>
        /// Obtém um membro pelo CPF dentro de uma igreja.
        /// </summary>
        public async Task<MemberDTO> GetByCpfAsync(string cpf, int igrejaId)
        {
            var membro = await _membroRepository.GetByCpfAsync(cpf, igrejaId);
            return _mapper.Map<MemberDTO>(membro);
        }

        /// <summary>
        /// Obtém um membro pelo e-mail dentro de uma igreja.
        /// </summary>
        public async Task<MemberDTO> GetByEmailAsync(string email, int igrejaId)
        {
            var membro = await _membroRepository.GetByEmailAsync(email, igrejaId);
            return _mapper.Map<MemberDTO>(membro);
        }

        /// <summary>
        /// Obtém os membros de uma igreja.
        /// </summary>
        public async Task<IReadOnlyList<MemberDTO>> GetByChurchAsync(int igrejaId)
        {
            var membros = await _membroRepository.GetByChurchAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MemberDTO>>(membros);
        }

        /// <summary>
        /// Obtém membros ativos de uma igreja.
        /// </summary>
        public async Task<IReadOnlyList<MemberDTO>> GetAtivosByIgrejaAsync(int igrejaId)
        {
            var membros = await _membroRepository.GetActivesByChurchAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MemberDTO>>(membros);
        }

        /// <summary>
        /// Obtém membros inativos de uma igreja.
        /// </summary>
        public async Task<IReadOnlyList<MemberDTO>> GetInativosByIgrejaAsync(int igrejaId)
        {
            var membros = await _membroRepository.GetInactivesByChurchAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MemberDTO>>(membros);
        }

        /// <summary>
        /// Adiciona um novo membro.
        /// </summary>
        public async Task Add(MemberDTO MemberDTO)
        {
            var membro = _mapper.Map<Member>(MemberDTO);
            await _membroRepository.AddAsync(membro);
        }

        /// <summary>
        /// Atualiza os dados de um membro existente.
        /// </summary>
        public async Task Update(MemberDTO MemberDTO)
        {
            var membro = _mapper.Map<Member>(MemberDTO);
            await _membroRepository.UpdateAsync(membro);
        }

        /// <summary>
        /// Remove um membro pelo identificador.
        /// </summary>
        public async Task Remove(int? id)
        {
            var membro = await _membroRepository.GetByIdAsync(id);
            if (membro is null)
                return;

            await _membroRepository.DeleteAsync(membro);
        }
    }
}