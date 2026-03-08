using API_Hexagonal.API.DTO;
using API_Hexagonal.Application.IServices;
using API_Hexagonal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Hexagonal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAlunoDTO alunoDTO)
        {
            try
            {
                _alunoService.Create(alunoDTO);
                return Created("", alunoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAlunoById(Guid id)
        {
            Aluno aluno = _alunoService.GetAlunoById(id);
            return Ok(aluno);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            List<Aluno> alunos = _alunoService.GetList();
            return Ok(alunos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(Guid id)
        {
            var aluno = _alunoService.GetAlunoById(id);
            if (aluno == null)
                return NotFound(new { message = "Aluno não encontrado" });

            _alunoService.Delete(aluno);
            return Ok(new { message = "Aluno deletado com sucesso" });
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Aluno aluno)
        {
            try
            {
                _alunoService.PutAluno(aluno);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{alunoId}/matricular/{materiaId}")]
        public IActionResult Matricular(Guid alunoId, Guid materiaId)
        {
            try
            {
                var materia = _alunoService.GetMateriaById(materiaId); // método no service
                if (materia == null)
                    return NotFound("Matéria não encontrada");

                bool result = _alunoService.Matricular(alunoId, materiaId);

                if (result)
                    return Ok("Aluno matriculado com sucesso");
                else
                    return BadRequest("Aluno já está matriculado nessa matéria");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}