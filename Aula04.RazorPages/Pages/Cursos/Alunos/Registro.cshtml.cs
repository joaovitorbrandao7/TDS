using Aula04.RazorPages.Data;
using Aula04.RazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Pages.Cursos.Alunos
{
    public class Registro : PageModel
    {
        private readonly AppDbContext _context;
        public List<CursoModel>? CursoList { get; set; }
        public List<AlunoModel>? AlunoList { get; set;}

        public Registro(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            CursoList = await _context.Cursos!.ToListAsync();
            AlunoList = await _context.Alunos!.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPost(int curso, int aluno)
        {
            var selectedCurso = await _context.Cursos!.Include(c => c.Alunos).FirstOrDefaultAsync();
            var selectedAluno = await _context.Alunos!.FindAsync(aluno);

            if(selectedCurso == null || selectedAluno == null)
            {
                return NotFound();
            }

            selectedCurso.Alunos!.Add(selectedAluno);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}