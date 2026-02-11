using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO para representar endereços.
    /// </summary>
    public class AddressDTO
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public EntityAddressType EntityType { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
    }
}