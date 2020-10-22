using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class UserAssignModuleRepository : IUserAssignModuleRepository
    {
        private readonly AppDbContext appDbContext;

        public UserAssignModuleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<UserAssignModule> GetUserAssignModule(int id)
        {
            return await appDbContext.UserAssignModule
                            .Include(a=>a.ModuleMaster)
                            .FirstOrDefaultAsync(a => a.UserAssignModuleID == id);
        }

        public async Task<IEnumerable<UserAssignModule>> GetUserAssignModules()
        {
            return await appDbContext.UserAssignModule.ToListAsync();
        }

        public async Task<IEnumerable<UserAssignModule>> GetUserAssignModules_userName(string userName)
        {
            IQueryable<UserAssignModule> query = appDbContext.UserAssignModule
                            .Include(a => a.ModuleMaster)
                            .Where(a => a.UserName.Contains(userName));
            return await query.ToListAsync();
        }
    }
}
