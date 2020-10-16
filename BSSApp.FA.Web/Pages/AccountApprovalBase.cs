using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
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

        protected BioScan.Components.BssMessagePopupBase MessageConfirmation { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Ledgers = (await LedgerService.GetLedgers()).ToList();
            AcMaster = await AcMasterService.GetAcMaster(int.Parse(Id));

            AcMaster = new AcMaster 
                {   
                    AcMasterID=AcMaster.AcMasterID,
                    LedgerID=AcMaster.LedgerID, 
                    LedgerCode=AcMaster.LedgerCode, 
                    Acno=AcMaster.Acno,
                    Acname=AcMaster.Acname,
                    CreatedBy=AcMaster.CreatedBy,
                    CreatedDate=AcMaster.CreatedDate,
                    AuthorisedBy =AcMaster.AuthorisedBy==null ? "LoginUser" : AcMaster.AuthorisedBy,
                    AuthorisedAc=AcMaster.AuthorisedAc == false ? false : AcMaster.AuthorisedAc,
                    AuthorisedDate=AcMaster.AuthorisedDate==null ? DateTime.Now :AcMaster.AuthorisedDate 
                };
        }

        public class HttpPatchRecord
        {
            [JsonPropertyName("op")]
            public string Op { get; set; }

            [JsonPropertyName("path")]
            public string Path { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
            //public bool displayBtn { get; set; } = false;
        }
        protected void confirmAction_Click( bool actionConfirmed)
        {
            if (actionConfirmed)
            {
                var patchObject = new List<HttpPatchRecord>();
                patchObject.Add(new HttpPatchRecord { Op = "replace", Path = "/authorisedBy", Value = AcMaster.AuthorisedBy });
                patchObject.Add(new HttpPatchRecord { Op = "replace", Path = "/authorisedAc", Value = AcMaster.AuthorisedAc.ToString() });
                patchObject.Add(new HttpPatchRecord { Op = "replace", Path = "/authorisedDate", Value = AcMaster.AuthorisedDate.ToString() });
                var json = System.Text.Json.JsonSerializer.Serialize(patchObject);
                var myHttpContent = new StringContent(json, Encoding.UTF8, "application/json");

                //,{ "op":"replace","path":"/authorisedAc","value": true},{ "op":"replace","path":"/authorisedDate","value": "2020-10-12"}]';
                AcMasterService.UpdatePatchAcMaster(AcMaster.AcMasterID, myHttpContent);
                NavigationManager.NavigateTo("/findaccount");
            }
        }
        protected void Update_Patch()
        {
            MessageConfirmation.show();
        }

        //protected void Update_Patch()
        //{
        //    var patchObject = new List<HttpPatchRecord>();
        //    patchObject.Add(new HttpPatchRecord { Op = "replace", Path = "/authorisedBy", Value = AcMaster.AuthorisedBy });
        //    patchObject.Add(new HttpPatchRecord { Op = "replace", Path = "/authorisedAc", Value = AcMaster.AuthorisedAc.ToString() });
        //    patchObject.Add(new HttpPatchRecord { Op = "replace", Path = "/authorisedDate", Value = AcMaster.AuthorisedDate.ToString() });
        //    var json = System.Text.Json.JsonSerializer.Serialize(patchObject);
        //    var myHttpContent = new StringContent(json, Encoding.UTF8, "application/json");

        //    //,{ "op":"replace","path":"/authorisedAc","value": true},{ "op":"replace","path":"/authorisedDate","value": "2020-10-12"}]';
        //    AcMasterService.UpdatePatchAcMaster(AcMaster.AcMasterID, myHttpContent);
        //}
    }
}
