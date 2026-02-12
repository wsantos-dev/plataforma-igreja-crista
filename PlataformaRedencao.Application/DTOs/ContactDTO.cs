namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO representing contact information (email and phone).
    /// </summary>
    public class ContactDTO
    {
        public string EmailAddress { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }
}