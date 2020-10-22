using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class ModuleObjectMasterService : IModuleObjectMasterService
    {
        private readonly HttpClient httpClient;

        public ModuleObjectMasterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ModuleObjectMaster> GetModuleObjectMaster(int id)
        {
            return await httpClient.GetJsonAsync<ModuleObjectMaster>($"api/ModuleObjectMaster/{id}");
        }

        public async Task<IEnumerable<ModuleObjectMaster>> GetModuleObjectMasters()
        {
            return await httpClient.GetJsonAsync<ModuleObjectMaster[]>("api/ModuleObjectMaster");
        }

        public async Task<IEnumerable<ModuleObjectMaster>> GetModuleObjects_user_ModuleWise(string usrName, int mm_ID, string obj_Type)
        {
            return await httpClient.GetJsonAsync<ModuleObjectMaster[]>
                ($"api/ModuleObjectMaster/userwise?userName={usrName}&moduleID={mm_ID}&objectType={obj_Type}");
        }
    }
}
