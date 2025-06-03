using Microsoft.EntityFrameworkCore;
using student2.Models.Entities;

namespace student2.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Parent> Parents { get; set; }
    }
}
