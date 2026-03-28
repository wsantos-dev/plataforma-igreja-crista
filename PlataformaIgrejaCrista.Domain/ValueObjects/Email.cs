using System.Text.RegularExpressions;

namespace PlataformaIgrejaCrista.Domain.ValueObjects
{
    /// <summary>
    /// Value object representing an email address in the domain.
    /// Encapsulates email validation rules so that only valid values can be instantiated.
    /// The email is immutable, has no identity of its own, and equality is defined by the address (case-insensitive).
    /// </summary>
    public sealed class EmailAddress : IEquatable<EmailAddress>
    {
        /// <summary>
        /// Regular expression used for basic email address format validation.
        /// </summary>
        private static readonly Regex EmailRegex = new(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        /// <summary>
        /// Validated and normalized email address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Creates a new instance of <see cref="EmailAddress"/> from the given address.
        /// </summary>
        /// <param name="address">Email address.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the email is null, empty, or invalid.
        /// </exception>
        public EmailAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Email cannot be empty.", nameof(address));

            address = address.Trim();

            if (!EmailRegex.IsMatch(address))
                throw new ArgumentException("Invalid email.", nameof(address));

            Address = address;
        }

        /// <summary>
        /// Implicit conversion from <see cref="EmailAddress"/> to <see cref="string"/>.
        /// Returns the validated email address.
        /// </summary>
        public static implicit operator string(EmailAddress email)
            => email.Address;

        #region Equality

        /// <summary>
        /// Determines whether another <see cref="EmailAddress"/> is equal to this instance (case-insensitive).
        /// </summary>
        /// <param name="other">Another <see cref="EmailAddress"/> instance.</param>
        /// <returns><c>true</c> if the addresses are equivalent; otherwise, <c>false</c>.</returns>
        public bool Equals(EmailAddress? other)
            => other is not null &&
               string.Equals(Address, other.Address, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        public override bool Equals(object? obj)
            => Equals(obj as EmailAddress);

        /// <summary>
        /// Returns the hash code based on the email address (case-insensitive).
        /// </summary>
        public override int GetHashCode()
            => StringComparer.OrdinalIgnoreCase.GetHashCode(Address);

        #endregion

        /// <summary>
        /// Returns the string representation of the email.
        /// </summary>
        /// <returns>Email address.</returns>
        public override string ToString()
            => Address;
    }
}
