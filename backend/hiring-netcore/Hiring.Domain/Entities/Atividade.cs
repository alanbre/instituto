namespace Hiring.Domain.Entities
{
    public class Atividade : BaseEntity
    {
        public string Name { get; set; }
        public Vaga Vaga { get; set; }
    }
}
