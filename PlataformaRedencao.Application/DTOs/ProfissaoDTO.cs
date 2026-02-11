namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO simples para Profession.
    /// </summary>
    public class ProfessionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Code { get; set; }
    }
}
