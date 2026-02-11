using AutoMapper;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;

namespace PlataformaRedencao.Application.Services
{
    /// <summary>
    /// Implementação do serviço para operações relacionadas a igrejas.
    /// </summary>
    public class ChurchService : IChurchService
    {
        private readonly IChurchRepository _churchRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="IChurchService"/>.
        /// </summary>
        /// <param name="igrejaRepository">Repositório de igrejas.</param>
        /// <param name="mapper">Mapeador de objetos.</param>
        public ChurchService(IChurchRepository churchRepository, IMapper mapper)
        {
            _churchRepository = churchRepository;
            _mapper = mapper;

        }

        /// <summary>
        /// Obtém uma igreja pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da igreja. Pode ser nulo.</param>
        /// <returns>Um <see cref="ChurchDTO"/> correspondente ou <c>null</c> se não encontrado.</returns>
        public async Task<ChurchDTO> GetById(int? id)
        {
            var igrejaEntity = await _churchRepository.GetByIdAsync(id);
            return _mapper.Map<ChurchDTO>(igrejaEntity);
        }

        /// <summary>
        /// Obtém todas as igrejas.
        /// </summary>
        /// <returns>Uma coleção somente de leitura de <see cref="ChurchDTO"/>.</returns>
        public async Task<IReadOnlyCollection<ChurchDTO>> GetChurchesAsync()
        {
            var igrejasEntity = await _churchRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<ChurchDTO>>(igrejasEntity);
        }

        /// <summary>
        /// Adiciona uma nova igreja.
        /// </summary>
        /// <param name="ChurchDTO">Dados da igreja a ser adicionada.</param>
        /// <returns>Uma tarefa assíncrona que representa a operação.</returns>
        public async Task Add(ChurchDTO ChurchDTO)
        {
            var igrejaEntity = _mapper.Map<Church>(ChurchDTO);
            await _churchRepository.AddAsync(igrejaEntity);
        }

        /// <summary>
        /// Atualiza os dados de uma igreja existente.
        /// </summary>
        /// <param name="ChurchDTO">Dados da igreja a ser atualizada.</param>
        /// <returns>Uma tarefa assíncrona que representa a operação.</returns>
        public async Task Update(ChurchDTO ChurchDTO)
        {
            var igrejaEntity = _mapper.Map<Church>(ChurchDTO);
            await _churchRepository.UpdateAsync(igrejaEntity);
        }

        /// <summary>
        /// Remove uma igreja pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da igreja a ser removida. Pode ser nulo.</param>
        /// <returns>Uma tarefa assíncrona que representa a operação.</returns>
        public async Task Remove(int? id)
        {
            var igrejaEntity = await _churchRepository.GetByIdAsync(id);
            if (igrejaEntity is null)
                return;

            await _churchRepository.DeleteAsync(igrejaEntity);
        }
    }
}