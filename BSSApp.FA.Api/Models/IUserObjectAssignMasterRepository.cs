using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public interface IUserObjectAssignMasterRepository
    {
        Task<IEnumerable<UserObjectAssignMaster>> GetUserObjectAssignMasters();
        Task<UserObjectAssignMaster> GetUserObjectAssignMaster(int id);
    }
}
