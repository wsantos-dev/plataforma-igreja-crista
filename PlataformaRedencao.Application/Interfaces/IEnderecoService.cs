using PlataformaRedencao.Application.DTOs;

namespace PlataformaRedencao.Application.Interfaces
{
    /// <summary>
    /// Service for address-related operations.
    /// </summary>
    public interface IAddressService
    {
        /// <summary>Gets all addresses.</summary>
        Task<IReadOnlyCollection<AddressDTO>> GetAddressAsync();

        /// <summary>Gets an address by id.</summary>
        Task<AddressDTO> GetById(int? id);

        /// <summary>Adds a new address.</summary>
        Task Add(AddressDTO enderecoDTO);

        /// <summary>Updates an existing address.</summary>
        Task Update(AddressDTO enderecoDTO);

        /// <summary>Removes an address by id.</summary>
        Task Remove(int? id);
    }
}