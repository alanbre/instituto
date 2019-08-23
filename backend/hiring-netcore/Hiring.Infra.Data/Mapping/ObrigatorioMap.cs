using Hiring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiring.Infra.Data.Mapping
{
    public class ObrigatorioMap : IEntityTypeConfiguration<Obrigatorio>
    {
        public void Configure(EntityTypeBuilder<Obrigatorio> builder)
        {
            builder.ToTable("Obrigatorio");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnName("Name");
        }
    }
}
