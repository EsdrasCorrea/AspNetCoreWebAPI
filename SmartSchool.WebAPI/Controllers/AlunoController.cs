using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;

        public AlunoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllAlunos(true);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repository.GetAlunoById(id, true);
            if (aluno == null) return BadRequest("Aluno não foi encontrado");

            return Ok(aluno);
        }

        // api/aluno/ByName?nome=Marcos&&sobrenome=Paulo
        /* [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não foi encontrado");

            return Ok(aluno);

        }
        */
        // api/aluno    
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repository.Add(aluno);
            if (_repository.SaveChanges())
            {
                return Ok(aluno);                
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repository.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repository.Update(aluno);
            if(_repository.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest ("Aluno não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repository.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _repository.Update(aluno);
            if(_repository.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest ("Aluno não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _repository.Delete(aluno);
            if(_repository.SaveChanges())
            {
                return Ok("Aluno foi excluido");
            }

            return BadRequest("Aluno não foi excluido");
        }

    }
}