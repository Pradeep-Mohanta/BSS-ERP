using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class BookMasterService : IBookMasterService
    {
        private readonly HttpClient httpClient;

        public BookMasterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<BookMaster> AddBookMaster(BookMaster newBook)
        {
            return await httpClient.PostJsonAsync<BookMaster>("api/BookMaster",newBook);
        }

        public async Task<BookMaster> GetBookMaster(int id)
        {
            return await httpClient.GetJsonAsync<BookMaster>($"api/BookMaster/{id}");
        }

        public async Task<IEnumerable<BookMaster>> GetBookMasters()
        {
            return await httpClient.GetJsonAsync<BookMaster[]>("api/bookmaster");
        }
    }
}
