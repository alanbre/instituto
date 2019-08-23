using System;
using System.Collections.Generic;
using FluentValidation;
using Hiring.Domain.Entities;
using Hiring.Domain.Interfaces;
using Hiring.Infra.Data.Repository;

namespace Hiring.Service.Services
{
    public class VagaService
    {
        private VagaRepository<Vaga> repository = new VagaRepository<Vaga>();

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            repository.Delete(id);
        }

        public Vaga Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return repository.Select(id);
        }

        public IList<Vaga> Get()
        {
            return repository.Select();
        }

        public Vaga Post<V>(Vaga obj) where V : AbstractValidator<Vaga>
        {
            Validate(obj, Activator.CreateInstance<V>());
            repository.Insert(obj);
            return obj;
        }

        public Vaga Put<V>(Vaga obj) where V : AbstractValidator<Vaga>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        private void Validate(Vaga obj, AbstractValidator<Vaga> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
