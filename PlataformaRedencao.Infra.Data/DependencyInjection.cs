using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaRedencao.Infra.Data.Context;

namespace PlataformaRedencao.Infra.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataInfrastructure(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddDbContext<PlataformaRedencaoDbContext>(options =>
               options.UseNpgsql(
                   configuration.GetConnectionString("PostgreSql"),
                   p => p.MigrationsAssembly(typeof(PlataformaRedencaoDbContext)
                   .Assembly.FullName)
                )
            .UseSnakeCaseNamingConvention()
        );

        return services;
    }
}
