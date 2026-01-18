using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Infra.Data.EntitiesConfiguration;

namespace PlataformaRedencao.Infra.Data.Context
{
    public class PlataformaRedencaoDbContext : DbContext
    {
        public PlataformaRedencaoDbContext(DbContextOptions<PlataformaRedencaoDbContext> options)
            : base(options)
        { }

        public DbSet<Membro> Membros => Set<Membro>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(PlataformaRedencaoDbContext).Assembly
            );
        }
    }
}