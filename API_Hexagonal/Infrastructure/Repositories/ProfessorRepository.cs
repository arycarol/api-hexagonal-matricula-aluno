using API_Hexagonal.Domain.Entities;
using API_Hexagonal.Domain.Interface.IRepository;
using API_Hexagonal.Infrastructure.Data;

namespace API_Hexagonal.Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly DataContext _context;

        public ProfessorRepository(DataContext context)
        {
            this._context = context;
        }

        public void Create(Professor professor)
        {
            try
            {
                this._context.ProfessorTable.Add(professor);
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateMateria(Materia materia)
        {
            _context.MateriaTable.Add(materia);
            _context.SaveChanges();
        }

        public bool Delete(Professor professor)
        {
            var del = _context.ProfessorTable.FirstOrDefault(f => f.Id == professor.Id);

            if (del == null)
                return false;

            _context.ProfessorTable.Remove(del);
            _context.SaveChanges();

            return true;
        }

        public List<Professor> GetList()
        {
            return _context.ProfessorTable.ToList();
        }

        public Professor GetProfessorById(Guid id)
        {
            Professor professor = this._context.ProfessorTable
                .Select(Professor => Professor)
                .Where(Professor => Professor.Id == id)
                .FirstOrDefault();

            return professor;
        }

        public bool Put(Professor professor)
        {
            _context.ProfessorTable.Update(professor);
            _context.SaveChanges();
            return true;
        }
    }
}
