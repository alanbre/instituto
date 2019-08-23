using Hiring.Domain.Entities;
using Hiring.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Hiring.Infra.Data.Context
{
    public class VagaContext : DbContext
    {
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Desejavel> Desejaveis { get; set; }
        public DbSet<Obrigatorio> Obrigatorios { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("connectionstring");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vaga>(new VagaMap().Configure);
            modelBuilder.Entity<Atividade>(new AtividadeMap().Configure);
            modelBuilder.Entity<Desejavel>(new DesejavelMap().Configure);
            modelBuilder.Entity<Obrigatorio>(new ObrigatorioMap().Configure);
        }
    }
}