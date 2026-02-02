using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Serviço para operações relacionadas a assinaturas eletrônicas.
    /// </summary>
    public interface IAssinaturaEletronicaService
    {
        /// <summary>
        /// Obtém todas as assinaturas eletrônicas.
        /// </summary>
        Task<IReadOnlyCollection<AssinaturaEletronicaDTO>> GetAssinaturasAsync();

        /// <summary>
        /// Obtém uma assinatura pelo identificador.
        /// </summary>
        Task<AssinaturaEletronicaDTO> GetById(int? id);

        /// <summary>
        /// Adiciona uma nova assinatura eletrônica.
        /// </summary>
        Task Add(AssinaturaEletronicaDTO assinaturaDTO);

        /// <summary>
        /// Atualiza uma assinatura eletrônica existente.
        /// </summary>
        Task Update(AssinaturaEletronicaDTO assinaturaDTO);

        /// <summary>
        /// Remove uma assinatura pelo identificador.
        /// </summary>
        Task Remove(int? id);
    }
}