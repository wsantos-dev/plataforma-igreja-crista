namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// Simple DTO for Profession.
    /// </summary>
    public class ProfessionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Code { get; set; }
    }
}
