using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class BSheetGroupRepository : IBSheetGroupRepository
    {
        private readonly AppDbContext appDbContext;

        public BSheetGroupRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<BSheetGroup> GetBSheetGroup(int id)
        {
            return await appDbContext.BSheetGroups.FirstOrDefaultAsync(b=>b.BSheetGroupID==id);
        }

        public async Task<IEnumerable<BSheetGroup>> GetBSheetGroups()
        {
            return await appDbContext.BSheetGroups
                    .OrderBy(b=>b.G_Name)
                    .ToListAsync();
        }
    }
}
