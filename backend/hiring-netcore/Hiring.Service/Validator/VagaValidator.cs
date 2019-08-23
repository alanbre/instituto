using System;
using FluentValidation;
using Hiring.Domain.Entities;

namespace Hiring.Service.Validator
{
    public class VagaValidator : AbstractValidator<Vaga>
    {
        public VagaValidator()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(x => {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(c => c.Codigo)
            .NotEmpty().WithMessage("É necessário informar o código.")
            .NotNull().WithMessage("É necessário informar o código.");

            RuleFor(c => c.Titulo)
                .NotEmpty().WithMessage("É necessário informar o título.")
                .NotNull().WithMessage("É necessário informar o título.");

            RuleFor(c => c.Localizacao)
                .NotEmpty().WithMessage("É necessário informar a localização.")
                .NotNull().WithMessage("É necessário informar a localização.");

            RuleFor(c => c.Formacao)
                .NotEmpty().WithMessage("É necessário informar a formação.")
                .NotNull().WithMessage("É necessário informar a formação.");

            RuleFor(c => c.Atividades)
                .NotEmpty().WithMessage("É necessário informar as atividades")
                .NotNull().WithMessage("É necessário informar as atividades");

            RuleFor(c => c.Desejaveis)
                .NotEmpty().WithMessage("É necessário informar as desejaveis")
                .NotNull().WithMessage("É necessário informar as desejaveis");

            RuleFor(c => c.Obrigatorios)
                .NotEmpty().WithMessage("É necessário informar as obrigatorios")
                .NotNull().WithMessage("É necessário informar as obrigatorios");

            RuleFor(c => c.Contratacao)
                .NotEmpty().WithMessage("É necessário informar a contratação.")
                .NotNull().WithMessage("É necessário informar a contratação.");
        }
    }
}