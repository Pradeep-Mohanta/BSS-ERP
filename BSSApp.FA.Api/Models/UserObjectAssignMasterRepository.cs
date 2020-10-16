using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSSApp.FA.Models;

namespace BSSApp.FA.Api.Models
{
    public class UserObjectAssignMasterRepository : IUserObjectAssignMasterRepository
    {
        private readonly AppDbContext appDbContext;

        public UserObjectAssignMasterRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<UserObjectAssignMaster> GetUserObjectAssignMaster(int id)
        {
            return await appDbContext.UserObjectAssignMaster
                        .FirstOrDefaultAsync(a => a.ModuleObjectMasterID == id);
        }

        public async Task<IEnumerable<UserObjectAssignMaster>> GetUserObjectAssignMasters()
        {
            return await appDbContext.UserObjectAssignMaster
                            .OrderBy(t=>t.UserName)
                            .ToListAsync();
        }
    }
}
