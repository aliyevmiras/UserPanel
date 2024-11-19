using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserPanel.Models
{
	public class ApplicationContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
			//Database.EnsureDeleted();
            Database.EnsureCreated();
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
        }

	}
}
