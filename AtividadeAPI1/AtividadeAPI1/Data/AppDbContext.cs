using Microsoft.EntityFrameworkCore;
using AtividadeAPI1.API.Model;

namespace AtividadeAPI1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskModel>? Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        
            => options.UseSqlite("DataSource=tds.db;Cache=Shared");
       
        }
    }

