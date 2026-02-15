using System;
using PlataformaRedencao.Infra.Identity.Entities;

namespace PlataformaRedencao.Infra.Identity.Services;

public interface ITokenService
{
    string GenerateToken(ApplicationUser user);
}
