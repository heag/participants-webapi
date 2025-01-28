using AppManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppManager
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=Hector; Trusted_Connection=True; MultipleActiveResultSets=true");
        }
    }
}