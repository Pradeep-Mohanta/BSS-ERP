using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public interface IAccountGroupMasterService
    {
        public Task<IEnumerable<AccountGroupMaster>> GetAccountGroupMasters();
        public Task<AccountGroupMaster> GetAccountGroupMaster(int id);
    }
}
