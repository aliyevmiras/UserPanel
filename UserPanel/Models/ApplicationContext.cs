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

        //public override DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// ignore unnecessary columns for user inherited from IdentityUser class
			modelBuilder.Entity<User>().Ignore(x => x.UserName);
			modelBuilder.Entity<User>().Ignore(x => x.NormalizedUserName);
			modelBuilder.Entity<User>().Ignore(x => x.SecurityStamp);
			modelBuilder.Entity<User>().Ignore(x => x.TwoFactorEnabled);
			modelBuilder.Entity<User>().Ignore(x => x.LockoutEnabled);
			modelBuilder.Entity<User>().Ignore(x => x.LockoutEnd);
			modelBuilder.Entity<User>().Ignore(x => x.ConcurrencyStamp);
			modelBuilder.Entity<User>().Ignore(x => x.AccessFailedCount);
			modelBuilder.Entity<User>().Ignore(x => x.EmailConfirmed);
			modelBuilder.Entity<User>().Ignore(x => x.NormalizedEmail);
			modelBuilder.Entity<User>().Ignore(x => x.PasswordHash);
			modelBuilder.Entity<User>().Ignore(x => x.PhoneNumber);
			modelBuilder.Entity<User>().Ignore(x => x.PhoneNumberConfirmed);
		}

	}
}
