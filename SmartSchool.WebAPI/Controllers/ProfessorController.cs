using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProfessorController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repository.GetProfessorById(id, true);
            if (professor == null) return BadRequest("Professor não encontrado");

            return Ok(professor);
        }

        //api/professor/ByName?nome=Marcos&&sobrenome=Paulo
        /* [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if (professor == null) return BadRequest("Professor não encontrado");

            return Ok(professor);
        } */

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
           _repository.Add(professor);
           if(_repository.SaveChanges())
           {
                return Ok(professor);
           }

           return BadRequest("Professor não cadastrado");
        }

        [HttpPut]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repository.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");

            _repository.Update(professor);
            if(_repository.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest ("Professor não atualizado");
            
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repository.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");

            _repository.Update(professor);
            if(_repository.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest ("Professor não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repository.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor não encontrado");

            _repository.Update(prof);
            if(_repository.SaveChanges())
            {
                return Ok("Professor foi excluido com sucesso");
            }

            return BadRequest ("Professor não pode ser excluido");
        }
    }
}