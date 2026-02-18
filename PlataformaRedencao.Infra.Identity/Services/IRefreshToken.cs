using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    /// <summary>
    /// Repository abstraction for managing refresh tokens.
    /// </summary>
    public interface IRefreshTokenRepository
    {
        /// <summary>
        /// Adds a new refresh token.
        /// </summary>
        Task AddAsync(RefreshToken refreshToken);

        /// <summary>
        /// Gets a refresh token by its hash.
        /// </summary>
        Task<RefreshToken?> GetByHashAsync(string tokenHash);

        /// <summary>
        /// Gets all active refresh tokens for a user.
        /// </summary>
        Task<IReadOnlyCollection<RefreshToken>> GetActiveTokensByUserAsync(string userId);

        /// <summary>
        /// Persists changes to the data store.
        /// </summary>
        Task SaveChangesAsync();
    }
}
