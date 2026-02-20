namespace PlataformaRedencao.Domain.Interfaces
{
    /// <summary>
    /// Provides hashing capabilities for sensitive values.
    /// </summary>
    public interface IHashingService
    {
        /// <summary>
        /// Computes the SHA-256 hash of the specified input.
        /// </summary>
        string ComputeSha256(string input);
    }
}
