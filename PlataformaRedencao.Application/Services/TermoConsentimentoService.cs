using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a termos de consentimento.
    /// </summary>
    public class TermoConsentimentoService : ITermoConsentimentoService
    {
        private readonly ITermoConsentimentoRepository _termoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="TermoConsentimentoService"/>.
        /// </summary>
        public TermoConsentimentoService(ITermoConsentimentoRepository termoRepository, IMapper mapper)
        {
            _termoRepository = termoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os termos de consentimento.
        /// </summary>
        public async Task<IReadOnlyCollection<TermoConsentimentoDTO>> GetTermosAsync()
        {
            var itens = await _termoRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<TermoConsentimentoDTO>>(itens);
        }

        /// <summary>
        /// Obtém um termo pelo identificador.
        /// </summary>
        public async Task<TermoConsentimentoDTO> GetById(int? id)
        {
            var item = await _termoRepository.GetByIdAsync(id);
            return _mapper.Map<TermoConsentimentoDTO>(item);
        }

        /// <summary>
        /// Adiciona um novo termo de consentimento.
        /// </summary>
        public async Task Add(TermoConsentimentoDTO termoDTO)
        {
            var entidade = _mapper.Map<TermoConsentimento>(termoDTO);
            await _termoRepository.AddAsync(entidade);
        }

        /// <summary>
        /// Atualiza um termo existente.
        /// </summary>
        public async Task Update(TermoConsentimentoDTO termoDTO)
        {
            var entidade = _mapper.Map<TermoConsentimento>(termoDTO);
            await _termoRepository.UpdateAsync(entidade);
        }

        /// <summary>
        /// Remove um termo pelo identificador.
        /// </summary>
        public async Task Remove(int? id)
        {
            var entidade = await _termoRepository.GetByIdAsync(id);
            if (entidade is null)
                return;

            await _termoRepository.DeleteAsync(entidade);
        }
    }
}