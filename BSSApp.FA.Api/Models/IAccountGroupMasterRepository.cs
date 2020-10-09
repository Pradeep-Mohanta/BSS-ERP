using BSSApp.FA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public interface IAccountGroupMasterRepository
    {
        public Task<List<AccountGroupMaster>> GetAccountGroupMasters();
        public Task<AccountGroupMaster> GetAccountGroupMaster(int id);

        public Task<List<AccountGroupMaster>> GetAccountGroupMastersWithCode(string AcGroupCode);
    }
}
