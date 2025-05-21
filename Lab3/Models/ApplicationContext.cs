using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Users => Set<Student>();
        public ApplicationContext() => Database.EnsureCreated();
        public ApplicationContext(DbContextOptions options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=helloapp.db");
        }
        public DbSet<Lab3.Models.Group> Group { get; set; } = default!;
        public DbSet<Lab3.Models.Hobby> Hobby { get; set; } = default!;
        public DbSet<Lab3.Models.StudentHobby> StudentHobby { get; set; } = default!;
    }
}
