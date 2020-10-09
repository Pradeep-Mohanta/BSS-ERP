using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class TypeMastService : ITypeMastService
    {
        private readonly HttpClient httpClient;

        public TypeMastService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<TypeMast> GetTypeMast(int id)
        {
            return await httpClient.GetJsonAsync<TypeMast>($"api/typemast/{id}");
        }

        public async Task<IEnumerable<TypeMast>> GetTypeMasts()
        {
            return await httpClient.GetJsonAsync<TypeMast[]>("api/typemast");
        }
    }
}
