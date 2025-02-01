using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UserPanel.Models.Data
{
    public static class SeedData
    {
        public async static Task EnsurePopulated(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();


                // Seed roles
                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>("Administrator"));
                    await roleManager.CreateAsync(new IdentityRole<Guid>("User"));
                }

                // Seed users with hashed password
                if (!userManager.Users.Any())
                {
                    var users = new[]
                    {
                        new User { UserName = "admin", Email = "admin@example.com", RegistrationDate = DateTime.UtcNow },
                        new User { UserName = "user1", Email = "user1@example.com", RegistrationDate = DateTime.UtcNow },
                        new User { UserName = "user2", Email = "user2@example.com", RegistrationDate = DateTime.UtcNow }
                    };

                    foreach (var user in users)
                    {
                        var result = await userManager.CreateAsync(user, "defaultPassword123@kz");
                        if (result.Succeeded)
                        {
                            if (user.UserName == "admin")
                            {
                                await userManager.AddToRoleAsync(user, "Administrator");
                            }
                            else
                            {
                                await userManager.AddToRoleAsync(user, "User");
                            }
                        }
                    }

                }


            }
        }
    }
}