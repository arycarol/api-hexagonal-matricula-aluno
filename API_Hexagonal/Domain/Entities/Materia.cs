namespace API_Hexagonal.Domain.Entities
{
    public class Materia
    {
        public Guid Id { get; set; }
        public DateTime DataMatricula { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
        public Guid ProfessorId { get; internal set; }
        public Professor Professor { get; set; }

        public Materia()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
