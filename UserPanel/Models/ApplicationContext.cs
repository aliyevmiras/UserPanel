using Microsoft.EntityFrameworkCore;

namespace UserPanel.Models
{
	public class ApplicationContext : DbContext
	{

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

    }
}
