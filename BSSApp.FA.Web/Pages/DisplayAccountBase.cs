using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class DisplayAccountBase:ComponentBase
    {
        [Parameter]
        public AcMaster AcMaster { get; set; } = new AcMaster();

        public DateTime Dob;
        
        [Inject]
        public ICountryService CountryService { get; set; }
        public List<Country> Countries { get; set; }
        public string CountryID;

        [Inject]
        public IStateService StateService { get; set; }
        public List<State> States { get; set; }
        public string StateID;

       

        protected async override Task OnInitializedAsync()
        {
            Dob = (AcMaster.Dob.ToString() == "1/1/0001 12:00:00 AM" ? DateTime.Today : AcMaster.Dob);

            CountryID = (AcMaster.CountryID.ToString() == "0" ? "1" : AcMaster.CountryID.ToString());
            StateID = (AcMaster.StateID.ToString() == "0" ? "0" : AcMaster.StateID.ToString());
            Countries = (await CountryService.GetCountries()).ToList();
            if (CountryID != "0")
            {
                States = (await StateService.GetStatesForCountry(int.Parse(CountryID))).ToList();
            }
        }
        protected async void CountryHasChanged(string value)
        {
            if (value != "0") 
            { 
                CountryID = value;
                await LoadState(value);
            }
            else
            {
                States.Clear();
            }
        }
        protected async Task LoadState(string value)
        {
            States = (await StateService.GetStatesForCountry(int.Parse(value))).ToList();
            StateHasChanged();
        }
    }
}
