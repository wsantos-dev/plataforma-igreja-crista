using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Aggregate Root que representa uma Igreja Evangélica
    /// dentro do domínio da Plataforma Redenção.
    /// </summary>
    /// <remarks>
    /// A entidade <see cref="Church"/> concentra os dados oficiais de uma igreja,
    /// incluindo informações civis, contato, liderança e endereço principal.
    /// </remarks>
    public sealed class Church : BaseEntity
    {
        /// <summary>
        /// Nome oficial da igreja.
        /// </summary>
        public string OfficialName { get; private set; }

        /// <summary>
        /// Nome fantasia ou nome curto utilizado publicamente.
        /// </summary>
        public string TradeName { get; private set; }

        /// <summary>
        /// Denominação à qual a igreja pertence.
        /// </summary>
        public string? Denomination { get; private set; }

        /// <summary>
        /// Pastor presidente ou líder principal da igreja.
        /// </summary>
        public string LeadPastor { get; private set; }

        /// <summary>
        /// Data de fundação da igreja.
        /// </summary>
        public DateOnly FoundationDate { get; private set; }

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
        public string Website { get; private set; }

        /// <summary>
        /// Data de criação do registro da igreja no sistema.
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Data da última atualização do cadastro da igreja.
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; private set; }

        /// <summary>
        /// FK para o endereço principal da igreja.
        /// </summary>
        /// <remarks>
        /// Representa a referência ao endereço principal da igreja, armazenado na entidade <see cref="Address"/>.
        /// </remarks>
        public int? AddressId { get; private set; }

        /// <summary>
        /// Referência de navegação para o endereço.
        /// </summary>
        public Address? Address { get; private set; }

        /// <summary>
        /// Cria uma nova instância de igreja com os dados essenciais.
        /// </summary>
        /// <param name="officialName">Nome oficial da igreja.</param>
        /// <param name="tradeName">Nome fantasia ou abreviado da igreja.</param>
        /// <param name="denomination">Denominação religiosa da igreja.</param>
        /// <param name="leadPastor">Pastor presidente ou líder principal.</param>
        /// <param name="foundationDate">Data de fundação da igreja.</param>
        /// <param name="cnpj">CNPJ da igreja.</param>
        /// <param name="email">E-mail institucional.</param>
        /// <param name="website">Site oficial da igreja.</param>
        public Church(
            string officialName,
            string tradeName,
            string denomination,
            string leadPastor,
            DateOnly foundationDate,
            string cnpj,
            string email,
            string website)
        {
            OfficialName = officialName;
            TradeName = tradeName;
            Denomination = denomination;
            LeadPastor = leadPastor;
            FoundationDate = foundationDate;
            Cnpj = cnpj;
            Email = email;
            Website = website;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Altera o endereço principal da igreja, definindo a FK para o endereço existente.
        /// </summary>
        /// <param name="address">Endereço existente a ser vinculado como principal.</param>
        /// <remarks>
        /// Atualiza a referência de navegação e a FK <see cref="AddressId"/>.
        /// </remarks>
        public void ChangeAddress(Address address)
        {
            AddressId = address.Id;
            Address = address;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
