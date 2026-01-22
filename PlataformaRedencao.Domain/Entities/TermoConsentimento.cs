using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa o termo oficial de consentimento que define, de forma explícita,
    /// clara e inequívoca, as condições para o tratamento de dados pessoais,
    /// conforme a legislação vigente (ex.: LGPD).
    /// </summary>
    /// <remarks>
    /// O <see cref="TermoConsentimento"/> é uma entidade de domínio com identidade
    /// própria, pois:
    /// - Possui versionamento controlado.
    /// - Pode ter vigência temporal.
    /// - Serve como base jurídica para a concessão de consentimentos.
    ///
    /// O conteúdo deste termo NÃO deve ser alterado após sua publicação.
    /// Qualquer modificação exige a criação de uma nova versão.
    /// </remarks>
    public sealed class TermoConsentimento : BaseEntity
    {
        /// <summary>
        /// Tipo de consentimento ao qual este termo está associado.
        /// </summary>
        /// <remarks>
        /// Define a finalidade jurídica do termo, como uso de dados pessoais,
        /// compartilhamento com terceiros, comunicação institucional ou
        /// processamento para fins legais.
        /// </remarks>
        public TipoConsentimento Tipo { get; private set; }

        /// <summary>
        /// Conteúdo integral do termo de consentimento.
        /// </summary>
        /// <remarks>
        /// Deve conter o texto completo apresentado ao titular dos dados no momento
        /// da concessão do consentimento.
        /// Este conteúdo é utilizado para:
        /// - Exibição ao usuário
        /// - Geração de hash criptográfico
        /// - Validação da assinatura eletrônica
        /// O texto deve ser armazenado exatamente como foi apresentado,
        /// sem alterações posteriores.
        /// </remarks>
        public string Conteudo { get; private set; }

        /// <summary>
        /// Versão identificadora do termo de consentimento.
        /// </summary>
        /// <remarks>
        /// Permite o controle evolutivo do termo.
        /// Exemplos de versionamento: "1.0", "1.1", "2.0".
        /// A versão é fundamental para auditoria, rastreabilidade e comprovação
        /// jurídica do consentimento concedido.
        /// </remarks>
        public string Versao { get; private set; }

        /// <summary>
        /// Data e hora a partir da qual o termo de consentimento passa a ser válido.
        /// </summary>
        /// <remarks>
        /// Indica o início da vigência jurídica do termo.
        /// Um termo só pode ser utilizado para concessão de consentimento se
        /// estiver vigente na data da assinatura.
        /// Termos com vigência futura não devem ser apresentados ao usuário.
        /// </remarks>
        public DateTime VigenciaInicio { get; private set; }

        /// <summary>
        /// Data e hora em que o termo deixa de ser válido, se aplicável.
        /// </summary>
        /// <remarks>
        /// Permite registrar fim da vigência de um termo sem removê-lo do histórico.
        /// </remarks>
        public DateTime? VigenciaFim { get; private set; }

        /// <summary>
        /// Construtor privado para EF Core.
        /// </summary>
        private TermoConsentimento() { }

        /// <summary>
        /// Cria um novo termo de consentimento.
        /// </summary>
        /// <param name="tipo">Tipo do consentimento.</param>
        /// <param name="conteudo">Conteúdo textual do termo.</param>
        /// <param name="versao">Versão do termo.</param>
        /// <param name="vigenciaInicio">Data de início da vigência.</param>
        public TermoConsentimento(TipoConsentimento tipo, string conteudo, string versao, DateTime vigenciaInicio)
        {
            Tipo = tipo;
            Conteudo = conteudo ?? throw new ArgumentNullException(nameof(conteudo));
            Versao = versao ?? throw new ArgumentNullException(nameof(versao));
            VigenciaInicio = vigenciaInicio;
        }

        public bool EstaVigenteEm(DateTime data)
        {
            if (data < VigenciaInicio)
                return false;

            if (VigenciaFim.HasValue && data > VigenciaFim.Value)
                return false;

            return true;
        }
    }
}
