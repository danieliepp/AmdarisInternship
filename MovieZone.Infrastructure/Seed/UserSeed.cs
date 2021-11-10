using Microsoft.AspNetCore.Identity;
using MovieZone.Domain.Models.Auth;
using System.Linq;
using System.Threading.Tasks;

namespace MovieZone.Infrastructure.Seed
{
    public class UserSeed
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            
            if (!roleManager.Roles.Any() && !userManager.Users.Any())
            {
                var administrator = new Role()
                {
                    Name = "Administrator"
                };

                var user = new User()
                {
                    UserName = "admin",
                    Email = "admin@moviezone.com",
               /*     AccessFailedCount = 10,
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false*/

                };

                var userResult = await userManager.CreateAsync(user, "IncludeDivide5518");
                var roleResult = await roleManager.CreateAsync(administrator);

                if (roleResult.Succeeded && userResult.Succeeded)
                {
                    var adminUser = await userManager.FindByEmailAsync(user.Email);

                    await userManager.AddToRoleAsync(adminUser, administrator.Name);
                }
            }



            
        }
    }
}
