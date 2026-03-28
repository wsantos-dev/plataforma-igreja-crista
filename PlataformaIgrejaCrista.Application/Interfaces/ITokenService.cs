using PlataformaIgrejaCrista.Domain.Entities;

namespace PlataformaIgrejaCrista.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(ApplicationUser user);
}
