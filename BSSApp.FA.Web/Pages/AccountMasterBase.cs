using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class AccountMasterBase:ComponentBase
    {
        [Inject]
        public IAcMasterService AcMasterService { get; set; }

        //public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<AcMaster> AcMasters { get; set; } = new List<AcMaster>();
        public IEnumerable<AcMaster> AcMastersNew { get; set; }

        [Inject]
        public ILedgerService LedgerService { get; set; }
        public IEnumerable<Ledger> Ledgers { get; set; } = new List<Ledger>();

        [Inject]
        public IAccountGroupMasterService AccountGroupMasterService { get; set; }
        public IEnumerable<AccountGroupMaster> AccountGroupMasters { get; set; } = new List<AccountGroupMaster>();

        [Parameter]
        public string Lcd { get; set; }
        public string LedgerID { get; set; } ="3";
        public string  AccountGroupCode { get; set; }
        public string maxaccountno { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Ledgers = (await LedgerService.GetLedgers()).ToList();
            AccountGroupMasters= (await AccountGroupMasterService.GetAccountGroupMasters()).ToList();
            Lcd = Lcd ?? "GL";
            AcMasters = (await AcMasterService.LedgerOfAccounts(Lcd)).ToList();
        }
        protected async void OnAccountGroupChange(ChangeEventArgs AccountGroupChange)
        {
            int val = 0;
            //******************Data Fetching through lambda-expression
            //AcMastersNew = (IEnumerable<AcMaster>) await AcMasterService.GetMaxAccountNo(AccountGroupChange.Value.ToString());

            //******************Data Fetching through store-procedure
            AcMastersNew = await AcMasterService.GetMaxAcNo_sp(AccountGroupChange.Value.ToString());
            if (AcMastersNew.Count()>0)
            {
                foreach (var acno in AcMastersNew)
                {
                    Int32.TryParse(acno.Acno, out val);
                    maxaccountno = (val+1).ToString();
                    StateHasChanged();
                }
            }
            else
            {
                Int32.TryParse(AccountGroupChange.Value.ToString(), out val);
                maxaccountno = (val + 1).ToString();
                StateHasChanged();
            }
            //AcMaster = (await AcMasterService.LedgerOfAccounts(Lcd)).ToList();
        }


    }
}
