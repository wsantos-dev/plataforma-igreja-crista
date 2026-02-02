using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a consentimentos.
    /// </summary>
    public class ConsentimentoService : IConsentimentoService
    {
        private readonly IConsentimentoRepository _consentimentoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ConsentimentoService"/>.
        /// </summary>
        public ConsentimentoService(IConsentimentoRepository consentimentoRepository, IMapper mapper)
        {
            _consentimentoRepository = consentimentoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os consentimentos.
        /// </summary>
        public async Task<IReadOnlyCollection<ConsentimentoDTO>> GetConsentimentosAsync()
        {
            var itens = await _consentimentoRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<ConsentimentoDTO>>(itens);
        }

        /// <summary>
        /// Obtém um consentimento pelo identificador.
        /// </summary>
        public async Task<ConsentimentoDTO> GetById(int? id)
        {
            var item = await _consentimentoRepository.GetByIdAsync(id);
            return _mapper.Map<ConsentimentoDTO>(item);
        }

        /// <summary>
        /// Adiciona um novo consentimento.
        /// </summary>
        public async Task Add(ConsentimentoDTO consentimentoDTO)
        {
            var entidade = _mapper.Map<Consentimento>(consentimentoDTO);
            await _consentimentoRepository.AddAsync(entidade);
        }

        /// <summary>
        /// Atualiza um consentimento existente.
        /// </summary>
        public async Task Update(ConsentimentoDTO consentimentoDTO)
        {
            var entidade = _mapper.Map<Consentimento>(consentimentoDTO);
            await _consentimentoRepository.UpdateAsync(entidade);
        }

        /// <summary>
        /// Remove um consentimento pelo identificador.
        /// </summary>
        public async Task Remove(int? id)
        {
            var entidade = await _consentimentoRepository.GetByIdAsync(id);
            if (entidade is null)
                return;

            await _consentimentoRepository.DeleteAsync(entidade);
        }
    }
}