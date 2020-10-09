using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class LedgerService : ILedgerService
    {
        private readonly HttpClient httpClient;

        public LedgerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Ledger> GetLedger(int id)
        {
            return await httpClient.GetJsonAsync<Ledger>($"api/ledgers/{id}");
        }

        public async Task<IEnumerable<Ledger>> GetLedgers()
        {
            return await httpClient.GetJsonAsync<Ledger[]>("api/ledgers");
        }
    }
}
