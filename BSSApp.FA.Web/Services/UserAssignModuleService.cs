using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class UserAssignModuleService : IUserAssignModuleService
    {
        private readonly HttpClient httpClient;

        public UserAssignModuleService(HttpClient httpClient )
        {
            this.httpClient = httpClient;
        }
        public async Task<UserAssignModule> GetUserAssignModule(int id)
        {
            return await httpClient.GetJsonAsync<UserAssignModule>($"api/UserAssignModule/{id}");
        }

        public async Task<IEnumerable<UserAssignModule>> GetUserAssignModules()
        {
            return await httpClient.GetJsonAsync<UserAssignModule[]>("api/UserAssignModule");
        }

        public async Task<IEnumerable<UserAssignModule>> GetUserAssignModules_userName(string userName)
        {
            try
            {
            return await httpClient.GetJsonAsync<UserAssignModule[]>($"api/UserAssignModule/userwise?username={userName}");
        }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, "User not Access.");
                throw ex;
            }

        }
    }
}
