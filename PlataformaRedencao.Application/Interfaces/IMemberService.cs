using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Serviço para operações relacionadas a membros.
    /// </summary>
    public interface IMemberService
    {
        /// <summary>
        /// Obtém todos os membros.
        /// </summary>
        /// <returns>Uma coleção somente de leitura de <see cref="MemberDTO"/>.</returns>
        Task<IReadOnlyCollection<MemberDTO>> GetMembersAsync();

        /// <summary>
        /// Obtém um membro pelo identificador.
        /// </summary>
        /// <param name="id">Identificador do membro. Pode ser nulo.</param>
        /// <returns>O membro correspondente ou <c>null</c> se não encontrado.</returns>
        Task<MemberDTO> GetById(int? id);

        /// <summary>
        /// Obtém um membro pelo CPF dentro de uma igreja.
        /// </summary>
        /// <param name="cpf">CPF do membro.</param>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>O membro correspondente ou <c>null</c> se não encontrado.</returns>
        Task<MemberDTO> GetByCpfAsync(string cpf, int igrejaId);

        /// <summary>
        /// Obtém um membro pelo e-mail dentro de uma igreja.
        /// </summary>
        /// <param name="email">E-mail do membro.</param>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>O membro correspondente ou <c>null</c> se não encontrado.</returns>
        Task<MemberDTO> GetByEmailAsync(string email, int igrejaId);

        /// <summary>
        /// Obtém os membros de uma igreja.
        /// </summary>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>Lista de membros vinculados à igreja.</returns>
        Task<IReadOnlyList<MemberDTO>> GetByChurchAsync(int igrejaId);

        /// <summary>
        /// Obtém os membros ativos de uma igreja.
        /// </summary>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>Lista de membros ativos vinculados à igreja.</returns>
        Task<IReadOnlyList<MemberDTO>> GetAtivosByIgrejaAsync(int igrejaId);

        /// <summary>
        /// Obtém os membros inativos de uma igreja.
        /// </summary>
        /// <param name="igrejaId">Identificador da igreja.</param>
        /// <returns>Lista de membros inativos vinculados à igreja.</returns>
        Task<IReadOnlyList<MemberDTO>> GetInativosByIgrejaAsync(int igrejaId);

        /// <summary>
        /// Adiciona um novo membro.
        /// </summary>
        /// <param name="MemberDTO">Dados do membro a ser adicionado.</param>
        Task Add(MemberDTO MemberDTO);

        /// <summary>
        /// Atualiza os dados de um membro existente.
        /// </summary>
        /// <param name="MemberDTO">Dados do membro a ser atualizado.</param>
        Task Update(MemberDTO MemberDTO);

        /// <summary>
        /// Remove um membro pelo identificador.
        /// </summary>
        /// <param name="id">Identificador do membro a ser removido. Pode ser nulo.</param>
        Task Remove(int? id);
    }
}