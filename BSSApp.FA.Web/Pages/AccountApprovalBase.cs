using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class AccountApprovalBase:ComponentBase
    {
        [Inject]
        public IAcMasterService AcMasterService { get; set; }
        public AcMaster AcMaster { get; set; } = new AcMaster();

        [Inject]
        public ILedgerService LedgerService { get; set; }
        public List<Ledger> Ledgers { get; set; }

        [Parameter]
        public string Id { get; set; }
        public string LedgerCode;
        public Boolean Disable_Act_Footer { get; set; } = false;
        protected async override Task OnInitializedAsync()
        {
            AcMaster = await AcMasterService.GetAcMaster(int.Parse(Id));
        }

    }
}
