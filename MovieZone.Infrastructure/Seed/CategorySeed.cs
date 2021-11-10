using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Infrastructure.Seed
{
    public class CategorySeed
    {
        public static async Task Seed(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Categories.Any())
            {
                Category[] categories = {
                new Category { Name = "New"},
                new Category { Name = "Popular" }};

                await applicationDbContext.AddRangeAsync(categories);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
