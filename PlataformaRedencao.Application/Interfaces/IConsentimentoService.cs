using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Serviço para operações relacionadas a consentimentos.
    /// </summary>
    public interface IConsentimentoService
    {
        /// <summary>
        /// Obtém todos os consentimentos.
        /// </summary>
        Task<IReadOnlyCollection<ConsentimentoDTO>> GetConsentimentosAsync();

        /// <summary>
        /// Obtém um consentimento pelo identificador.
        /// </summary>
        Task<ConsentimentoDTO> GetById(int? id);

        /// <summary>
        /// Adiciona um novo consentimento.
        /// </summary>
        Task Add(ConsentimentoDTO consentimentoDTO);

        /// <summary>
        /// Atualiza um consentimento existente.
        /// </summary>
        Task Update(ConsentimentoDTO consentimentoDTO);

        /// <summary>
        /// Remove um consentimento pelo identificador.
        /// </summary>
        Task Remove(int? id);
    }
}