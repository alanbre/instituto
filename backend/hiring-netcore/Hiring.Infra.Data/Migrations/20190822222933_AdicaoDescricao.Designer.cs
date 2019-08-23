﻿// <auto-generated />
using System;
using Hiring.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hiring.Infra.Data.Migrations
{
    [DbContext(typeof(VagaContext))]
    [Migration("20190822222933_AdicaoDescricao")]
    partial class AdicaoDescricao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hiring.Domain.Entities.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<int?>("VagaId");

                    b.HasKey("Id");

                    b.HasIndex("VagaId");

                    b.ToTable("Atividade");
                });

            modelBuilder.Entity("Hiring.Domain.Entities.Desejavel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<int?>("VagaId");

                    b.HasKey("Id");

                    b.HasIndex("VagaId");

                    b.ToTable("Desejavel");
                });

            modelBuilder.Entity("Hiring.Domain.Entities.Obrigatorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<int?>("VagaId");

                    b.HasKey("Id");

                    b.HasIndex("VagaId");

                    b.ToTable("Obrigatorio");
                });

            modelBuilder.Entity("Hiring.Domain.Entities.Vaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("Codigo");

                    b.Property<string>("Contratacao")
                        .IsRequired()
                        .HasColumnName("Contratacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao");

                    b.Property<string>("Formacao")
                        .IsRequired()
                        .HasColumnName("Formacao");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnName("Localizacao");

                    b.Property<bool>("Nova")
                        .HasColumnName("Nova");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Vaga");
                });

            modelBuilder.Entity("Hiring.Domain.Entities.Atividade", b =>
                {
                    b.HasOne("Hiring.Domain.Entities.Vaga", "Vaga")
                        .WithMany("Atividades")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hiring.Domain.Entities.Desejavel", b =>
                {
                    b.HasOne("Hiring.Domain.Entities.Vaga", "Vaga")
                        .WithMany("Desejaveis")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hiring.Domain.Entities.Obrigatorio", b =>
                {
                    b.HasOne("Hiring.Domain.Entities.Vaga", "Vaga")
                        .WithMany("Obrigatorios")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}