using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class SubLedgerService : ISubLedgerService
    {
        private readonly HttpClient httpClient;

        public SubLedgerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<SubLedger>> GetSubLedgers(string lcode)
        {
            return await httpClient.GetJsonAsync<List<SubLedger>>($"api/subledgers/{lcode}");

        }

    }
}
