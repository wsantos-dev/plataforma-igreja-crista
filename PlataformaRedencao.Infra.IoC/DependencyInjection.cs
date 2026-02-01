using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Npgsql.Replication;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;
using PlataformaRedencao.Infra.Data.Repositories;

namespace PlataformaRedencao.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PlataformaRedencaoDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("PostgreSql"),
                p => p.MigrationsAssembly(typeof(PlataformaRedencaoDbContext)
                .Assembly.FullName)));

        services.AddScoped<IIgrejaRepository, IgrejaRepository>();
        services.AddScoped<IMembroRepository, MembroRepository>();
        services.AddScoped<IProfissaoRepository, ProfissaoRepository>();
        services.AddScoped<IConsentimentoRepository, ConsentimentoRepository>();
        services.AddScoped<ITermoConsentimentoRepository, TermoConsentimentoRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        services.AddScoped<IAssinaturaEletronicaRepository, AssinaturaEletronicaRepository>();

        return services;
    }
}
