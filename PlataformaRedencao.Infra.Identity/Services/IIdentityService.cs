using System;

namespace PlataformaRedencao.Infra.Identity.Services;

public interface IIdentityService
{
    Task<IReadOnlyCollection<(string id, string email, string userName)>> GetAllUserAsync();
    Task<(string accessToken, string refreshToken)> RegisterAsync(string email, string password);
    Task<(string accessToken, string refreshToken)> LoginAsync(string email, string password);
}
