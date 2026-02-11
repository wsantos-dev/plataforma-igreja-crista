using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Serviço para operações relacionadas a igrejas.
    /// </summary>
    public interface IChurchService
    {
        /// <summary>
        /// Obtém todas as igrejas.
        /// </summary>
        /// <returns>Uma coleção somente de leitura de <see cref="ChurchDTO"/>.</returns>
        Task<IReadOnlyCollection<ChurchDTO>> GetChurchesAsync();

        /// <summary>
        /// Obtém uma igreja pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da igreja. Pode ser nulo.</param>
        /// <returns>A igreja correspondente ou <c>null</c> se não encontrada.</returns>
        Task<ChurchDTO> GetById(int? id);

        /// <summary>
        /// Adiciona uma nova igreja.
        /// </summary>
        /// <param name="ChurchDTO">Dados da igreja a ser adicionada.</param>
        /// <returns>Uma tarefa assíncrona que representa a operação.</returns>
        Task Add(ChurchDTO ChurchDTO);

        /// <summary>
        /// Atualiza os dados de uma igreja existente.
        /// </summary>
        /// <param name="ChurchDTO">Dados da igreja a ser atualizada.</param>
        /// <returns>Uma tarefa assíncrona que representa a operação.</returns>
        Task Update(ChurchDTO ChurchDTO);

        /// <summary>
        /// Remove uma igreja pelo identificador.
        /// </summary>
        /// <param name="id">Identificador da igreja a ser removida. Pode ser nulo.</param>
        /// <returns>Uma tarefa assíncrona que representa a operação.</returns>
        Task Remove(int? id);
    }
}