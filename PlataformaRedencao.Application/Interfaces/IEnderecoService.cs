using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Serviço para operações relacionadas a endereços.
    /// </summary>
    public interface IAddressService
    {
        /// <summary>
        /// Obtém todos os endereços.
        /// </summary>
        Task<IReadOnlyCollection<AddressDTO>> GetAddressAsync();

        /// <summary>
        /// Obtém um endereço pelo identificador.
        /// </summary>
        Task<AddressDTO> GetById(int? id);

        /// <summary>
        /// Adiciona um novo endereço.
        /// </summary>
        Task Add(AddressDTO enderecoDTO);

        /// <summary>
        /// Atualiza um endereço existente.
        /// </summary>
        Task Update(AddressDTO enderecoDTO);

        /// <summary>
        /// Remove um endereço pelo identificador.
        /// </summary>
        Task Remove(int? id);
    }
}