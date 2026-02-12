using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Service for member-related operations.
    /// </summary>
    public interface IMemberService
    {
        /// <summary>Gets all members.</summary>
        /// <returns>A read-only collection of <see cref="MemberDTO"/>.</returns>
        Task<IReadOnlyCollection<MemberDTO>> GetMembersAsync();

        /// <summary>Gets a member by id.</summary>
        /// <param name="id">Member id (nullable).</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        Task<MemberDTO> GetById(int? id);

        /// <summary>Gets a member by CPF within a church.</summary>
        /// <param name="cpf">Member CPF.</param>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        Task<MemberDTO> GetByCpfAsync(string cpf, int igrejaId);

        /// <summary>Gets a member by email within a church.</summary>
        /// <param name="email">Member email.</param>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>The member or <c>null</c> if not found.</returns>
        Task<MemberDTO> GetByEmailAsync(string email, int igrejaId);

        /// <summary>Gets members of a church.</summary>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>List of members linked to the church.</returns>
        Task<IReadOnlyList<MemberDTO>> GetByChurchAsync(int igrejaId);

        /// <summary>Gets active members of a church.</summary>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>List of active members linked to the church.</returns>
        Task<IReadOnlyList<MemberDTO>> GetAtivosByIgrejaAsync(int igrejaId);

        /// <summary>Gets inactive members of a church.</summary>
        /// <param name="igrejaId">Church id.</param>
        /// <returns>List of inactive members linked to the church.</returns>
        Task<IReadOnlyList<MemberDTO>> GetInativosByIgrejaAsync(int igrejaId);

        /// <summary>Adds a new member.</summary>
        /// <param name="MemberDTO">Member data to add.</param>
        Task Add(MemberDTO MemberDTO);

        /// <summary>Updates an existing member.</summary>
        /// <param name="MemberDTO">Member data to update.</param>
        Task Update(MemberDTO MemberDTO);

        /// <summary>Removes a member by id.</summary>
        /// <param name="id">Member id to remove (nullable).</param>
        Task Remove(int? id);
    }
}