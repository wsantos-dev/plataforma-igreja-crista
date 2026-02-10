using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
       public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
       {
              public void Configure(EntityTypeBuilder<Usuario> builder)
              {
                     builder.ToTable("usuario", "seguranca");

                     builder.HasKey(u => u.Id);

                     builder.Property(i => i.Id)
                            .HasColumnName("id");

                     builder.Property(u => u.Email)
                            .HasColumnName("email")
                            .HasMaxLength(150)
                            .IsRequired();

                     builder.Property(u => u.SenhaHash)
                            .HasColumnName("senha_hash")
                            .HasMaxLength(255)
                            .IsRequired();

                     builder.Property(u => u.IsAtivo)
                            .HasColumnName("ativo")
                            .IsRequired();

                     builder.Property(u => u.CriadoEm)
                            .HasColumnName("criado_em")
                            .HasColumnType("timestamptz")
                            .IsRequired();
              }
       }
}