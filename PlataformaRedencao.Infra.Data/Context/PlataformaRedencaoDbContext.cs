using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Infra.Identity.Entities;

namespace PlataformaRedencao.Infra.Data.Context
{
    public class PlataformaRedencaoDbContext : IdentityDbContext<ApplicationUser>
    {
        public PlataformaRedencaoDbContext(DbContextOptions<PlataformaRedencaoDbContext> options)
            : base(options)
        { }

        public DbSet<Church> Churches { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Profession> Professions { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("auth");
            
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(PlataformaRedencaoDbContext).Assembly
            );
        }
    }
}