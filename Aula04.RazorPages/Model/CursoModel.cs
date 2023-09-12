using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Aula04.RazorPages.Model{
    public class CursoModel{
       
        public int? IdCurso { get; set; }
        public string? NomeCurso { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataInicio {get; set; }    
        public DateTime? DataTermino { get; set; }


        public List<AlunoModel>? Alunos { get; set; }
    }
}