using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieZone.Domain.Models.Auth;
using MovieZone.Infrastructure.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Infrastructure.Extentions
{
    public static class HostExtention
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetService<ApplicationDbContext>();
                    var userManager = services.GetService<UserManager<User>>();
                    var roleManager = services.GetService<RoleManager<Role>>();

                    context.Database.Migrate();

                    await CategorySeed.Seed(context);
                    await CountrySeed.Seed(context);
                    await GenreSeed.Seed(context);
                    await LanguageSeed.Seed(context);
                    await StudioSeed.Seed(context);
                    await UserSeed.Seed(userManager, roleManager);

                }
                catch(Exception exception)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, exception.Message);
                }
            }
        }
    }
}
