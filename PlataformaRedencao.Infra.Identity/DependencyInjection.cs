using System;
using Microsoft.Extensions.DependencyInjection;
using PlataformaRedencao.Infra.Identity.Services;

namespace PlataformaRedencao.Infra.Identity;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }

}
