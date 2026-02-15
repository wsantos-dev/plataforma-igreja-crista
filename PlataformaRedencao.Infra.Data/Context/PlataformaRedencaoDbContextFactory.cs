using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PlataformaRedencao.Infra.Data.Context
{
    public class PlataformaRedencaoDbContextFactory : IDesignTimeDbContextFactory<PlataformaRedencaoDbContext>
    {
        public PlataformaRedencaoDbContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PlataformaRedencao.API"))
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets<PlataformaRedencaoDbContextFactory>() // Isso busca os segredos
                .Build();

            var builder = new DbContextOptionsBuilder<PlataformaRedencaoDbContext>();
            var connectionString = configuration.GetConnectionString("PostgreSql");

            builder.UseNpgsql(connectionString);

            return new PlataformaRedencaoDbContext(builder.Options);
        }
    }
}