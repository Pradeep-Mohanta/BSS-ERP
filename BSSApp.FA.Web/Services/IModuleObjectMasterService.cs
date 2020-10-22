using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public interface IModuleObjectMasterService
    {
        Task<IEnumerable<ModuleObjectMaster>> GetModuleObjectMasters();
        Task<ModuleObjectMaster> GetModuleObjectMaster(int id);
        Task<IEnumerable<ModuleObjectMaster>> GetModuleObjects_user_ModuleWise
                (string userName, int moduleMasterID, string objectType);
    }
}
