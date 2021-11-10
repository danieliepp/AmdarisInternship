using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Infrastructure.Seed
{
    public class StudioSeed
    {
        public static async Task Seed(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Studios.Any())
            {
                Studio[] studios =  {
                new Studio { Name = "Universal Pictures" },
                new Studio { Name = "Warner Bros." },
                new Studio { Name = "Columbia Pictures" },
                new Studio { Name = "Walt Disney Pictures" },
                new Studio { Name = "Marvel Studios" },
                new Studio { Name = "Paramount Pictures" },
                new Studio { Name = "20th Century Fox" },
                new Studio { Name = "RatPac-Dune Entertainment" },
                new Studio { Name = "Legendary Entertainment" },
                new Studio { Name = "Relativity Media" },
                new Studio { Name = "Netflix" },
                new Studio { Name = "DreamWorks Pictures" },
                new Studio { Name = "Disney-Pixar" }};

                await applicationDbContext.Studios.AddRangeAsync(studios);
                await applicationDbContext.SaveChangesAsync();
            }

        }
    }
}
