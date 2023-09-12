using Aula04.RazorPages.Model;
using Microsoft.EntityFrameworkCore;

namespace Aula04.RazorPages.Data {
    public class AppDbContext : DbContext {
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CursoModel>().ToTable("Cursos").HasKey(c => c.IdCurso);
            modelBuilder.Entity<CursoModel>().Property(c => c.IdCurso).ValueGeneratedOnAdd();
            modelBuilder.Entity<AlunoModel>().ToTable("Alunos").HasKey(a => a.IdAluno);
            modelBuilder.Entity<AlunoModel>().Property(a => a.IdAluno).ValueGeneratedOnAdd();

            modelBuilder.Entity<CursoModel>()
                .HasMany(c => c.Alunos)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "CursoAluno",
                    a => a.HasOne<AlunoModel>().WithMany().HasForeignKey("IdAluno"),
                    c => c.HasOne<CursoModel>().WithMany().HasForeignKey("IdCurso"),
                    ac =>
                    {
                        ac.HasKey("IdCurso", "IdAluno");
                        ac.ToTable("CursoAluno");
                    }
                );
        }
    }
}