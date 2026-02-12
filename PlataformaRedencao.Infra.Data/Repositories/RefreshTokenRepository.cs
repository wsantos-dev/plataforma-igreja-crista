using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data.Repositories
{
    /// <summary>
    /// Repository implementation for persistence and handling of <see cref="RefreshToken"/> entities.
    /// Uses <see cref="PlataformaRedencaoDbContext"/> for data access operations related to refresh tokens.
    /// </summary>
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly PlataformaRedencaoDbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="RefreshTokenRepository"/>.
        /// </summary>
        /// <param name="context">DbContext instance used for database access.</param>
        public RefreshTokenRepository(PlataformaRedencaoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new <see cref="RefreshToken"/> to the database.
        /// </summary>
        /// <param name="token">Refresh token entity to persist.</param>
        /// <returns>A <see cref="Task"/> representing the async operation.</returns>
        public async Task AddAsync(RefreshToken token)
        {
            _context.RefreshTokens.Add(token);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a <see cref="RefreshToken"/> by its token value.
        /// </summary>
        /// <param name="token">Token value to look up.</param>
        /// <returns>The <see cref="RefreshToken"/> entity matching the given value.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when no matching token is found.
        /// </exception>
        public async Task<RefreshToken> GetAsync(string token)
        {
            return await _context.RefreshTokens
                .FirstAsync(r => r.Token == token);
        }

        /// <summary>
        /// Revokes an existing <see cref="RefreshToken"/>.
        /// </summary>
        /// <param name="token">Refresh token entity to revoke.</param>
        /// <returns>A <see cref="Task"/> representing the async operation.</returns>
        /// <remarks>Revocation is performed via the entity's <c>Revoke()</c> method, following domain rules.</remarks>
        public async Task RevokeAsync(RefreshToken token)
        {
            token.Revoke();
            await _context.SaveChangesAsync();
        }
    }
}
