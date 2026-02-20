using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Domain.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<IReadOnlyCollection<RefreshToken>> GetActiveTokensByUserAsync(string userId);
        Task<RefreshToken?> GetByHashAsync(string tokenHash);
        Task AddAsync(RefreshToken refreshToken);
        Task SaveChangesAsync();
    }
}