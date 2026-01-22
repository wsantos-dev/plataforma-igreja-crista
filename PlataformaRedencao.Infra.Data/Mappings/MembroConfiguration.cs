using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.ValueObjects;

namespace PlataformaRedencao.Infra.Data.EntitiesConfiguration
{
       public class MembroConfiguration : IEntityTypeConfiguration<Membro>
       {
              public void Configure(EntityTypeBuilder<Membro> builder)
              {
                     builder.ToTable("membro", "membros");

                     builder.HasKey(m => m.Id);
                     builder.Property(m => m.Id).HasColumnName("id");

                     builder.Property(m => m.Cpf)
                            .HasColumnName("cpf")
                            .HasConversion(
                                   v => v.Valor,
                                   v => new Cpf(v))
                            .HasMaxLength(14)
                            .IsRequired();

                     builder.Property(m => m.NomePessoa)
                            .HasColumnName("primeiro_nome")
                            .HasConversion(
                                   v => v.PrimeiroNome,
                                   v => new NomePessoa(v, string.Empty))
                            .HasMaxLength(200)
                            .IsRequired();

                     builder.Property(m => m.NomePessoa)
                           .HasColumnName("sobrenome")
                           .HasConversion(
                                  v => v.SobreNome,
                                  v => new NomePessoa(v, string.Empty))
                           .HasMaxLength(200)
                           .IsRequired();

                     builder.Property(m => m.DataNascimento)
                            .HasColumnName("data_nascimento")
                            .IsRequired();

                     builder.Property(m => m.Sexo)
                            .HasColumnName("sexo")
                             .HasConversion(
                                   v => v.Codigo,
                                   v => Sexo.FromCodigo(v))
                            .IsRequired();

                     builder.OwnsOne(m => m.Contato, c =>
                     {
                            c.Property(p => p.Email)
                            .HasColumnName("email")
                            .HasMaxLength(255)
                            .HasConversion(
                                   v => v!.Endereco,
                                   v => new Email(v))

                            .IsRequired();

                            c.Property(p => p.Telefone)
                            .HasColumnName("telefone")
                            .HasConversion(
                                   v => v!.Numero,
                                   v => new Telefone(v))
                            .HasMaxLength(20);
                     });

                     builder.Property(m => m.EstadoCivil)
                            .HasColumnName("estado_civil")
                            .IsRequired();

                     builder.Property(m => m.Escolaridade)
                            .HasColumnName("escolaridade")
                            .IsRequired();

                     builder.Property(m => m.DataAdmissao)
                            .HasColumnName("data_admissao")
                            .IsRequired();

                     builder.Property(m => m.TipoAdmissao)
                            .HasColumnName("tipo_admissao")
                            .IsRequired();

                     builder.Property(m => m.Situacao)
                            .HasColumnName("situacao")
                            .IsRequired();

                     builder.Property(m => m.Ativo)
                            .HasColumnName("ativo")
                            .IsRequired();

                     // Chaves estrangeiras
                     builder.Property(m => m.EnderecoId)
                            .HasColumnName("endereco_id")
                            .IsRequired();

                     builder.HasOne(m => m.Endereco)
                            .WithMany()
                            .HasForeignKey(m => m.EnderecoId)
                            .OnDelete(DeleteBehavior.Restrict);

                     builder.Property(m => m.ProfissaoId)
                            .HasColumnName("profissao_id")
                            .IsRequired();

                     builder.HasOne(m => m.Profissao)
                            .WithMany()
                            .HasForeignKey(m => m.ProfissaoId)
                            .OnDelete(DeleteBehavior.Restrict);

                     builder.Property(m => m.IgrejaId)
                            .HasColumnName("igreja_id")
                            .IsRequired();

                     builder.HasOne(m => m.Igreja)
                            .WithMany() // Se não houver coleção de membros em Igreja, .WithMany() é suficiente
                            .HasForeignKey(m => m.IgrejaId)
                            .OnDelete(DeleteBehavior.Restrict);
              }
       }
}
