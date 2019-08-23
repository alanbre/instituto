namespace Hiring.Domain.Entities
{
    public class Desejavel : BaseEntity
    {
        public string Name { get; set; }
        public Vaga Vaga { get; set; }
    }
}
