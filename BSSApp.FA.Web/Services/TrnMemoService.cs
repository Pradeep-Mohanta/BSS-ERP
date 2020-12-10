using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class TrnMemoService : ITrnMemoService
    {
        private readonly HttpClient httpClient;

        public TrnMemoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<TrnMemo> AddTrnMemo(TrnMemo NewTrnMemo)
        {
            return await httpClient.PostJsonAsync<TrnMemo>("api/TrnMemo", NewTrnMemo);
        }

        //public async Task<TrnMemo> AddTrnMemo_ext(Trn trnMemoNew)
        //{
        //    return await httpClient.PostJsonAsync<TrnMemo>("api/TrnMemo", trnMemoNew);
        //}
    }
}
