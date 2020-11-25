using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class ModuleObjectMasterRepository : IModuleObjectMasterRepository
    {
        private readonly AppDbContext appDbContext;

        public ModuleObjectMasterRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ModuleObjectMaster> GetModuleObjectMaster(int id)
        {
            return await appDbContext.ModuleObjectMaster
                .FirstOrDefaultAsync(a => a.ModuleObjectMasterID == id);
        }

        public async Task<IEnumerable<ModuleObjectMaster>> GetModuleObjectMasters()
        {
            return await appDbContext.ModuleObjectMaster
                        .Include(a=>a.UserObjectAssignMaster)
                        .Include(b=>b.ModuleMaster)
                        .ToListAsync();
        }
        public async Task<IEnumerable<ModuleObjectMaster>> GetModuleObjects_user_ModuleWise(string userName,int moduleID,string objectType)
        {
            IQueryable<ModuleObjectMaster> queryUser = appDbContext.ModuleObjectMaster
                                    .Include(a => a.UserObjectAssignMaster)
                                    .Include(b=>b.ModuleMaster)
                                    .Where(a => a.UserObjectAssignMaster.UserName.Contains(userName) 
                                                && a.ModuleCode=="FA" && a.ObjectType=="Master");
            return await queryUser.ToListAsync();
        }
    }
}
