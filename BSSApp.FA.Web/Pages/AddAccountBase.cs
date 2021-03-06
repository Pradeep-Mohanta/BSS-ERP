﻿using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class AddAccountBase:ComponentBase
    {
        //public string ShowGLView { get; set; }

        [Inject]
        public IAcMasterService AcMasterService { get; set; }
        public AcMaster AcMasters { get; set; } = new AcMaster();
        public IEnumerable<AcMaster> AcMastersNew { get; set; }

        [Inject]
        public ILedgerService LedgerService { get; set; }
        public IEnumerable<Ledger> Ledgers { get; set; } = new List<Ledger>();
        public string LedgerID { get; set; }
        public string BSheetGID { get; set; }
        public string L_ID { get; set; }
        public string L_Code { get; set; }

        [Inject]
        public IAccountGroupMasterService AccountGroupMasterService { get; set; }
        public IEnumerable<AccountGroupMaster> AccountGroupMasters { get; set; } = new List<AccountGroupMaster>();

        //public Boolean Disable_Act_Footer { get; set; } = true;
        public string Maxaccountno { get; set; }
        public string CreatedUser { get; set; } = "Admin";
        protected BioScan.Components.BssMessagePopup MessageConfirmation;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Ledgers = (await LedgerService.GetLedgers()).ToList();
            AccountGroupMasters = (await AccountGroupMasterService.GetAccountGroupMasters()).ToList();
            //AcMasters = (AcMaster)await AcMasterService.GetAcMasters();
            AcMasters = new AcMaster
            {
                Acno=Maxaccountno,
                Ason=DateTime.Now,
                CreatedBy = CreatedUser,
                CreatedDate = DateTime.Now,
                AuthorisedAc = false,
                AuthorisedDate = DateTime.Now,
                AuthorisedBy = "pdp"
            };
        }
        protected async void ConfirmAction_Click(bool actionConfirm)
        {
            if (actionConfirm)
            {
                //string lgrVal = "3,GL";
                //LedgerChange(lgrVal);
                var result = await AcMasterService.AddAcMaster(AcMasters);
                if (result != null)
                {
                    NavigationManager.NavigateTo("/findaccount");
                }
            }
        }
        protected void AddNewAccount()
        {
            MessageConfirmation.show();
            
        }
        protected async void OnAccountGroupChange(ChangeEventArgs AccountGroupChange)
        {
            int val;     
            //int LID;
            Int32.TryParse(L_ID, out int LID);
            //******************Data Fetching through lambda-expression
            //AcMastersNew = (IEnumerable<AcMaster>) await AcMasterService.GetMaxAccountNo(AccountGroupChange.Value.ToString());
            
            //******************Data Fetching through store-procedure
            AcMastersNew = await AcMasterService.GetMaxAcNo_sp(AccountGroupChange.Value.ToString());
            if (AcMastersNew.Count() > 0)
            {
                foreach (var acm in AcMastersNew)
                {
                    Int32.TryParse(acm.Acno, out val);
                    Maxaccountno = (val + 1).ToString();
                    AcMasters = new AcMaster 
                    {
                        LedgerID = LID,
                        LedgerCode = L_Code,
                        Acno = Maxaccountno, 
                        DrCr="D",
                        CountryID=1,
                        StateID=1,
                        Ason=DateTime.Now, 
                        AuthorisedDate=DateTime.Now, 
                        Compcode="001",
                        Dob=DateTime.Now,
                        CreatedDate=DateTime.Now,
                        CreatedBy= CreatedUser
                    };
                    StateHasChanged();
                }
            }
            else
            {
                Int32.TryParse(AccountGroupChange.Value.ToString(), out val);
                Maxaccountno = (val + 1).ToString();
                //Int32.TryParse(L_ID, out LID);
                AcMasters = new AcMaster 
                { 
                    
                    LedgerID=LID,
                    LedgerCode=L_Code,
                    Acno = Maxaccountno,
                    DrCr = "D",
                    CountryID = 1,
                    StateID=1,
                    Ason = DateTime.Now,
                    AuthorisedDate = DateTime.Now,
                    Compcode = "001",
                    Dob = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    CreatedBy = CreatedUser
                };
                StateHasChanged();
            }
        }
        protected async void Group_Change(string value)
        {
            int val;
            Int32.TryParse(L_ID, out int LID);
            BSheetGID = value;
            //******************Data Fetching through lambda-expression
            //AcMastersNew = (IEnumerable<AcMaster>) await AcMasterService.GetMaxAccountNo(AccountGroupChange.Value.ToString());

            //******************Data Fetching through store-procedure
            AcMastersNew = await AcMasterService.GetMaxAcNo_sp(value);
            if (AcMastersNew.Count() > 0)
            {
                foreach (var acm in AcMastersNew)
                {
                    Int32.TryParse(acm.Acno, out val);
                    Maxaccountno = (val + 1).ToString();
                    AcMasters = new AcMaster
                    {
                        LedgerID = LID,
                        LedgerCode = L_Code,
                        Acno = Maxaccountno,
                        DrCr = "D",
                        CountryID = 1,
                        StateID = 1,
                        Ason = DateTime.Now,
                        AuthorisedDate = DateTime.Now,
                        Compcode = "001",
                        Dob = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        CreatedBy = CreatedUser
                    };
                    StateHasChanged();
                }
            }
            else
            {
                Int32.TryParse(value, out val);
                Maxaccountno = (val + 1).ToString();
                //Int32.TryParse(L_ID, out LID);
                AcMasters = new AcMaster
                {
                    LedgerID = LID,
                    LedgerCode = L_Code,
                    Acno = Maxaccountno,
                    DrCr = "D",
                    CountryID = 1,
                    StateID = 1,
                    Ason = DateTime.Now,
                    AuthorisedDate = DateTime.Now,
                    Compcode = "001",
                    Dob = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    CreatedBy = CreatedUser
                };
                StateHasChanged();
            }
        }
        protected void LedgerChange(string value)
        {
            string[] get_value = value.Split(",");
            L_ID = get_value[0].ToString();
            Int32.TryParse(L_ID, out int LID);
            L_Code = get_value[1].ToString();
            LedgerID = value;
            BSheetGID = "0";
            AcMasters = new AcMaster
            {
                LedgerID = LID,
                LedgerCode = L_Code,
                Acno = "",
                DrCr = "D",
                CountryID = 1,
                StateID = 1,
                Ason = DateTime.Now,
                AuthorisedDate = DateTime.Now,
                Compcode = "001",
                Dob = DateTime.Now,
                CreatedDate = DateTime.Now,
                CreatedBy = CreatedUser
            };
        }
    }
}
