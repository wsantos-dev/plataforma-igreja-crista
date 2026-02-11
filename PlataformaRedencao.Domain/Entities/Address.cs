using PlataformaRedencao.Domain.Enums;

namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Representa um endereço genérico associado a qualquer entidade do domínio,
    /// mantendo histórico de vigência e indicando se é o endereço atual.
    /// </summary>
    /// <remarks>
    /// A entidade <see cref="Address"/> pode ser associada a diferentes tipos de entidades,
    /// como Membro, Igreja, Pessoa ou Visitante, utilizando <see cref="EntityAddressType"/>.
    /// Possui controle de vigência, permitindo registrar períodos em que o endereço foi válido.
    /// </remarks>
    public sealed class Address : BaseEntity
    {
        /// <summary>
        /// Identificador da entidade dona do endereço.
        /// </summary>
        /// <remarks>
        /// Representa a chave da entidade que possui este endereço.
        /// </remarks>
        public int EntityId { get; private set; }

        /// <summary>
        /// Tipo da entidade dona do endereço.
        /// </summary>
        /// <remarks>
        /// Define a classificação da entidade dona do endereço, como Membro, Igreja, Pessoa ou Visitante.
        /// </remarks>
        public EntityAddressType EntityType { get; private set; }

        /// <summary>
        /// Logradouro do endereço.
        /// </summary>
        public string? Street { get; private set; }

        /// <summary>
        /// Número do endereço.
        /// </summary>
        public string? Number { get; private set; }

        /// <summary>
        /// Complemento do endereço.
        /// </summary>
        public string? Complement { get; private set; }

        /// <summary>
        /// Bairro do endereço.
        /// </summary>
        public string? Neighborhood { get; private set; }

        /// <summary>
        /// Cidade do endereço.
        /// </summary>
        public string? City { get; private set; }

        /// <summary>
        /// Estado do endereço.
        /// </summary>
        public string? State { get; private set; }

        /// <summary>
        /// País do endereço.
        /// </summary>
        public string? Country { get; private set; }

        /// <summary>
        /// Código postal do endereço.
        /// </summary>
        public string? PostalCode { get; private set; }

        /// <summary>
        /// Inicializa um novo endereço associado a uma entidade do domínio.
        /// </summary>
        /// <param name="entityId">Identificador da entidade dona do endereço.</param>
        /// <param name="entityType">Tipo da entidade dona do endereço.</param>
        /// <param name="street">Logradouro do endereço.</param>
        /// <param name="complement">Complemento do endereço.</param>
        /// <param name="number">Número do endereço.</param>
        /// <param name="city">Cidade do endereço.</param>
        /// <param name="state">Estado do endereço.</param>
        /// <param name="country">País do endereço.</param>
        /// <param name="postalCode">Código postal do endereço.</param>
        public Address(
            int entityId,
            EntityAddressType entityType,
            string street,
            string complement,
            string number,
            string city,
            string state,
            string country,
            string postalCode)
        {
            EntityId = entityId;
            EntityType = entityType;
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
        }
    }
}
