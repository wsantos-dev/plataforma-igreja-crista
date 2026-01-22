using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa um endereço genérico associado a qualquer entidade do domínio,
    /// mantendo histórico de vigência e indicando se é o endereço atual.
    /// </summary>
    /// <remarks>
    /// A entidade <see cref="Endereco"/> pode ser associada a diferentes tipos de entidades,
    /// como Membro, Igreja, Pessoa ou Visitante, utilizando <see cref="TipoEntidade"/>.
    /// Possui controle de vigência, permitindo registrar períodos em que o endereço foi válido.
    /// </remarks>
    public class Endereco : BaseEntity
    {
        /// <summary>
        /// Identificador da entidade dona do endereço.
        /// </summary>
        /// <remarks>
        /// Representa a chave da entidade que possui este endereço.
        /// </remarks>
        public int EntidadeId { get; private set; }

        /// <summary>
        /// Tipo da entidade dona do endereço.
        /// </summary>
        /// <remarks>
        /// Define a classificação da entidade dona do endereço, como Membro, Igreja, Pessoa ou Visitante.
        /// </remarks>
        public TipoEntidadeEndereco TipoEntidade { get; private set; }

        /// <summary>
        /// Logradouro do endereço.
        /// </summary>
        public string? Logradouro { get; private set; }

        /// <summary>
        /// Número do endereço.
        /// </summary>
        public string? Numero { get; private set; }

        /// <summary>
        /// Complemento do endereço.
        /// </summary>
        public string? Complemento { get; private set; }

        /// <summary>
        /// Bairro do endereço.
        /// </summary>
        public string? Bairro { get; private set; }

        /// <summary>
        /// Cidade do endereço.
        /// </summary>
        public string? Cidade { get; private set; }

        /// <summary>
        /// Estado do endereço.
        /// </summary>
        public string? Estado { get; private set; }

        /// <summary>
        /// País do endereço.
        /// </summary>
        public string? Pais { get; private set; }

        /// <summary>
        /// Código postal do endereço.
        /// </summary>
        public string? Cep { get; private set; }

        /// <summary>
        /// Indica se este é o endereço atual do dono.
        /// </summary>
        /// <remarks>
        /// Um endereço atual é considerado válido para uso nos registros da entidade.
        /// </remarks>
        public bool Atual { get; private set; }

        /// <summary>
        /// Data de início da vigência do endereço.
        /// </summary>
        /// <remarks>
        /// Indica quando o endereço passou a ser considerado válido.
        /// </remarks>
        public DateTime? VigenteDesde { get; private set; }

        /// <summary>
        /// Data de término da vigência do endereço.
        /// </summary>
        /// <remarks>
        /// Indica quando o endereço deixou de ser considerado válido.
        /// </remarks>
        public DateTime? VigenteAte { get; private set; }

        /// <summary>
        /// Inicializa um novo endereço associado a uma entidade do domínio.
        /// </summary>
        /// <param name="entidadeId">Identificador da entidade dona do endereço.</param>
        /// <param name="tipoEntidade">Tipo da entidade dona do endereço.</param>
        /// <param name="logradouro">Logradouro do endereço.</param>
        /// <param name="complemento">Complemento do endereço.</param>
        /// <param name="numero">Número do endereço.</param>
        /// <param name="cidade">Cidade do endereço.</param>
        /// <param name="estado">Estado do endereço.</param>
        /// <param name="pais">País do endereço.</param>
        /// <param name="cep">Código postal do endereço.</param>
        public Endereco(
            int entidadeId,
            TipoEntidadeEndereco tipoEntidade,
            string logradouro,
            string complemento,
            string numero,
            string cidade,
            string estado,
            string pais,
            string cep)
        {
            EntidadeId = entidadeId;
            TipoEntidade = tipoEntidade;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Cep = cep;

            Atual = true;
            VigenteDesde = DateTime.UtcNow;
        }

        /// <summary>
        /// Encerra a vigência do endereço, marcando-o como não atual.
        /// </summary>
        /// <remarks>
        /// Define <see cref="Atual"/> como falso e registra a data de término em <see cref="VigenteAte"/>.
        /// </remarks>
        public void EncerrarVigencia()
        {
            Atual = false;
            VigenteAte = DateTime.UtcNow;
        }
    }
}
