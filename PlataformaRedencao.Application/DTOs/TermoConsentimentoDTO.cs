namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO que representa um termo de consentimento.
    /// </summary>
    public class TermoConsentimentoDTO
    {
        public int Id { get; set; }
        public TipoConsentimento Tipo { get; set; }
        public string Conteudo { get; set; } = null!;
        public string Versao { get; set; } = null!;
        public DateTime VigenciaInicio { get; set; }
        public DateTime? VigenciaFim { get; set; }
    }
}