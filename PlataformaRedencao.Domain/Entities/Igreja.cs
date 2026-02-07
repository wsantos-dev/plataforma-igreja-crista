using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Aggregate Root que representa uma Igreja Evangélica
    /// dentro do domínio da Plataforma Redenção.
    /// </summary>
    /// <remarks>
    /// A entidade <see cref="Igreja"/> concentra os dados oficiais de uma igreja,
    /// incluindo informações civis, contato, liderança e endereço principal.
    /// </remarks>
    public sealed class Igreja : BaseEntity
    {

        /// <summary>
        /// Nome oficial da igreja.
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Nome fantasia ou nome curto utilizado publicamente.
        /// </summary>
        public string NomeFantasia { get; private set; }

        /// <summary>
        /// Denominação à qual a igreja pertence.
        /// </summary>
        public string Denominacao { get; private set; }

        /// <summary>
        /// Pastor presidente ou líder principal da igreja.
        /// </summary>
        public string PastorResponsavel { get; private set; }

        /// <summary>
        /// Data de fundação da igreja.
        /// </summary>
        public DateTime DataFundacao { get; private set; }

        /// <summary>
        /// Número de registro legal da igreja (CNPJ).
        /// </summary>
        public string Cnpj { get; private set; }

        /// <summary>
        /// E-mail institucional da igreja.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Site oficial da igreja.
        /// </summary>
        public string Site { get; private set; }

        /// <summary>
        /// Indica se a igreja está ativa no sistema.
        /// </summary>
        /// <remarks>
        /// Uma igreja inativa não realiza operações no sistema, mas seus registros permanecem.
        /// </remarks>
        public bool Ativa { get; private set; }

        /// <summary>
        /// Data de criação do registro da igreja no sistema.
        /// </summary>
        public DateTime CriadaEm { get; private set; }

        /// <summary>
        /// Data da última atualização do cadastro da igreja.
        /// </summary>
        public DateTime? AtualizadaEm { get; private set; }

        /// <summary>
        /// FK para o endereço principal da igreja.
        /// </summary>
        /// <remarks>
        /// Representa a referência ao endereço principal da igreja, armazenado na entidade <see cref="Endereco"/>.
        /// </remarks>
        public int? EnderecoId { get; private set; }

        /// <summary>
        /// Referência de navegação para o endereço.
        /// </summary>
        public Endereco? Endereco { get; private set; }

        /// <summary>
        /// Cria uma nova instância de igreja com os dados essenciais.
        /// </summary>
        /// <param name="nome">Nome oficial da igreja.</param>
        /// <param name="nomeFantasia">Nome fantasia ou abreviado da igreja.</param>
        /// <param name="denominacao">Denominação religiosa da igreja.</param>
        /// <param name="pastorResponsavel">Pastor presidente ou líder principal.</param>
        /// <param name="dataFundacao">Data de fundação da igreja.</param>
        /// <param name="cnpj">CNPJ da igreja.</param>
        /// <param name="email">E-mail institucional.</param>
        /// <param name="site">Site oficial da igreja.</param>
        public Igreja(
            string nome,
            string nomeFantasia,
            string denominacao,
            string pastorResponsavel,
            DateTime dataFundacao,
            string cnpj,
            string email,
            string site)
        {
            Nome = nome;
            NomeFantasia = nomeFantasia;
            Denominacao = denominacao;
            PastorResponsavel = pastorResponsavel;
            DataFundacao = dataFundacao;
            Cnpj = cnpj;
            Email = email;
            Site = site;

            Ativa = true;
            CriadaEm = DateTime.UtcNow;
        }

        /// <summary>
        /// Altera o endereço principal da igreja, definindo a FK para o endereço existente.
        /// </summary>
        /// <param name="endereco">Endereço existente a ser vinculado como principal.</param>
        /// <remarks>
        /// Atualiza a referência de navegação e a FK <see cref="EnderecoId"/>.
        /// </remarks>
        public void AlterarEndereco(Endereco endereco)
        {
            EnderecoId = endereco.Id;
            Endereco = endereco;
            AtualizadaEm = DateTime.UtcNow;
        }

        /// <summary>
        /// Desativa a igreja no sistema.
        /// </summary>
        /// <remarks>
        /// Uma igreja desativada não realiza operações, mas mantém histórico de registros.
        /// </remarks>
        public void Desativar()
        {
            Ativa = false;
            AtualizadaEm = DateTime.UtcNow;
        }

        /// <summary>
        /// Reativa a igreja no sistema.
        /// </summary>
        /// <remarks>
        /// Uma igreja reativada volta a estar disponível para operações.
        /// </remarks>
        public void Reativar()
        {
            Ativa = true;
            AtualizadaEm = DateTime.UtcNow;
        }
    }
}
