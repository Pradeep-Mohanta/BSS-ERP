using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class AccountGroupMasterService : IAccountGroupMasterService
    {
        private readonly HttpClient httpClient;

        public AccountGroupMasterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<AccountGroupMaster> GetAccountGroupMaster(int id)
        {
            return await httpClient.GetJsonAsync<AccountGroupMaster>($"api/accountgroupmaster/{id}");
        }

        public async Task<IEnumerable<AccountGroupMaster>> GetAccountGroupMasters()
        {
            return await httpClient.GetJsonAsync<AccountGroupMaster[]>("api/accountgroupmaster");
        }
    }
}
