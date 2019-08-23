using System.Collections.Generic;
using System.Linq;
using Hiring.Domain.Entities;
using Hiring.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hiring.Infra.Data.Repository
{
    public class VagaRepository<T>
    {
        private VagaContext context = new VagaContext();

        public void Delete(int id)
        {
            var vaga = context.Vagas.SingleOrDefault(v => v.Id == id);
            context.Vagas.Remove(vaga);
            context.SaveChanges();
        }

        public void Insert(Vaga obj)
        {
            context.Vagas.Add(obj);
            context.SaveChanges();
        }

        public Vaga Select(int id)
        {
            return context.Vagas.Include(vaga => vaga.Atividades).Include(vaga => vaga.Desejaveis).Include(vaga => vaga.Obrigatorios).SingleOrDefault(vaga => vaga.Id == id);
        }

        public IList<Vaga> Select()
        {
            return context.Vagas.Include(vaga => vaga.Atividades).Include(vaga => vaga.Desejaveis).Include(vaga => vaga.Obrigatorios).ToList();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
