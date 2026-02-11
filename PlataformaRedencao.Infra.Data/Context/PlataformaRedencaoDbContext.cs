using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Context
{
    public class PlataformaRedencaoDbContext : DbContext
    {
        public PlataformaRedencaoDbContext(DbContextOptions<PlataformaRedencaoDbContext> options)
            : base(options)
        { }

        public DbSet<Church> Churches { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(PlataformaRedencaoDbContext).Assembly
            );
        }
    }
}