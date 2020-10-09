using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class EditAccountBase:ComponentBase
    {
        [Inject]
        public IAcMasterService AcMasterService { get; set; }
        public AcMaster AcMaster { get; set; } = new AcMaster();
        
        [Inject]
        public ITypeMastService TypeMastService { get; set; }
        public List<TypeMast> TypeMasts { get; set; }

        [Inject]
        public IBSheetGroupService BSheetGroupService { get; set; }
        public List<BSheetGroup> BSheetGroups { get; set; }

        [Inject]
        public ICountryService CountryService { get; set; }
        public List<Country> Countries { get; set; }

        [Inject]
        public IStateService StateService { get; set; }
        public List<State> States { get; set; }

        [Inject]
        public ICostCenterService CostCenterService { get; set; }
        public List<CostCenter> CostCenters { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }
        public string CountryID;
        public string LedgerCode;
        public string Message { get; set; } = "Data Update Successfully";
        protected async override Task OnInitializedAsync()
        {
            //PopupMessage = "Data Update Successfully";
            AcMaster =await AcMasterService.GetAcMaster(int.Parse(Id));
            LedgerCode = AcMaster.LedgerCode;

            //CountryID = AcMaster.CountryID.ToString();
            //TypeMasts = (await TypeMastService.GetTypeMasts()).ToList();
            //BSheetGroups = (await BSheetGroupService.GetBSheetGroups()).ToList();
            //Countries = (await CountryService.GetCountries()).ToList();
            //States = (await StateService.GetStatesForCountry(int.Parse(CountryID))).ToList();
            //CostCenters = (await CostCenterService.GetCostCenters()).ToList();
        }
        protected async void CountryHasChanged(string value)
        {
            CountryID = value;
            await LoadState(value);
        }
        protected async Task LoadState(string value)
        {
            States = (await StateService.GetStatesForCountry(int.Parse(value))).ToList();
            StateHasChanged();
        } 
        protected async Task HandleValidSubmit()
        {
            await AcMasterService.UpdateAcMaster(AcMaster);
            //var result=await AcMasterService.UpdateAcMaster(AcMaster);
            //if (result != null)
            //{
            //    NavigationManager.NavigateTo("/findaccount");
            //}
        }
    }
}
