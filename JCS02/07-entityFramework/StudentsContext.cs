using Microsoft.EntityFrameworkCore;

namespace cs207
{
    internal class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=studenti");
        }
    }
}
