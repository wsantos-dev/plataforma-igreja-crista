using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
       {
              public void Configure(EntityTypeBuilder<Profession> builder)
              {
                     builder.ToTable("profession", "members");

                     builder.HasKey(p => p.Id);
                     builder.Property(p => p.Id)
                            .HasColumnName("id");

                     builder.Property(p => p.Name)
                            .HasColumnName("nome")
                            .HasMaxLength(150)
                            .IsRequired();

                     builder.Property(p => p.Code)
                            .HasColumnName("codigo")
                            .HasMaxLength(30);

              }
       }
}
