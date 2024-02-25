using Microsoft.EntityFrameworkCore;
using EgetAspNetDatabasTest.Models;
namespace EgetAspNetDatabasTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }
    }
}
