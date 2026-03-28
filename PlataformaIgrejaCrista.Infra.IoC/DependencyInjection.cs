using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaIgrejaCrista.Application.Interfaces;
using PlataformaIgrejaCrista.Application.Services;
using PlataformaIgrejaCrista.Infra.Data;
using PlataformaIgrejaCrista.Infra.Data.Repositories;
using PlataformaIgrejaCrista.Infra.Data.Services;
using PlataformaIgrejaCrista.Domain.Interfaces;
using PlataformaIgrejaCrista.Application.Mappings;

namespace PlataformaIgrejaCrista.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDataInfrastructure(configuration);

        // Repositories
        services.AddScoped<IChurchRepository, ChurchRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IProfessionRepository, ProfessionRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();


        // AutoMapper
        services.AddAutoMapper(cfg => cfg.AddProfile(typeof(DomainToDTOMappingProfile)));

        // Application services
        services.AddScoped<IChurchService, ChurchService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IProfissionService, ProfessionService>();
        services.AddScoped<IAddressService, AddressService>();

        // Security

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}
