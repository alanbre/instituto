using System.Collections.Generic;

namespace Hiring.Domain.Entities
{
    public class Vaga : BaseEntity
    {
        public bool Nova { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Localizacao { get; set; }
        public string Descricao { get; set; }
        public string Formacao { get; set; }
        public ICollection<Atividade> Atividades { get; set; }
        public ICollection<Desejavel> Desejaveis { get; set; }
        public ICollection<Obrigatorio> Obrigatorios { get; set; }
        public string Contratacao { get; set; }
    }
}
