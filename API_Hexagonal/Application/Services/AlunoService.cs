using API_Hexagonal.API.DTO;
using API_Hexagonal.Application.IServices;
using API_Hexagonal.Domain.Entities;
using API_Hexagonal.Domain.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API_Hexagonal.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;


        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void Create(CreateAlunoDTO alunoDTO)
        {
            if (alunoDTO == null)
                throw new Exception("Informações do aluno são obrigatórias");

            if (string.IsNullOrWhiteSpace(alunoDTO.FirstName))
                throw new Exception("FirstName não pode ser vazio");

            if (alunoDTO.FirstName.Length > 50)
                throw new Exception("FirstName não pode ter mais de 50 caracteres");

            if (string.IsNullOrWhiteSpace(alunoDTO.Email))
                throw new Exception("Email é obrigatório");

            if (!alunoDTO.Email.EndsWith("@faculdade.edu"))
                throw new Exception("Email deve ser institucional (@faculdade.edu)");

            var alunoExistente = _alunoRepository.GetByEmail(alunoDTO.Email);

            if (alunoExistente != null)
                throw new Exception("Já existe um aluno com este email");

            var novoAluno = new Aluno
            {
                FirstName = alunoDTO.FirstName,
                Email = alunoDTO.Email
            };

            _alunoRepository.Create(novoAluno);
        }

        public Aluno GetAlunoById(Guid id)
        {
            return _alunoRepository.GetAlunoById(id);
        }

        public Aluno GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email é obrigatório");

            var aluno = _alunoRepository.GetByEmail(email);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            return aluno;
        }

        public List<Aluno> GetList()
        {
            return _alunoRepository.GetList();
        }

        public void Delete(Aluno aluno)
        {
            if (aluno == null)
                throw new Exception("Aluno não informado");

            _alunoRepository.Delete(aluno);
        }

        public void PutAluno(Aluno aluno)
        {
            if (aluno == null)
                throw new Exception("Aluno não informado");

            _alunoRepository.PutAluno(aluno);
        }

        public bool Matricular(Guid alunoId, Guid materiaId)
        {
            var aluno = _alunoRepository.GetAlunoById(alunoId);
            if (aluno == null)
                throw new KeyNotFoundException("Aluno não encontrado");

            var materia = _alunoRepository.GetMateriaById(materiaId);
            if (materia == null)
                throw new KeyNotFoundException("Matéria não encontrada");

            if (aluno.Materias.Any(m => m.Id == materiaId))
                return false;

            aluno.Materias.Add(materia);
            _alunoRepository.PutAluno(aluno);

            return true;
        }

        public Materia GetMateriaById(Guid materiaId)
        {
            var materia = _alunoRepository.GetMateriaById(materiaId);

            if (materia == null)
                throw new KeyNotFoundException("Matéria não encontrada");

            return materia;
        }
    }
}