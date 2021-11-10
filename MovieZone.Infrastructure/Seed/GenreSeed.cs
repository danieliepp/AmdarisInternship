using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Infrastructure.Seed
{
    public class GenreSeed
    {
        public static async Task Seed(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Genres.Any())
            {
                Genre[] genres = {
                new Genre { Name = "Action"},
                new Genre { Name = "Comedy" },
                new Genre { Name = "Drama" },
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Mystery" },
                new Genre { Name = "Romance" },
                new Genre { Name = "Thriller" },
                new Genre { Name = "Adventure" },
                new Genre { Name = "Crime" },
                new Genre { Name = "Documentary" },
                new Genre { Name = "Animation" },
                new Genre { Name = "Family" },
                new Genre { Name = "Science Fiction" },
                new Genre { Name = "War" }};

                await applicationDbContext.AddRangeAsync(genres);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
