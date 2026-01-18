using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;

namespace PlataformaRedencao.Infra.Data.EntitiesConfiguration
{
    public class MembroConfiguration : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.UseTpcMappingStrategy();

            // Nome da tabela
            builder.ToTable("Membros");

            // Chave primária
            builder.HasKey(m => m.Id);

            // ============================
            // Campos herdados de Pessoa
            // ============================

            builder.Property(m => m.DataNascimento)
                   .IsRequired();

            builder.Property(m => m.Sexo)
                   .IsRequired();

            builder.Property(m => m.EstadoCivil);

            builder.Property(m => m.Escolaridade);

            builder.Property(m => m.EnderecoId)
                   .IsRequired();

            builder.Property(m => m.ProfissaoId)
                   .IsRequired();

            // ----------------------------
            // Value Object: NomeCompleto
            // ----------------------------
            builder.OwnsOne(m => m.NomePessoa, nome =>
            {
                nome.Property(n => n.PrimeiroNome)
                    .HasColumnName("Primeiro")
                    .IsRequired()
                    .HasMaxLength(100);

                nome.Property(n => n.SobreNome)
                    .HasColumnName("SobreNome")
                    .IsRequired()
                    .HasMaxLength(150);
            });

            // ----------------------------
            // Value Object: Contato
            // ----------------------------
            builder.OwnsOne(m => m.Contato, contato =>
            {
                contato.Property(c => c.Email)
                       .HasColumnName("Email")
                       .HasMaxLength(150);

                contato.Property(c => c.Telefone)
                       .HasColumnName("Telefone")
                       .HasMaxLength(20);
            });

            // ============================
            // Campos próprios de Membro
            // ============================

            builder.Property(m => m.DataAdmissao)
                   .IsRequired();

            builder.Property(m => m.TipoAdmissao)
                   .IsRequired();

            builder.Property(m => m.Situacao)
                   .IsRequired();

            builder.Property(m => m.Ativo)
                   .IsRequired();

            // ============================
            // Relacionamentos
            // ============================

            builder.HasOne(m => m.Endereco)
                   .WithMany()
                   .HasForeignKey(m => m.EnderecoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Profissao)
                   .WithMany()
                   .HasForeignKey(m => m.ProfissaoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}