using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Hexagonal.Domain.Entities;
using API_Hexagonal.Domain.Interface.IRepository;
using API_Hexagonal.Infrastructure.Data;

namespace API_Hexagonal.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext _context;

        public AlunoRepository(DataContext context)
        {
            this._context = context;
        }

        public void Create(Aluno aluno)
        {
            try
            {
                this._context.AlunosTable.Add(aluno);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Delete(Aluno aluno)
        {
            var del = _context.AlunosTable.FirstOrDefault(f => f.Id == aluno.Id);

            if (del == null)
                return false;

            _context.AlunosTable.Remove(del);
            _context.SaveChanges();

            return true;
        }

        public Aluno GetAlunoById(Guid id)
        {
            var aluno = _context.AlunosTable
                .Include(a => a.Materias)          
                .ThenInclude(m => m.Professor)
                .FirstOrDefault(a => a.Id == id);

            return aluno;
        }

        public Aluno GetByEmail(string email)
        {
            Aluno aluno = _context.AlunosTable
                .Where(a => a.Email == email)
                .FirstOrDefault();

            return aluno;
        }

        public List<Aluno> GetList()
        {
            return _context.AlunosTable
                .Include(a => a.Materias)          
                .ThenInclude(m => m.Professor) 
                .ToList();
        }

        public bool PutAluno(Aluno aluno)
        {
            _context.AlunosTable.Update(aluno);
            _context.SaveChanges();
            return true;
        }

        public Materia GetMateriaById(Guid materiaId)
        {
            return _context.MateriaTable.FirstOrDefault(m => m.Id == materiaId);
        }
    }
}
