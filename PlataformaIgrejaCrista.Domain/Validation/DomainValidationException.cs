namespace PlataformaIgrejaCrista.Domain.Validation
{
    /// <summary>
    /// Exception thrown when a domain validation rule is violated.
    /// Used to signal invalid business state or input to the API layer.
    /// </summary>
    public class DomainValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance with the given error message.
        /// </summary>
        /// <param name="error">Validation error message.</param>
        public DomainValidationException(string error) : base(error)
        { }

        /// <summary>
        /// Throws <see cref="DomainValidationException"/> when the condition is true.
        /// </summary>
        /// <param name="condition">When true, the exception is thrown.</param>
        /// <param name="error">Error message to include in the exception.</param>
        public static void When(bool condition, string error)
        {
            if (condition)
                throw new DomainValidationException(error);
        }
    }
}
