using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a assinaturas eletrônicas.
    /// </summary>
    public class AssinaturaEletronicaService : IAssinaturaEletronicaService
    {
        private readonly IAssinaturaEletronicaRepository _assinaturaRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="AssinaturaEletronicaService"/>.
        /// </summary>
        public AssinaturaEletronicaService(IAssinaturaEletronicaRepository assinaturaRepository, IMapper mapper)
        {
            _assinaturaRepository = assinaturaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todas as assinaturas eletrônicas.
        /// </summary>
        public async Task<IReadOnlyCollection<AssinaturaEletronicaDTO>> GetAssinaturasAsync()
        {
            var itens = await _assinaturaRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<AssinaturaEletronicaDTO>>(itens);
        }

        /// <summary>
        /// Obtém uma assinatura pelo identificador.
        /// </summary>
        public async Task<AssinaturaEletronicaDTO> GetById(int? id)
        {
            var item = await _assinaturaRepository.GetByIdAsync(id);
            return _mapper.Map<AssinaturaEletronicaDTO>(item);
        }

        /// <summary>
        /// Adiciona uma nova assinatura eletrônica.
        /// </summary>
        public async Task Add(AssinaturaEletronicaDTO assinaturaDTO)
        {
            var entidade = _mapper.Map<AssinaturaEletronica>(assinaturaDTO);
            await _assinaturaRepository.AddAsync(entidade);
        }

        /// <summary>
        /// Atualiza uma assinatura eletrônica existente.
        /// </summary>
        public async Task Update(AssinaturaEletronicaDTO assinaturaDTO)
        {
            var entidade = _mapper.Map<AssinaturaEletronica>(assinaturaDTO);
            await _assinaturaRepository.UpdateAsync(entidade);
        }

        /// <summary>
        /// Remove uma assinatura pelo identificador.
        /// </summary>
        public async Task Remove(int? id)
        {
            var entidade = await _assinaturaRepository.GetByIdAsync(id);
            if (entidade is null)
                return;

            await _assinaturaRepository.DeleteAsync(entidade);
        }
    }
}