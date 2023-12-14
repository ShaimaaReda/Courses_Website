using Microsoft.EntityFrameworkCore;
using courses.Models;
namespace courses.Database
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Course> courses { get; set; }
        public ApplicationDbContext(DbContextOptions option):base(option) 
        {
            
        }
    }
}
