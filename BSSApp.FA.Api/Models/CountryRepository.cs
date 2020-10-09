using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext appDbContext;

        public CountryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await appDbContext.Countries.ToListAsync();
        }

        public Task<Country> GetCountry(int id)
        {
            return appDbContext.Countries.FirstOrDefaultAsync(c => c.CountryID == id);
        }
    }
}
