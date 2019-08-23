namespace Hiring.Domain.Entities
{
    public class Obrigatorio : BaseEntity
    {
        public string Name { get; set; }
        public Vaga Vaga { get; set; }
    }
}
