using API_Hexagonal.API.DTO;
using API_Hexagonal.Domain.Entities;

namespace API_Hexagonal.Application.IServices
{
    public interface IProfessorService
    {
        public void Create(CreateProfessorDTO Professor);
        public Professor GetProfessorById(Guid id);
        public List<Professor> GetList();
        public void Delete(Guid id);
        public void PutProfessor(Professor professor);
        public bool CreateMateria(Guid professorId,Materia materia);
    }
}
