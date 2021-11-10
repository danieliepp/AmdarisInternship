using MovieZone.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Infrastructure.Seed
{
    public class CountrySeed
    {
        public static async Task Seed(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Countries.Any())
            {
                var unitedStates = new Country() { Name = "United States" };
                var unitedKingdom = new Country() { Name = "United Kingdom" };
                var china = new Country() { Name = "China" };
                var france = new Country() { Name = "France" };
                var japan = new Country() { Name = "Japan" };
                var germany = new Country() { Name = "Germany" };
                var republicOfKorea = new Country() { Name = "Republic of Korea" };
                var canada = new Country() { Name = "Canada" };
                var australia = new Country() { Name = "Australia" };
                var india = new Country() { Name = "India" };
                var italy = new Country() { Name = "Italy" };
                var russianFederation = new Country() { Name = "Russian Federation" };

                applicationDbContext.Countries.Add(unitedStates);
                applicationDbContext.Countries.Add(unitedKingdom);
                applicationDbContext.Countries.Add(china);
                applicationDbContext.Countries.Add(france);
                applicationDbContext.Countries.Add(japan);
                applicationDbContext.Countries.Add(germany);
                applicationDbContext.Countries.Add(republicOfKorea);
                applicationDbContext.Countries.Add(canada);
                applicationDbContext.Countries.Add(australia);
                applicationDbContext.Countries.Add(india);
                applicationDbContext.Countries.Add(italy);
                applicationDbContext.Countries.Add(russianFederation);

                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
