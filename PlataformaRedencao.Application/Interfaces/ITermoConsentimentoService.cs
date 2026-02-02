using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Serviço para operações relacionadas a termos de consentimento.
    /// </summary>
    public interface ITermoConsentimentoService
    {
        /// <summary>
        /// Obtém todos os termos de consentimento.
        /// </summary>
        Task<IReadOnlyCollection<TermoConsentimentoDTO>> GetTermosAsync();

        /// <summary>
        /// Obtém um termo pelo identificador.
        /// </summary>
        Task<TermoConsentimentoDTO> GetById(int? id);

        /// <summary>
        /// Adiciona um novo termo de consentimento.
        /// </summary>
        Task Add(TermoConsentimentoDTO termoDTO);

        /// <summary>
        /// Atualiza um termo existente.
        /// </summary>
        Task Update(TermoConsentimentoDTO termoDTO);

        /// <summary>
        /// Remove um termo pelo identificador.
        /// </summary>
        Task Remove(int? id);
    }
}