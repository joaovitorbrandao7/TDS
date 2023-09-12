using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula04.RazorPages.Model{
    public class AlunoModel{
        
        public int? IdAluno { get; set; }
        public string? NomeAluno { get; set; }
        public string? Email { get; set; }
        public DateTime DataInscricao { get; set; }
    }
}