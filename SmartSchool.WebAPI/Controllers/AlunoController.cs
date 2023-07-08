using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        
        public AlunoController(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var alunos = await _repository.GetAllAlunosAsync(pageParams, true);
            var alunosResult = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

            Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalCount, alunos.TotalPages);

            return Ok(alunosResult);
        }
        
        
        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repository.GetAlunoById(id, true);
            if (aluno == null) return BadRequest("Aluno não foi encontrado");

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }
        
        
        // api/aluno    
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repository.Add(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não cadastrado");
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não atualizado");
        }

        
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

             _mapper.Map(model, aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não atualizado");
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _repository.Delete(aluno);
            if (_repository.SaveChanges())
            {
                return Ok("Aluno foi excluido");
            }

            return BadRequest("Aluno não foi excluido");
        }

       /*  [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new AlunoRegistrarDto());
        } */

    }
}