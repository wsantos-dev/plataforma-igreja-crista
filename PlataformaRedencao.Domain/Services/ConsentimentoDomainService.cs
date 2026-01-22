using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Services
{
    /// <summary>
    /// Centraliza regras de negócio relacionadas ao fluxo de consentimento.
    /// </summary>
    public sealed class ConsentimentoDomainService
    {
        public Consentimento ConcederConsentimento(
            Membro membro,
            TermoConsentimento termo,
            TipoConsentimento tipo,
            DateTime dataConcessao)
        {
            return new Consentimento(
                membro,
                termo,
                tipo,
                dataConcessao);
        }

        public AssinaturaEletronica AssinarConsentimento(
            Consentimento consentimento,
            ProvedorAssinatura provedor,
            TipoAssinatura tipo,
            DateTime dataAssinatura,
            string? hashDocumento,
            string? identificador,
            string? certificado)
        {
            return new AssinaturaEletronica(
                consentimento,
                provedor,
                tipo,
                dataAssinatura,
                hashDocumento,
                identificador,
                certificado);
        }
    }
}
