namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Represents a profession held by a person.
    /// </summary>
    /// <remarks>
    /// Used as a reference to classify a person's occupation. Some professions have special meaning in the domain, such as the default "Not informed".
    /// </remarks>
    public sealed class Profession : BaseEntity
    {
        /// <summary>
        /// Code used to represent "not informed" profession.
        /// </summary>
        public const string NotInformedCode = "0000";

        /// <summary>
        /// Profession name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Official profession code (e.g. CBO).
        /// </summary>
        public string? Code { get; private set; }

        public Profession(int id, string name, string? code = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Profession name cannot be empty.",
                    nameof(name));

            Id = id;
            Name = name.Trim();
            Code = string.IsNullOrWhiteSpace(code) ? null : code.Trim();
        }

        /// <summary>
        /// Indicates whether this profession represents the default "not informed" value.
        /// </summary>
        public bool IsNotInformed()
            => Code == NotInformedCode;

        /// <summary>
        /// Creates the default "not informed" profession instance.
        /// </summary>
        /// <remarks>Should be used only for initial seed or controlled initialization scenarios.</remarks>
        public static Profession CreateNotInformed()
        {
            const int DefaultId = 999;
            return new Profession(DefaultId, "Not informed", NotInformedCode);
        }
    }
}
