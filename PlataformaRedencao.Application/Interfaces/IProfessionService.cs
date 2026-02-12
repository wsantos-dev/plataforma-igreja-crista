using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Service for profession-related operations.
    /// </summary>
    public interface IProfissionService
    {
        /// <summary>Gets all professions.</summary>
        Task<IReadOnlyCollection<ProfessionDTO>> GetProfessionsAsync();

        /// <summary>Gets a profession by id.</summary>
        Task<ProfessionDTO> GetById(int? id);

        /// <summary>Adds a new profession.</summary>
        Task Add(ProfessionDTO ProfessionDTO);

        /// <summary>Updates an existing profession.</summary>
        Task Update(ProfessionDTO ProfessionDTO);

        /// <summary>Removes a profession by id.</summary>
        Task Remove(int? id);
    }
}