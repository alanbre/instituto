using Hiring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiring.Infra.Data.Mapping
{
    public class DesejavelMap : IEntityTypeConfiguration<Desejavel>
    {
        public void Configure(EntityTypeBuilder<Desejavel> builder)
        {
            builder.ToTable("Desejavel");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnName("Name");
        }
    }
}
