using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementation of the service for profession-related operations.
    /// </summary>
    public class ProfissaoService : IProfissionService
    {
        private readonly IProfessionRepository _profissaoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="ProfissaoService"/>.
        /// </summary>
        public ProfissaoService(IProfessionRepository profissaoRepository, IMapper mapper)
        {
            _profissaoRepository = profissaoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all professions.
        /// </summary>
        public async Task<IReadOnlyCollection<ProfessionDTO>> GetProfessionsAsync()
        {
            var profissoes = await _profissaoRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<ProfessionDTO>>(profissoes);
        }

        /// <summary>
        /// Gets a profession by id.
        /// </summary>
        public async Task<ProfessionDTO> GetByIdAsync(int? id)
        {
            var profissao = await _profissaoRepository.GetByIdAsync(id);
            return _mapper.Map<ProfessionDTO>(profissao);
        }

        /// <summary>
        /// Adds a new profession.
        /// </summary>
        public async Task AddAsync(ProfessionDTO ProfessionDTO)
        {
            var profissao = _mapper.Map<Profession>(ProfessionDTO);
            await _profissaoRepository.AddAsync(profissao);
        }

        /// <summary>
        /// Updates an existing profession.
        /// </summary>
        public async Task UpdateAsync(ProfessionDTO ProfessionDTO)
        {
            var profissao = _mapper.Map<Profession>(ProfessionDTO);
            await _profissaoRepository.UpdateAsync(profissao);
        }

        /// <summary>
        /// Removes a profession by id.
        /// </summary>
        public async Task RemoveAsync(int? id)
        {
            var profissao = await _profissaoRepository.GetByIdAsync(id);
            if (profissao is null)
                return;

            await _profissaoRepository.DeleteAsync(profissao);
        }
    }
}