using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class CostCenterRepository : ICostCenterRepository
    {
        private readonly AppDbContext appDbContext;

        public CostCenterRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<CostCenter> GetCostCenter(int id)
        {
            return await appDbContext.CostCenters.FirstOrDefaultAsync(c => c.CostCenterID == id);
        }

        public async Task<IEnumerable<CostCenter>> GetCostCenters()
        {
            return await appDbContext.CostCenters
                        .OrderBy(c=>c.CostCenterName)
                        .ToListAsync();
        }
    }
}
