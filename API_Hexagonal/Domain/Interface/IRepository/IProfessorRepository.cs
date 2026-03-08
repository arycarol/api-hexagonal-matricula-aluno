using API_Hexagonal.Domain.Entities;

namespace API_Hexagonal.Domain.Interface.IRepository
{
    public interface IProfessorRepository
    {
        public void Create(Professor professor);
        public Professor GetProfessorById(Guid id);
        public List<Professor> GetList();
        public bool Delete(Professor professor);
        public bool Put(Professor professor);
        void CreateMateria(Materia materia);
    }
}
