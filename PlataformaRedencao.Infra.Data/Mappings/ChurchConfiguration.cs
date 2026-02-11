using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.Mappings;

public class ChurchConfiguration : IEntityTypeConfiguration<Church>
{
    public void Configure(EntityTypeBuilder<Church> builder)
    {
        builder.ToTable("church", "public");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.OfficialName)
            .HasColumnName("official_name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.TradeName)
            .HasColumnName("trade_name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.Denomination)
            .HasColumnName("denomination")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(c => c.LeadPastor)
            .HasColumnName("lead_pastor")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.FoundationDate)
            .HasColumnName("foundation_date")
            .IsRequired();

        builder.Property(c => c.Cnpj)
            .HasColumnName("cnpj")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.Website)
            .HasColumnName("website")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamptz");

        // FK Address (nullable conforme entidade)
        builder.Property(c => c.AddressId)
            .HasColumnName("address_id")
            .IsRequired(false);

        builder.HasOne(c => c.Address)
            .WithMany()
            .HasForeignKey(c => c.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
