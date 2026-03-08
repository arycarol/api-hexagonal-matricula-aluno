using API_Hexagonal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Hexagonal.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        }

        public DbSet<Aluno> AlunosTable { get; private set; }
        public DbSet<Materia> MateriaTable { get; private set; }
        public DbSet<Professor> ProfessorTable { get; private set; }


    }
}
