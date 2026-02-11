using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address", "members");

            // PK
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            // Entidade dona do endereço
            builder.Property(e => e.EntityId)
                .HasColumnName("entity_id")
                .IsRequired();

            builder.Property(e => e.EntityType)
                .HasColumnName("entity_type")
                .HasConversion<int>()
                .IsRequired();

            // Dados do endereço
            builder.Property(e => e.Street)
                .HasColumnName("street")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Number)
                .HasColumnName("number")
                .HasMaxLength(20);

            builder.Property(e => e.Complement)
                .HasColumnName("complement")
                .HasMaxLength(100);

            builder.Property(e => e.Neighborhood)
                .HasColumnName("neighborhood")
                .HasMaxLength(100);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Country)
                .HasColumnName("country")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.PostalCode)
                .HasColumnName("postalcode")
                .HasMaxLength(20)
                .IsRequired();

            // Índices úteis
            builder.HasIndex(e => new { e.EntityId, e.EntityType });
        }
    }
}
