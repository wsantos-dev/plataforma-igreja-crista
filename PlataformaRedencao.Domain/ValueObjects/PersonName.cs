namespace PlataformaRedencao.Domain.ValueObjects
{
    /// <summary>
    /// Represents the full legal name of a person.
    /// </summary>
    /// <remarks>
    /// <see cref="PersonName"/> is a value object: it has no identity, is immutable after creation, and is compared by value.
    /// It encapsulates first name and last name as in civil registration.
    /// </remarks>
    public sealed class PersonName
    {
        /// <summary>
        /// Legal first name of the person (as in civil registration).
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Last name / family name of the person (as in civil registration).
        /// </summary>
        public string LastName { get; }

        private PersonName() { } // EF Core

        /// <summary>
        /// Creates a new instance of <see cref="PersonName"/>.
        /// </summary>
        /// <param name="firstName">Legal first name.</param>
        /// <param name="lastName">Last name.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when first name or last name are invalid.
        /// </exception>
        public PersonName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("O nome não pode ser .", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.", nameof(lastName));

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }

        /// <summary>
        /// Returns the full name formatted.
        /// </summary>
        public override string ToString()
            => $"{FirstName} {LastName}";

        /// <summary>
        /// Compares two <see cref="PersonName"/> instances by value.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not PersonName other)
                return false;

            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

        /// <summary>
        /// Returns the hash code based on the object values.
        /// </summary>
        public override int GetHashCode()
            => HashCode.Combine(FirstName, LastName);
    }
}
