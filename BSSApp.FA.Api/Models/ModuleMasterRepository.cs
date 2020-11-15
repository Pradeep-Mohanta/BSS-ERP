using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class ModuleMasterRepository : IModuleMasterRepository
    {
        private readonly AppDbContext appDbContext;

        public ModuleMasterRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ModuleMaster> GetModuleMaster(int id)
        {
            return await appDbContext.ModuleMaster.FirstOrDefaultAsync(m => m.ModuleMasterID == id);
        }

        public async Task<IEnumerable<ModuleMaster>> GetModuleMasters()
        {
            return await appDbContext.ModuleMaster.ToListAsync();
        }
    }
}
