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
						new User { Email = "nonexisting@gmail.com", Password = "123" },
						new User { Email = "nonexisting2@gmail.com", Password = "123" },
						new User { Email = "nonexisting3@gmail.com", Password = "123" },
						new User { Email = "nonexisting4@gmail.com", Password = "123" },
						new User { Email = "nonexisting5@gmail.com", Password = "123" }
						);
					context.SaveChanges();
				}
			}
			

		}
	}
}
