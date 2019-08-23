using Hiring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiring.Infra.Data.Mapping
{
    public class VagaMap : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.ToTable("Vaga");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nova)
                    .IsRequired()
                    .HasColumnName("Nova");
            
            builder.Property(c => c.Codigo)
                    .IsRequired()
                    .HasColumnName("Codigo");
                
            builder.Property(c => c.Titulo)
                    .IsRequired()
                    .HasColumnName("Titulo");

            builder.Property(c => c.Localizacao)
                    .IsRequired()
                    .HasColumnName("Localizacao");

            builder.Property(c => c.Descricao)
                    .IsRequired()
                    .HasColumnName("Descricao");

            builder.Property(c => c.Formacao)
                    .IsRequired()
                    .HasColumnName("Formacao");

            builder.Property(c => c.Contratacao)
                    .IsRequired()
                    .HasColumnName("Contratacao");

            builder.HasMany(a => a.Atividades).WithOne(v => v.Vaga).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(d => d.Desejaveis).WithOne(v => v.Vaga).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(o => o.Obrigatorios).WithOne(v => v.Vaga).OnDelete(DeleteBehavior.Cascade);
        }
    }
}