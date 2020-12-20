using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class TrnService : ITrnService
    {
        private readonly HttpClient httpClient;

        public TrnService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Trn> AddTrn(Trn newTrn)
        {
            return await httpClient.PostJsonAsync<Trn>("api/trn",newTrn);
        }

       

        public async Task<Trn> GetTrn(int id)
        {
            return await httpClient.GetJsonAsync<Trn>($"api/trn/{id}");
        }

        public async Task<IEnumerable<Trn>> GetTrns()
        {
            return await httpClient.GetJsonAsync<Trn[]>("api/trn");
        }

        public Task<Trn[]> GetTrnsVno(string Vno, DateTime vdt, int BookNo)
        {
            return httpClient.GetJsonAsync<Trn[]>($"api/trn/voucherVno?Vno={Vno}&Vdt={vdt}&BookNo={BookNo}");
        }

        public async Task<Trn[]> GetTrnVdtBook(DateTime vdt, int BookNo)
        {
            return await httpClient.GetJsonAsync<Trn[]>($"api/trn/voucherVdt?Vdt={vdt}&BookNo={BookNo}");
        }
        public async Task<Trn[]> GetMaxVNoMonthlyYearly(string monthOrYear, DateTime vdt, int BookNo)
        {
            return await httpClient.GetJsonAsync<Trn[]>($"api/trn/maxvoucherno?monthOrYear={monthOrYear}&vdt={vdt}&BookNo={BookNo}");
        }
    }
}
