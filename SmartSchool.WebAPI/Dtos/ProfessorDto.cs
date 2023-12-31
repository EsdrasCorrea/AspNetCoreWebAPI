using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Dtos
{
    public class ProfessorDto
    {
         public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInit { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<DisciplinaDto> Disciplinas { get; set; }
    }
}