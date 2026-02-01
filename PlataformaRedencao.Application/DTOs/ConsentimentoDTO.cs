namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO que representa um consentimento concedido por um membro.
    /// </summary>
    public class ConsentimentoDTO
    {
        public int Id { get; set; }
        public int MembroId { get; set; }
        public MembroDTO? Membro { get; set; }
        public int TermoConsentimentoId { get; set; }
        public TermoConsentimentoDTO? TermoConsentimento { get; set; }
        public TipoConsentimento Tipo { get; set; }
        public DateTime DataConcessao { get; set; }
        public DateTime? DataRevogacao { get; set; }
    }
}