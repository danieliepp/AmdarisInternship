using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Infrastructure.Seed
{
    public class LanguageSeed
    {
        public static async Task Seed(ApplicationDbContext applicationDbContext)
        {
            if(!applicationDbContext.Languages.Any())
            {
                var english = new Language() { Name = "English" };
                var russian = new Language() { Name = "Russian" };

                applicationDbContext.Languages.Add(english);
                applicationDbContext.Languages.Add(russian);

                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
