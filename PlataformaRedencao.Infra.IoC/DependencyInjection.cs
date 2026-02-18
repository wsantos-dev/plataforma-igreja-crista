using PlataformaRedencao.Infra.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Application.Services;
using PlataformaRedencao.Infra.Data;

using PlataformaRedencao.Infra.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using PlataformaRedencao.Infra.Data.Repositories;
using PlataformaRedencao.Infra.Data.Context;
using PlataformaRedencao.Infra.Data.Security;

namespace PlataformaRedencao.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        // Repositories
        services.AddDataInfrastructure(configuration);

        services.AddScoped<IChurchRepository, ChurchRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IProfessionRepository, ProfessionRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();


        // AutoMapper
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        // Application services
        services.AddScoped<IChurchService, ChurchService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IProfissionService, ProfissaoService>();
        services.AddScoped<IAddressService, AddressService>();

        // Security
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PlataformaRedencaoDbContext>()
                .AddDefaultTokenProviders();

        services.AddIdentityInfrastructure();

        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IHashingService, Sha256HashingService>();

        return services;
    }
}
