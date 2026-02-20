using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaRedencao.Domain;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Application.Services;
using PlataformaRedencao.Infra.Data;

using Microsoft.AspNetCore.Identity;
using PlataformaRedencao.Infra.Data.Repositories;
using PlataformaRedencao.Infra.Data.Context;
using PlataformaRedencao.Infra.Data.Security;
using PlataformaRedencao.Infra.Data.Services;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Application.Mappings;

namespace PlataformaRedencao.Infra.IoC;

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
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile).Assembly);

        // Application services
        services.AddScoped<IChurchService, ChurchService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IProfissionService, ProfissaoService>();
        services.AddScoped<IAddressService, AddressService>();

        // Security

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}
