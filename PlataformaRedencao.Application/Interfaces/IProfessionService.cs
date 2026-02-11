using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Serviço para operações relacionadas a profissões.
    /// </summary>
    public interface IProfissionService
    {
        /// <summary>
        /// Obtém todas as profissões.
        /// </summary>
        Task<IReadOnlyCollection<ProfessionDTO>> GetProfessionsAsync();

        /// <summary>
        /// Obtém uma profissão pelo identificador.
        /// </summary>
        Task<ProfessionDTO> GetById(int? id);

        /// <summary>
        /// Adiciona uma nova profissão.
        /// </summary>
        Task Add(ProfessionDTO ProfessionDTO);

        /// <summary>
        /// Atualiza uma profissão existente.
        /// </summary>
        Task Update(ProfessionDTO ProfessionDTO);

        /// <summary>
        /// Remove uma profissão pelo identificador.
        /// </summary>
        Task Remove(int? id);
    }
}