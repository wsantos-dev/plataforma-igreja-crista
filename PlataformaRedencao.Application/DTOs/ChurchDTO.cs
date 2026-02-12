namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO representing a Church for data transfer between layers.
    /// </summary>
    public class ChurchDTO
    {
        public int Id { get; set; }

        public string OfficialName { get; set; } = null!;

        public string TradeName { get; set; } = null!;

        public string? Denomination { get; set; }

        public string LeadPastor { get; set; } = null!;

        public DateOnly FoundationDate { get; set; }

        public string Cnpj { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Website { get; set; } = null!;

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public int? AddressId { get; set; }

        public AddressDTO? Address { get; set; }
    }
}
