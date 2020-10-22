using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public interface IModuleMasterRepository
    {
        Task<IEnumerable<ModuleMaster>> GetModuleMasters();
        Task<ModuleMaster> GetModuleMaster(int id);
    }
}
