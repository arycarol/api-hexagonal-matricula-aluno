using API_Hexagonal.API.DTO;
using API_Hexagonal.Application.IServices;
using API_Hexagonal.Application.Services;
using API_Hexagonal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Hexagonal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProfessorDTO professorDTO)
        {
            try
            {
                _professorService.Create(professorDTO);
                return Created("", professorDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Professor professor = _professorService.GetProfessorById(id);
            return Ok(professor);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            List<Professor> professores = _professorService.GetList();
            return Ok(professores);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfessor(Guid id)
        {
            var professor = _professorService.GetProfessorById(id);
            if (professor == null)
                return NotFound(new { message = "Professor não encontrado" });

            _professorService.Delete(id);
            return Ok(new { message = "Professor deletado com sucesso" });
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Professor professores)
        {
            try
            {
                _professorService.PutProfessor(professores);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{professorId}/materia")]
        public IActionResult CreateMateria(Guid professorId, [FromBody] CreateMateriaDTO dto)
        {
            try
            {
                Materia materia = new Materia
                {
                    Nome = dto.Nome,
                    Duracao = dto.Duracao
                };

                _professorService.CreateMateria(professorId, materia);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}