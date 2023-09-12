using System.ComponentModel.DataAnnotations;
using Aula04.RazorPages.Model;

namespace Aula04.RazorPages.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Cursos!.Any())
            {
                var cursos = new CursoModel[]
                {
                    new CursoModel
                    {
                        NomeCurso = "Curso de Razor Pages",
                        Descricao = "Como construir um front-end utilizando Razor Pages",
                        DataInicio = DateTime.Parse("2023-11-09"),
                        DataTermino = DateTime.Parse("2023-12-10")
                    },
                };
                context.AddRange(cursos);
            }

            if (!context.Alunos!.Any())
            {
                var alunos = new AlunoModel[]
                {
                    new AlunoModel
                    {
                        NomeAluno = "Maria da Silva",
                        Email = "mariasilva@gmail.com",
                        DataInscricao = DateTime.Now
                    },
                };
                context.AddRange(alunos);
            }
            context.SaveChanges();
        }
    }
}