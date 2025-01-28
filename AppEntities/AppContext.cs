using AppEntities.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppEntities
{
    public class AppContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=Hector; Trusted_Connection=True; MultipleActiveResultSets=true");
        }
    }
}