using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Events;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa a assinatura eletrônica associada a um <see cref="Consentimento"/>,
    /// utilizada como prova jurídica da manifestação de vontade do titular dos dados.
    /// </summary>
    /// <remarks>
    /// A <see cref="AssinaturaEletronica"/> é uma entidade de domínio com identidade
    /// própria, pois:
    /// - Possui valor probatório.
    /// - É emitida por um provedor de identidade ou certificação.
    /// - Está vinculada a um conteúdo específico por meio de hash criptográfico.
    ///
    /// A assinatura garante:
    /// - A identificação do titular.
    /// - A integridade do conteúdo assinado.
    /// - A data e hora do ato de assinatura.
    ///
    /// Uma assinatura eletrônica NÃO deve ser alterada após sua criação.
    /// Qualquer novo aceite exige uma nova assinatura.
    /// </remarks>
    public sealed class AssinaturaEletronica : BaseEntity
    {
        /// <summary>
        /// Consentimento ao qual esta assinatura eletrônica está vinculada.
        /// </summary>
        public Consentimento Consentimento { get; private set; }

        /// <summary>
        /// Chave estrangeira para o consentimento.
        /// </summary>
        public int ConsentimentoId { get; private set; }

        public ProvedorAssinatura Provedor { get; private set; }

        public TipoAssinatura Tipo { get; private set; }

        public DateTime DataAssinatura { get; private set; }

        public string? HashDocumento { get; private set; }

        public string? IdentificadorAssinatura { get; private set; }

        public string? Certificado { get; private set; }

        /// <summary>
        /// Construtor privado para EF Core.
        /// </summary>
        private AssinaturaEletronica() { }

        /// <summary>
        /// Cria uma nova assinatura eletrônica vinculada a um consentimento.
        /// </summary>
        /// <param name="consentimento">Consentimento assinado.</param>
        /// <param name="provedor">Provedor da assinatura.</param>
        /// <param name="tipo">Tipo de assinatura.</param>
        /// <param name="dataAssinatura">Data da assinatura.</param>
        /// <param name="hashDocumento">Hash do documento assinado.</param>
        /// <param name="identificadorAssinatura">Identificador externo da assinatura.</param>
        /// <param name="certificado">Dados do certificado digital.</param>
        public AssinaturaEletronica(
            Consentimento consentimento,
            ProvedorAssinatura provedor,
            TipoAssinatura tipo,
            DateTime dataAssinatura,
            string? hashDocumento = null,
            string? identificadorAssinatura = null,
            string? certificado = null)
        {
            if (consentimento is null)
                throw new ArgumentNullException(nameof(consentimento));

            if (consentimento.DataRevogacao.HasValue)
                throw new InvalidOperationException(
                    "Não é possível assinar um consentimento revogado.");

            Consentimento = consentimento;
            ConsentimentoId = consentimento.Id;
            Provedor = provedor;
            Tipo = tipo;
            DataAssinatura = dataAssinatura;
            HashDocumento = hashDocumento;
            IdentificadorAssinatura = identificadorAssinatura;
            Certificado = certificado;

            AddDomainEvent(new AssinaturaEletronicaCriadaEvent(this));
        }
    }
}
