using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a profissões.
    /// </summary>
    public class ProfissaoService : IProfissionService
    {
        private readonly IProfessionRepository _profissaoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ProfissaoService"/>.
        /// </summary>
        public ProfissaoService(IProfessionRepository profissaoRepository, IMapper mapper)
        {
            _profissaoRepository = profissaoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todas as profissões.
        /// </summary>
        public async Task<IReadOnlyCollection<ProfessionDTO>> GetProfessionsAsync()
        {
            var profissoes = await _profissaoRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<ProfessionDTO>>(profissoes);
        }

        /// <summary>
        /// Obtém uma profissão pelo identificador.
        /// </summary>
        public async Task<ProfessionDTO> GetById(int? id)
        {
            var profissao = await _profissaoRepository.GetByIdAsync(id);
            return _mapper.Map<ProfessionDTO>(profissao);
        }

        /// <summary>
        /// Adiciona uma nova profissão.
        /// </summary>
        public async Task Add(ProfessionDTO ProfessionDTO)
        {
            var profissao = _mapper.Map<Profession>(ProfessionDTO);
            await _profissaoRepository.AddAsync(profissao);
        }

        /// <summary>
        /// Atualiza uma profissão existente.
        /// </summary>
        public async Task Update(ProfessionDTO ProfessionDTO)
        {
            var profissao = _mapper.Map<Profession>(ProfessionDTO);
            await _profissaoRepository.UpdateAsync(profissao);
        }

        /// <summary>
        /// Remove uma profissão pelo identificador.
        /// </summary>
        public async Task Remove(int? id)
        {
            var profissao = await _profissaoRepository.GetByIdAsync(id);
            if (profissao is null)
                return;

            await _profissaoRepository.DeleteAsync(profissao);
        }
    }
}