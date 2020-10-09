using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public class StateService : IStateService
    {
        private readonly HttpClient httpClient;

        public StateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<State> GetState(int Id)
        {
            return await httpClient.GetJsonAsync<State>($"api/states/{Id}");
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            return await httpClient.GetJsonAsync<State[]>("api/states");
        }

        public async Task<IEnumerable<State>> GetStatesForCountry(int CID)
        {
            return await httpClient.GetJsonAsync<State[]>($"api/states/statesfind?cid={CID}");
        }
    }
}
