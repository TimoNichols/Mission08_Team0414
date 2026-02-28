using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0414.Models
{
    public class Mission08_Team0414Context : DbContext
    {
        public Mission08_Team0414Context(DbContextOptions<Mission08_Team0414Context> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}