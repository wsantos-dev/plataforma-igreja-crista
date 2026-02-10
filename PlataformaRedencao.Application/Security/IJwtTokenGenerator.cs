using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Application.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Usuario usuario);
    }
}