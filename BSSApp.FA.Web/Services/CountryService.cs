using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient httpClient;

        public CountryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await httpClient.GetJsonAsync<Country[]>("api/countries");
        }

        public async Task<Country> GetCountry(int Id)
        {
            return await httpClient.GetJsonAsync<Country>($"api/countries/{Id}");
        }
    }
}
