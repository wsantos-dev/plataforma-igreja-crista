using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.Events;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa o consentimento explícito concedido por um <see cref="Membro"/>
    /// para o tratamento de seus dados pessoais, com base em um <see cref="TermoConsentimento"/>.
    /// </summary>
    /// <remarks>
    /// O consentimento é uma entidade de domínio com identidade própria,
    /// pois possui ciclo de vida, histórico e relevância jurídica.
    ///
    /// Regras importantes:
    /// - Um consentimento é concedido em um momento específico.
    /// - A revogação não exclui o consentimento, apenas registra sua invalidação.
    /// - Consentimentos não devem ser atualizados, apenas concedidos ou revogados.
    /// - Cada tipo de consentimento pode ser concedido e revogado independentemente.
    /// </remarks>
    public sealed class Consentimento : BaseEntity
    {
        /// <summary>
        /// Membro ao qual o consentimento está vinculado.
        /// </summary>
        /// <remarks>
        /// Representa o titular do consentimento. Não deve ser nulo.
        /// </remarks>
        public Membro Membro { get; private set; }

        /// <summary>
        /// Chave estrangeira para o membro.
        /// </summary>
        public int MembroId { get; private set; }

        /// <summary>
        /// Termo de consentimento utilizado como base legal.
        /// </summary>
        /// <remarks>
        /// O consentimento está sempre vinculado a um termo existente,
        /// garantindo rastreabilidade e validade jurídica.
        /// </remarks>
        public TermoConsentimento TermoConsentimento { get; private set; }

        /// <summary>
        /// Chave estrangeira para o termo de consentimento.
        /// </summary>
        public int TermoConsentimentoId { get; private set; }

        /// <summary>
        /// Tipo do consentimento concedido.
        /// </summary>
        /// <remarks>
        /// Indica a finalidade jurídica do consentimento concedido.
        /// </remarks>
        public TipoConsentimento Tipo { get; private set; }

        /// <summary>
        /// Data e hora em que o consentimento foi concedido.
        /// </summary>
        public DateTime DataConcessao { get; private set; }

        /// <summary>
        /// Data e hora em que o consentimento foi revogado, se aplicável.
        /// </summary>
        public DateTime? DataRevogacao { get; private set; }

        /// <summary>
        /// Construtor privado para EF Core.
        /// </summary>
        private Consentimento() { }

        /// <summary>
        /// Cria um novo consentimento vinculado a um membro e termo.
        /// </summary>
        /// <param name="membro">Membro titular do consentimento.</param>
        /// <param name="termo">Termo utilizado como base legal.</param>
        /// <param name="tipo">Tipo do consentimento.</param>
        /// <param name="dataConcessao">Data em que o consentimento foi concedido.</param>
        public Consentimento(
            Membro membro,
            TermoConsentimento termo,
            TipoConsentimento tipo,
            DateTime dataConcessao)
        {
            if (!termo.EstaVigenteEm(dataConcessao))
                throw new InvalidOperationException(
                    "O termo de consentimento não está vigente na data da concessão.");

            Membro = membro ?? throw new ArgumentNullException(nameof(membro));
            MembroId = membro.Id;

            TermoConsentimento = termo ?? throw new ArgumentNullException(nameof(termo));
            TermoConsentimentoId = termo.Id;

            Tipo = tipo;
            DataConcessao = dataConcessao;

            AddDomainEvent(new ConsentimentoConcedidoEvent(this));
        }

        /// <summary>
        /// Revoga o consentimento.
        /// </summary>
        /// <param name="dataRevogacao">Data em que o consentimento foi revogado.</param>
        public void Revogar(DateTime dataRevogacao)
        {
            if (DataRevogacao.HasValue)
                throw new InvalidOperationException("Consentimento já revogado.");

            if (dataRevogacao < DataConcessao)
                throw new InvalidOperationException(
                    "A revogação não pode ocorrer antes da concessão.");

            DataRevogacao = dataRevogacao;

            AddDomainEvent(new ConsentimentoRevogadoEvent(this));
        }
    }
}
