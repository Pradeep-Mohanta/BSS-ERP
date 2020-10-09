using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class BSheetGroupService : IBSheetGroupService
    {
        private readonly HttpClient httpClient;

        public BSheetGroupService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<BSheetGroup> GetBSheetGroup(int id)
        {
            return await httpClient.GetJsonAsync<BSheetGroup>($"api/bsheetgroup/{id}");
        }

        public async Task<IEnumerable<BSheetGroup>> GetBSheetGroups()
        {
            return await httpClient.GetJsonAsync<BSheetGroup[]>("api/bsheetgroup");
        }
    }
}
