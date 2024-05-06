using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UserPanel.Models.Data
{
	public static class SeedData
	{
		public static void EnsurePopulated(IServiceProvider services)
		{
			using(var scope = services.CreateScope())
			{
				ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
				if (!context.Users.Any())
				{
					context.Users.AddRange(
						new User { EmailAddress = "nonexisting1@gmail.com", Password = "123"},
						new User { EmailAddress = "nonexisting2@gmail.com", Password = "123" },
						new User { EmailAddress = "nonexisting3@gmail.com", Password = "123" },
						new User { EmailAddress = "nonexisting4@gmail.com", Password = "123" },
						new User { EmailAddress = "nonexisting5@gmail.com", Password = "123" }
						);
					context.SaveChanges();
				}
			}
			

		}
	}
}
