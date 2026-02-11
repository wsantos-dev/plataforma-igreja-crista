using System;
using PlataformaRedencao.Domain.ValueObjects;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Value Object que representa as informações de contato de uma pessoa.
    /// 
    /// Um contato é composto obrigatoriamente por um e-mail válido e,
    /// opcionalmente, por um telefone.
    /// 
    /// Este objeto é imutável, não possui identidade própria e sua igualdade
    /// é definida exclusivamente pelos valores que o compõem.
    /// </summary>
    public sealed class Contact : IEquatable<Contact>
    {
        /// <summary>
        /// Endereço de e-mail do contato.
        /// 
        /// Este campo é obrigatório e deve representar um e-mail válido
        /// segundo as regras do domínio.
        /// </summary>
        public EmailAddress? EmailAddress { get; }

        /// <summary>
        /// Telefone do contato.
        /// 
        /// Campo opcional, podendo representar telefone fixo ou móvel,
        /// conforme regras definidas no Value Object <see cref="Telefone"/>.
        /// </summary>
        public PhoneNumber? PhoneNumber { get; }

        /// <summary>
        /// Cria uma nova instância de <see cref="Contact"/>.
        /// </summary>
        /// <param name="emailAddress">E-mail do contato (obrigatório).</param>
        /// <param name="phoneNumber">Telefone do contato (opcional).</param>
        /// <exception cref="ArgumentNullException">
        /// Lançada quando o e-mail informado é nulo.
        /// </exception>
        public Contact(EmailAddress? emailAddress, PhoneNumber? phoneNumber = null)
        {
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            PhoneNumber = phoneNumber;
        }

        #region Equality

        /// <summary>
        /// Determina se outro objeto <see cref="Contact"/> é igual ao objeto atual.
        /// 
        /// Dois contatos são considerados iguais quando possuem o mesmo e-mail
        /// e o mesmo telefone (ou ambos sem telefone).
        /// </summary>
        /// <param name="other">Outro objeto <see cref="Contact"/>.</param>
        /// <returns>
        /// <c>true</c> se os valores forem equivalentes; caso contrário, <c>false</c>.
        /// </returns>
        public bool Equals(Contact? other)
        {
            if (other is null) return false;

            return EmailAddress!.Equals(other.EmailAddress) &&
                   Equals(PhoneNumber, other.PhoneNumber);
        }

        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado.</param>
        /// <returns>
        /// <c>true</c> se os objetos forem iguais; caso contrário, <c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
            => Equals(obj as Contact);

        /// <summary>
        /// Retorna o código hash baseado nos valores do contato.
        /// </summary>
        /// <returns>Código hash do objeto.</returns>
        public override int GetHashCode()
            => HashCode.Combine(EmailAddress, PhoneNumber);

        #endregion

        /// <summary>
        /// Retorna a representação textual do contato.
        /// 
        /// Caso o telefone não esteja presente, retorna apenas o e-mail.
        /// Caso contrário, retorna e-mail e telefone concatenados.
        /// </summary>
        /// <returns>Representação textual do contato.</returns>
        public override string ToString()
            => PhoneNumber is null
                ? EmailAddress!.ToString()
                : $"{EmailAddress} | {PhoneNumber}";
    }
}
