using API_Hexagonal.API.DTO;
using API_Hexagonal.Domain.Entities;

namespace API_Hexagonal.Application.IServices
{
    public interface IAlunoService
    {
        public void Create(CreateAlunoDTO Aluno);
        public Aluno GetAlunoById(Guid id);
        public Aluno GetByEmail(string email);
        public List<Aluno> GetList();
        public void Delete(Aluno aluno);
        public void PutAluno(Aluno aluno);
        public bool Matricular(Guid alunoId, Guid materiaId);
        public Materia GetMateriaById(Guid materiaId);


    }
}
