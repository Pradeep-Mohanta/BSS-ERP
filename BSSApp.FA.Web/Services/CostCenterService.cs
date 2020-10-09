using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class CostCenterService : ICostCenterService
    {
        private readonly HttpClient httpClient;

        public CostCenterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<CostCenter> GetCostCenter(int id)
        {
            return await httpClient.GetJsonAsync<CostCenter>($"api/costcenters/{id}");
        }

        public async Task<IEnumerable<CostCenter>> GetCostCenters()
        {
            return await httpClient.GetJsonAsync<CostCenter[]>("api/costcenters");
        }
    }
}
