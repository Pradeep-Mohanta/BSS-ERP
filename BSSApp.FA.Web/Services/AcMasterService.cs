using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class AcMasterService : IAcMasterService
    {
        private readonly HttpClient httpClient;

        public AcMasterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<AcMaster> AddAcMaster(AcMaster NewAccountMaster)
        {
            return await httpClient.PostJsonAsync<AcMaster>("api/AcMasters", NewAccountMaster);
        }

        public async Task<AcMaster> GetAcMaster(int AcMasterId)
        {
            return await httpClient.GetJsonAsync<AcMaster>($"api/AcMasters/{AcMasterId}");
        }

        public async Task<IEnumerable<AcMaster>> GetAcMasters()
        {
            return await httpClient.GetJsonAsync<AcMaster[]>("api/AcMasters");
        }
        public async Task<IEnumerable<AcMaster>> GetMaxAccountNo(string gcode)
        {
            return await httpClient.GetJsonAsync<AcMaster[]>($"api/AcMasters/maxacno?gcode={gcode}");
        }

        public async Task<AcMaster[]> GetMaxAcNo_sp(string gcode)
        {
            return await httpClient.GetJsonAsync<AcMaster[]>($"api/AcMasters/maxacnosp?gcode={gcode}");
        }

        public async Task<IEnumerable<AcMaster>> LedgerOfAccounts(string Lcd) 
        {
            return await httpClient.GetJsonAsync<AcMaster[]>($"api/AcMasters/accountsearch?ledgercode={Lcd}");
        }

        public async Task<AcMaster> UpdateAcMaster(AcMaster updatedAcmaster)
        {
            return await httpClient.PutJsonAsync<AcMaster>("api/AcMasters",updatedAcmaster);
        }
    }
}
