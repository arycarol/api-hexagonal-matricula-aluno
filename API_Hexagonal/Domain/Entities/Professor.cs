namespace API_Hexagonal.Domain.Entities
{
    public class Professor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<Materia> Materias { get; set; } = new List<Materia>();

        public Professor()
        {
            this.Id = Guid.NewGuid();
        }
    }
}