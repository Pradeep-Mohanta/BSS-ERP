using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext appDbContext;

        public StateRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<State> GetState(int Id)
        {
            return await appDbContext.States.FirstOrDefaultAsync(s=>s.StateID==Id);
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            return await appDbContext.States
                        .OrderBy(s=>s.StateName)
                        .ToListAsync();
        }

        public async Task<IEnumerable<State>> GetStatesForCountry(int CID)
        {
            return await appDbContext.States
                    .Where(s=>s.CountryID==CID)
                    .OrderBy(s=>s.StateName)
                    .ToListAsync();
        }
    }
}
