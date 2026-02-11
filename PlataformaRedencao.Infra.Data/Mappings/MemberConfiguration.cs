using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.ValueObjects;

namespace PlataformaRedencao.Infra.Data.Mappings;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
       public void Configure(EntityTypeBuilder<Member> builder)
       {
              builder.ToTable("member", "secretary");

              builder.HasKey(m => m.Id);

              builder.Property(m => m.Id)
                  .HasColumnName("id");

              // =============================
              // CPF (Value Object)
              // =============================
              builder.Property(m => m.Cpf)
                  .HasColumnName("cpf")
                  .HasConversion(
                      v => v!.Value,
                      v => new Cpf(v))
                  .HasMaxLength(14)
                  .IsRequired(false);

              // =============================
              // PersonName (Owned Type)
              // =============================
              builder.OwnsOne(m => m.FullName, name =>
              {
                     name.Property(n => n.FirstName)
                   .HasColumnName("first_name")
                   .HasMaxLength(100)
                   .IsRequired();

                     name.Property(n => n.LastName)
                   .HasColumnName("last_name")
                   .HasMaxLength(150)
                   .IsRequired();
              });

              // =============================
              // BirthDate
              // =============================
              builder.Property(m => m.BirthDate)
                  .HasColumnName("birth_date")
                  .HasColumnType("date")
                  .IsRequired();

              // =============================
              // Gender (Enum)
              // =============================
              builder.Property(m => m.Gender)
                  .HasColumnName("gender")
                  .HasConversion<int>()
                  .IsRequired(false);

              // =============================
              // Contact (Owned Type)
              // =============================
              builder.OwnsOne(m => m.Contact, contact =>
              {
                     contact.Property(c => c.EmailAddress)
                   .HasColumnName("email_address")
                   .HasMaxLength(255)
                   .HasConversion(
                       v => v!.Address,
                       v => new EmailAddress(v))
                   .IsRequired();

                     contact.Property(c => c.PhoneNumber)
                   .HasColumnName("phone_number")
                   .HasMaxLength(20)
                   .HasConversion(
                       v => v!.Number,
                       v => new PhoneNumber(v));
              });

              // =============================
              // Enums
              // =============================
              builder.Property(m => m.MaritalStatus)
                  .HasColumnName("marital_status")
                  .HasConversion<int>()
                  .IsRequired();

              builder.Property(m => m.EducationLevel)
                  .HasColumnName("education_level")
                  .HasConversion<int>()
                  .IsRequired();

              builder.Property(m => m.AdmissionType)
                  .HasColumnName("admission_type")
                  .HasConversion<int>()
                  .IsRequired();

              builder.Property(m => m.Status)
                  .HasColumnName("status")
                  .HasConversion<int>()
                  .IsRequired();

              // =============================
              // AdmissionDate
              // =============================
              builder.Property(m => m.AdmissionDate)
                  .HasColumnName("admission_date")
                  .HasColumnType("date")
                  .IsRequired();

              // =============================
              // Foreign Keys
              // =============================

              builder.Property(m => m.AddressId)
                  .HasColumnName("address_id")
                  .IsRequired();

              builder.HasOne(m => m.Address)
                  .WithMany()
                  .HasForeignKey(m => m.AddressId)
                  .OnDelete(DeleteBehavior.Restrict);

              builder.Property(m => m.ProfessionId)
                  .HasColumnName("profession_id")
                  .IsRequired();

              builder.HasOne(m => m.Profession)
                  .WithMany()
                  .HasForeignKey(m => m.ProfessionId)
                  .OnDelete(DeleteBehavior.Restrict);

              builder.Property(m => m.ChurchId)
                  .HasColumnName("church_id")
                  .IsRequired();

              builder.HasOne(m => m.Church)
                  .WithMany()
                  .HasForeignKey(m => m.ChurchId)
                  .OnDelete(DeleteBehavior.Restrict);

              // =============================
              // Auditoria
              // =============================
              builder.Property(m => m.CreatedAt)
                  .HasColumnName("created_at")
                  .HasColumnType("timestamptz")
                  .IsRequired();

              builder.Property(m => m.UpdatedAt)
                  .HasColumnName("updated_at")
                  .HasColumnType("timestamptz");
       }
}
