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
    public class FindAccountBase:ComponentBase
    {
        [Inject]
        public ILedgerService LedgerService { get; set; }
        public IEnumerable<Ledger> Ledgers { get; set; } = new List<Ledger>();

        [Inject]
        public IAcMasterService AcMasterService { get; set; }
        public IEnumerable<AcMaster> AcMaster { get; set; } = new List<AcMaster>();

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string LedgerID { get; set; }
        public string Lcd { get; set; }
        public ElementReference btn { get; set; }
        //public int ActId { get; set; }
        
        //public bool actionVal;
        protected BioScan.Components.BssMessagePopupBase MessageConfirmation { get; set; }
        protected void confirmAction_Click(bool actionConfirm)
        {
            if (actionConfirm)
            {
                string lgrVal = "3,GL";
                LedgerChange(lgrVal);
            }
        }
        protected async override Task OnInitializedAsync()
        {
            Ledgers = (await LedgerService.GetLedgers()).ToList();
        }
        protected async void LedgerChange(string value)
        {
            string[] get_val = value.Split(",");
            LedgerID = value;
            Lcd = get_val[1];
            await LoadAccountList(Lcd);
        }
        protected async Task LoadAccountList(string Lcd)
        {
            AcMaster = (await AcMasterService.LedgerOfAccounts(Lcd)).ToList();
            StateHasChanged();
        }
        
        protected async void Delete_Click(int id)
        {
            await AcMasterService.DeleteAcMaster(id);
            MessageConfirmation.show();
        }
    }
}
