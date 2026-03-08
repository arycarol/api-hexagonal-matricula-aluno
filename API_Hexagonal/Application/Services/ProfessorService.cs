using API_Hexagonal.API.DTO;
using API_Hexagonal.Application.IServices;
using API_Hexagonal.Domain.Entities;
using API_Hexagonal.Domain.Interface.IRepository;

namespace API_Hexagonal.Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public void Create(CreateProfessorDTO professorDTO)
        {
            if (professorDTO == null)
                throw new Exception("Informações do professor são obrigatórias");

            Professor professor = new Professor();
            professor.Nome = professorDTO.Nome;
            professor.Email = professorDTO.Email;

            _professorRepository.Create(professor);
        }

        public bool CreateMateria(Guid professorId, Materia materia)
        {
            if (materia == null)
                throw new Exception("Informações da matéria são obrigatórias");

            var professor = _professorRepository.GetProfessorById(professorId);

            if (professor == null)
                throw new Exception("Professor não encontrado");

            if (string.IsNullOrWhiteSpace(materia.Nome))
                throw new Exception("Nome da matéria é obrigatório");

            if (materia.Duracao <= 0)
                throw new Exception("Duração da matéria deve ser maior que zero");

            materia.DataMatricula = DateTime.Now;

            materia.ProfessorId = professorId;

            _professorRepository.CreateMateria(materia);

            return true;
        }

        public void Delete(Guid id)
        {
            var professor = _professorRepository.GetProfessorById(id);

            if (professor == null)
                throw new Exception("Professor não encontrado");

            _professorRepository.Delete(professor);
        }

        public List<Professor> GetList()
        {
            return _professorRepository.GetList();
        }

        public Professor GetProfessorById(Guid id)
        {
            return _professorRepository.GetProfessorById(id);
        }


        public void PutProfessor(Professor professor)
        {
            if (professor == null)
                throw new Exception("Professor inválido");

            _professorRepository.Put(professor);
        }
    }
}