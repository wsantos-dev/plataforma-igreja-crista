using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementation of the service for member-related operations.
    /// </summary>
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _membroRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="MemberService"/>.
        /// </summary>
        public MemberService(IMemberRepository membroRepository, IMapper mapper)
        {
            _membroRepository = membroRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all members.
        /// </summary>
        public async Task<IReadOnlyCollection<MemberDTO>> GetMembersAsync()
        {
            var membros = await _membroRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<MemberDTO>>(membros);
        }

        /// <summary>
        /// Gets a member by id.
        /// </summary>
        public async Task<MemberDTO> GetById(int? id)
        {
            var membro = await _membroRepository.GetByIdAsync(id);
            return _mapper.Map<MemberDTO>(membro);
        }

        /// <summary>
        /// Gets a member by CPF within a church.
        /// </summary>
        public async Task<MemberDTO> GetByCpfAsync(string cpf, int igrejaId)
        {
            var membro = await _membroRepository.GetByCpfAsync(cpf, igrejaId);
            return _mapper.Map<MemberDTO>(membro);
        }

        /// <summary>
        /// Gets a member by email within a church.
        /// </summary>
        public async Task<MemberDTO> GetByEmailAsync(string email, int igrejaId)
        {
            var membro = await _membroRepository.GetByEmailAsync(email, igrejaId);
            return _mapper.Map<MemberDTO>(membro);
        }

        /// <summary>
        /// Gets members of a church.
        /// </summary>
        public async Task<IReadOnlyList<MemberDTO>> GetByChurchAsync(int igrejaId)
        {
            var membros = await _membroRepository.GetByChurchAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MemberDTO>>(membros);
        }

        /// <summary>
        /// Gets active members of a church.
        /// </summary>
        public async Task<IReadOnlyList<MemberDTO>> GetAtivosByIgrejaAsync(int igrejaId)
        {
            var membros = await _membroRepository.GetActivesByChurchAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MemberDTO>>(membros);
        }

        /// <summary>
        /// Gets inactive members of a church.
        /// </summary>
        public async Task<IReadOnlyList<MemberDTO>> GetInativosByIgrejaAsync(int igrejaId)
        {
            var membros = await _membroRepository.GetInactivesByChurchAsync(igrejaId);
            return _mapper.Map<IReadOnlyList<MemberDTO>>(membros);
        }

        /// <summary>
        /// Adds a new member.
        /// </summary>
        public async Task Add(MemberDTO MemberDTO)
        {
            var membro = _mapper.Map<Member>(MemberDTO);
            await _membroRepository.AddAsync(membro);
        }

        /// <summary>
        /// Updates an existing member.
        /// </summary>
        public async Task Update(MemberDTO MemberDTO)
        {
            var membro = _mapper.Map<Member>(MemberDTO);
            await _membroRepository.UpdateAsync(membro);
        }

        /// <summary>
        /// Removes a member by id.
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