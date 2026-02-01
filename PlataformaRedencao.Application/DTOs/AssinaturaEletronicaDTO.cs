namespace PlataformaRedencao.Application.DTOs
{
    /// <summary>
    /// DTO que representa uma assinatura eletrônica vinculada a um consentimento.
    /// </summary>
    public class AssinaturaEletronicaDTO
    {
        public int Id { get; set; }
        public int ConsentimentoId { get; set; }
        public ConsentimentoDTO? Consentimento { get; set; }
        public ProvedorAssinatura Provedor { get; set; }
        public TipoAssinatura Tipo { get; set; }
        public DateTime DataAssinatura { get; set; }
        public string? HashDocumento { get; set; }
        public string? IdentificadorAssinatura { get; set; }
        public string? Certificado { get; set; }
    }
}