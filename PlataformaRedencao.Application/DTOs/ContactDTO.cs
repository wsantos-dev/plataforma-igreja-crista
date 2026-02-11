namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO que representa informações de contato (email e telefone).
    /// </summary>
    public class ContactDTO
    {
        public string EmailAddress { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    }
}