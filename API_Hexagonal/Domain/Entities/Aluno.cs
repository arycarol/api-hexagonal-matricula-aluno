namespace API_Hexagonal.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public ICollection<Materia> Materias { get; set; } = new List<Materia>();


        public Aluno()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
