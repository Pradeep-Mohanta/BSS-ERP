using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
namespace BSSApp.FA.Web.Pages
{
 
    public class SubLedgerMasterBase:ComponentBase
    {
        //readonly HttpClient httpClient;
        [Inject]
        public ILedgerService LedgerService { get; set; }

        [Inject]
        public ISubLedgerService SubLedgerService { get; set; }

        public IEnumerable<Ledger> Ledgers { get; set; } = new List<Ledger>();
        //public List<SubLedger> SubLedgers { get; set; } = new List<SubLedger>();
        //public List<Ledger> Ledgers;
        public List<SubLedger> SubLedgers;
        //public IEnumerable<SubLedger> SubLedgers;
        public string LedgerID { get; set; }
        public string LedgerCode { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Ledgers = (await LedgerService.GetLedgers()).ToList();
            
            //SubLedgers = (await SubLedgerService.GetSubLedgers("GL")).ToList();
        }
        protected async void OnLedgerChange(string val)
        {
            //string myval = val;
            //httpClient.GetJsonAsync<SubLedger[]>($"api/subledgers/{LedgerID}");
            //var result= httpClient.GetJsonAsync<SubLedger[]>($"api/subledgers/{LedgerID}");
            SubLedgers = (await SubLedgerService.GetSubLedgers($"{val}")).ToList();

        }
        protected async Task LedgerChange(ChangeEventArgs ledgerEvent)
        {
            LedgerID = ledgerEvent.Value.ToString();
            //string myval = LedgerID;
            SubLedgers = (await SubLedgerService.GetSubLedgers(LedgerID)).ToList();
        }
        //private string ledger;
        //public string Ledger
        //{
        //    get => ledger;
        //    set
        //    {
        //        ledger = value;

        //        //GetSubLedgers();
        //    }
        //}
        //void GetSubLedgers()
        //{
        //    //SubLedgers = null;
        //    if (!string.IsNullOrEmpty(ledger))
        //    {
        //        var selectedLedger = ledger;
        //        SubLedgers = ((IEnumerable<SubLedger>)SubLedgerService.GetSubLedgers(selectedLedger)).ToList();
        //        //Task<IEnumerable<SubLedger>> task = subLedgerService.GetSubLedgers(selectedLedger);
        //        //SubLedgers = task.to;

        //    }
        //}
        //private string subledger;
        //public string SubLedger
        //{
        //    get => subledger;
        //    set
        //    {
        //        subledger = value;
        //    }
        //}
    }
}
