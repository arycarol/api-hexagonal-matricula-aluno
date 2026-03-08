using API_Hexagonal.Domain.Entities;

namespace API_Hexagonal.Domain.Interface.IRepository
{
    public interface IAlunoRepository
    {
        public void Create(Aluno aluno);
        public Aluno GetAlunoById(Guid id);
        public List<Aluno> GetList();
        public bool Delete(Aluno id);
        public bool PutAluno(Aluno aluno);
        public Aluno GetByEmail(string email);
        Materia GetMateriaById(Guid materiaId);
    }
}
