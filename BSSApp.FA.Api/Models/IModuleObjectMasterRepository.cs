using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public interface IModuleObjectMasterRepository
    {
        Task<IEnumerable<ModuleObjectMaster>> GetModuleObjectMasters();
        Task<ModuleObjectMaster> GetModuleObjectMaster(int id);
        Task<IEnumerable<ModuleObjectMaster>> GetModuleObjects_user_ModuleWise(string userName,int moduleID,string objectType);
    }
}
