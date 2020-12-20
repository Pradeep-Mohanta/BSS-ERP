using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class VoucherEntryBase : ComponentBase
    {
        //[Inject]
        //public IMapper Mapper { get; set; }

        [Inject]
        public ITrnService TrnService { get; set; }
        public IEnumerable<Trn> TrnFindNew { get; set; } = new List<Trn>();
        public IEnumerable<Trn> TrnFind { get; set; } = new List<Trn>();
        public IEnumerable<Trn> TrnFindMaxVno { get; set; } = new List<Trn>();
        public List<Trn> MyList { get; set; } = new List<Trn>();
        public Trn Trns { get; set; } = new Trn();
        public TrnMemo TrnMemos { get; set; }
        public Trn TrnMemoNew { get; set; }
        public TrnMemo TrnMemo_sec { get; set; } = new TrnMemo();
        

        [Inject]
        public ILedgerService LedgerService { get; set; }
        public IEnumerable<Ledger> Ledgers { get; set; } = new List<Ledger>();

        [Inject]
        public ISubLedgerService SubLedgerService { get; set; }
        public IEnumerable<SubLedger> SubLedger { get; set; } = new List<SubLedger>();

        [Inject]
        public IAcMasterService AcMasterService { get; set; }
        public IEnumerable<AcMaster> AcMaster { get; set; }

        [Inject]
        public IBookMasterService BookMasterService { get; set; }
        public IEnumerable<BookMaster> BookMaster { get; set; } = new List<BookMaster>();

        [Inject]
        public ICostCenterService CostCenterService { get; set; }
        public IEnumerable<CostCenter> CostCenter { get; set; }
        
        [Inject]
        public ITrnMemoService TrnMemoService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string VoucherNoFind { get; set; }
        public string VoucherNumberSaved { get; set; }
        public int SVNo { get; set; }
        public string Narration1 { get; set; }
        public string ChequeNo { get; set; }
        public double Amount { get; set; }
        public string PairNo { get; set; }
        public string DebitCredit { get; set; }
        public bool Dis_Find { get; set; } = false;
        public bool Dis_Add { get; set; } = false;
        public bool Dis_voucherTable { get; set; } = false;
        public bool UpdateSubVoucherDisplay { get; set; } = false;
        public bool IsDisableVoucherDateAndBook { get; set; } = false;
        public bool DisableVoucherSaveButton { get; set; } = true;
        public bool DisableAdd_SubVoucherButton { get; set; } = true;
        public bool FromTableRowSelect { get; set; } = false;
        public string FetchLedgerID { get; set; }
        public string LedgerID { get; set; }
        public string LedgerCode { get; set; }

        public string FetchSubLedger { get; set; }
        public string SubLedgerID { get; set; }
        public string SubLedgerCode { get; set; }

        public string FetchAccountCode { get; set; }
        public string AccountID { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }

        public string CostCenterID { get; set; }
        //public DateTime VoucherDate { get; set; } = DateTime.Now;
        private DateTime CurDt = DateTime.Now;
        //public string[] acno_name;
        //public int arctr = 0;
        public DateTime VoucherDate 
            {
                get { return CurDt; }
                set { 
                        CurDt = value;
                        VoucherDateChange();
                    } 
            }
        public DateTime CurrentDate { get; set; } = DateTime.Now;

        public string SelectBookID { get; set; }
        public string SelectBookNo { get; set; }
        public string FetchBookNo { get; set; }

        public int Ctr { get; set; } = 0;
        public double DrAmount { get; set; } = 0;
        public double CrAmount { get; set; } = 0;
        protected async override Task OnInitializedAsync()
        {
            //Trns =(Trn) await TrnService.GetTrns();
            BookMaster = (IEnumerable<BookMaster>)await BookMasterService.GetBookMasters();
            Ledgers = await LedgerService.GetLedgers();
        }
        protected async void FindVoucher()
        {
            Dis_Find = true;
            Dis_Add = false;
            Int32.TryParse(SelectBookNo, out int BkNo);
            TrnFind = await TrnService.GetTrnVdtBook(VoucherDate, BkNo);
            StateHasChanged();
        }
        protected void BookChange(string value)
        {
            string[] SBookNo = value.Split(",");
            FetchBookNo = value;
            SelectBookID = SBookNo[0];
            SelectBookNo = SBookNo[1];
            //TrnFind = (IEnumerable<Trn>)await TrnService.GetTrnVdtBook(CurDate, int.Parse(BookNo));

        }
        protected async void Voucher_Change(string Vno)
        {
            VoucherNoFind = Vno;
            string[] get_values = Vno.Split(",");
            int get_bookno = Int32.Parse(get_values[1]);
            DateTime get_vdt = Convert.ToDateTime(get_values[2]);
            string get_vno = get_values[3];
            TrnFindNew = await TrnService.GetTrnsVno(get_vno, get_vdt, get_bookno);
            StateHasChanged();
        }
        protected void AddVoucher()
        {
            Dis_Find = false;
            Dis_voucherTable = false;
            Dis_Add = true;
            MyList.Clear();
        }
        protected async void Ledger_Change(string val)
        {
            FetchLedgerID = val;
            string[] sublCodestr = val.Split(",");
            LedgerID = sublCodestr[0];
            LedgerCode = sublCodestr[1];
            SubLedger = await SubLedgerService.GetSubLedgersInLedger(LedgerCode);
            AcMaster = await AcMasterService.LedgerOfAccounts(LedgerCode);
            CostCenter = await CostCenterService.GetCostCenters();
            if (FromTableRowSelect == true)
            {
                FromTableRowSelect = false;
            }
            else
            {
                FetchAccountCode = "0";
            }
            StateHasChanged();
        }
        protected void SubLedger_Change(string myval)
        {
            FetchSubLedger = myval;
            string[] subL = myval.Split(",");
            SubLedgerID = subL[0];
            SubLedgerCode = subL[1];
        }
        protected void Account_Change(string SelectVal)
        {
            FetchAccountCode = SelectVal;
            string[] ActCode = SelectVal.Split(",");
            AccountID = ActCode[0];
            AccountNo = ActCode[1];
            AccountName= ActCode[2];
        }
        protected void CostCenter_Change(string value)
        {
            CostCenterID = value;
        }
        protected void AddSubVoucher()
        {
            IsDisableVoucherDateAndBook = true;
            Dis_voucherTable = true;
            DisableVoucherSaveButton = false;
            //VoucherNumberSaved = "0000025";
            #region old code
            /*
            //Trnm = new List<Trn>()
            //{
            //    new Trn()
            //    {
            //        AcMasterID= int.Parse(AccountID)
            //    }
            //};
            //TrnMemoNew = new Trn
            //{
            //    AcMaster = Trns.AcMaster,
            //    BookMaster = Trns.BookMaster,
            //    CostCenter = Trns.CostCenter,
            //    Ledger = Trns.Ledger,
            //    SubLedger = Trns.SubLedger,
            //    AcMasterID = int.Parse(AccountID),
            //    Acno = AccountNo,
            //    Amount = Trns.Amount,
            //    BranchCode = "01",
            //    BookNo = int.Parse(SelectBookNo),
            //    BookMasterID = int.Parse(SelectBookID),
            //    ChqBr = "",
            //    ChequeNo = Trns.ChequeNo,
            //    Comp_Id = "001",
            //    CostCenterID = int.Parse(CostCenterID),
            //    Dc = Trns.Dc,
            //    Entrydate = CurDate,
            //    LedgerID = int.Parse(LedgerID),
            //    Narr1 = Trns.Narr1,
            //    Narr2 = "",
            //    Narr3 = "",
            //    PairNo = "",
            //    RefModuleCode = "FA",
            //    ShareTrnNo = "",
            //    Slcd = LedgerCode,
            //    SubLedgerID = int.Parse(SubLedgerID),
            //    SubLcd = SubLedgerCode,
            //    SvNo = 1,
            //    Username = "admin",
            //    Vdt = Trns.Vdt,
            //    Vno = "0000001"
            //};
            AcMaster = Trns.AcMaster,
            BookMaster = Trns.BookMaster,
            CostCenter = Trns.CostCenter,
            Ledger = Trns.Ledger,
            SubLedger = Trns.SubLedger,
            */
            #endregion
            MyList.Add(new Trn 
                    {
                        AcMasterID = int.Parse(AccountID),
                        Acno = AccountNo+"#"+AccountName,
                        Amount = Amount,
                        BranchCode = "01",
                        BookNo = int.Parse(SelectBookNo),
                        BookMasterID = int.Parse(SelectBookID),
                        ChqBr = "",
                        ChequeNo =ChequeNo,
                        Comp_Id = "001",
                        CostCenterID = int.Parse(CostCenterID),
                        Dc = DebitCredit,
                        Entrydate = CurrentDate,
                        LedgerID = int.Parse(LedgerID),
                        Narr1 = Narration1,
                        Narr2 = "",
                        Narr3 = "",
                        PairNo = PairNo,
                        RefModuleCode = "FA",
                        ShareTrnNo = "",
                        Slcd = LedgerCode,
                        SubLedgerID = int.Parse(SubLedgerID),
                        SubLcd = SubLedgerCode,
                        SvNo = ( Ctr == 0 ? 1 : MyList.Max(a=> a.SvNo) + 1 ),
                        Username = "admin",
                        Vdt = VoucherDate,
                        Vno =VoucherNumberSaved
                    });
            Ctr += 1;
            SVNo = Ctr;
            if (DebitCredit == "D")
            {
                DrAmount =+ Amount;
            }
            else
            {
                CrAmount =+ Amount;
            }
        }
       protected void VoucherPageReload()
        {
            NavigationManager.NavigateTo("/VoucherEntry", true);
        }
        protected void FetchRow(Trn trn_ml)
        {
            string[] selectedAcnoName;
            string select_acno;string select_acname;
            FromTableRowSelect = true;
            UpdateSubVoucherDisplay = true;
            selectedAcnoName = trn_ml.Acno.Split("#");
            select_acno = selectedAcnoName[0].Trim();
            select_acname= selectedAcnoName[1].Trim();
            string selectedLedger= trn_ml.LedgerID.ToString() + "," + trn_ml.Slcd;
            Ledger_Change(selectedLedger);
            FetchSubLedger = trn_ml.SubLedgerID.ToString() + "," + trn_ml.SubLcd;
            FetchAccountCode = trn_ml.AcMasterID.ToString().Trim() + "," + select_acno + "," + select_acname;
            CostCenterID = trn_ml.CostCenterID.ToString();
            Narration1 = trn_ml.Narr1;
            SVNo = trn_ml.SvNo;
            ChequeNo = trn_ml.ChequeNo;
            PairNo = trn_ml.PairNo;
            Amount = trn_ml.Amount;
            DebitCredit = trn_ml.Dc;
        }
        
        protected void UpdateSubVoucher(List<Trn> MyList)
        {
            DrAmount = 0;
            CrAmount = 0;
            UpdateSubVoucherDisplay = false;
            DisableVoucherSaveButton = false;
            string[] updAcno =FetchAccountCode.Split(",");
            string toUpdAcno = updAcno[1] + "#" + updAcno[2];
            string updAcMasterID = updAcno[0];
            string updAcName = updAcno[2];
            string[] updLedger = FetchLedgerID.Split(",");
            string updLedgerID = updLedger[0];
            string updslcd = updLedger[1];
            string[] updSubLedger = FetchSubLedger.Split(",");
            string updSubledgerID = updSubLedger[0];
            string updSubledgerCode = updSubLedger[1];
            MyList.Where(x => x.SvNo == SVNo).ToList()
                .ForEach(x => 
                {
                    x.LedgerID =int.Parse(updLedgerID);x.Slcd = updslcd; x.SubLedgerID =int.Parse(updSubledgerID); x.SubLcd = updSubledgerCode;
                    x.AcMasterID = int.Parse(updAcMasterID); x.Acno = toUpdAcno; x.CostCenterID = int.Parse(CostCenterID);
                    x.Narr1 = Narration1;x.ChequeNo = ChequeNo;x.PairNo=PairNo; x.Amount = Amount;x.Dc = DebitCredit;
                });
            MyList.Where(x => x.Dc == "D").ToList().ForEach(x => DrAmount += x.Amount);
            MyList.Where(x => x.Dc == "C").ToList().ForEach(x => CrAmount += x.Amount);
        }
        protected void SaveVoucher()
        {
            UpdateSubVoucherDisplay = false;
            NewVoucherSave();
        }
        protected void VoucherDateChange()
        {
            FetchBookNo = "0";
            Dis_Find = false;
            VoucherNoFind = "0";
            TrnFindNew=null;
        }
        protected async void NewVoucherSave()
        {
            string[] SelectBkNo = FetchBookNo.Split(",");
            int SelectedBookNo = int.Parse(SelectBkNo[1]);
            TrnFindMaxVno = await TrnService.GetMaxVNoMonthlyYearly("monthly", VoucherDate, SelectedBookNo);
            if (TrnFindMaxVno == null)
            {
                VoucherNumberSaved = Convert.ToDouble("1").ToString("0000000");
            }
            else
            {
                VoucherNumberSaved = (Convert.ToDouble(TrnFindMaxVno.Max(x => x.Vno)) + 1).ToString("0000000");
            }
            StateHasChanged();
            List<string> acnoNm = new List<string>();
            foreach (var myval in MyList)
            {
                acnoNm.Add(myval.SvNo.ToString() + ':' + myval.Acno.ToString());
            }
            var SaveTrn = MyList;
            SaveTrn.ForEach(x => { x.Acno = x.Acno.Substring(0, x.Acno.IndexOf("#")); x.Vno = VoucherNumberSaved; });
            //foreach (var saveTrn in SaveTrn)
            //{
            //    var result=await TrnService.AddTrn(saveTrn);
            //    if (result!=null)
            //    {
            //        VoucherNumberSaved = result.Vno;
            //    }
            //}
            string[] ValUpdate;
            string newAcno;
            int sv_no;
            for (int i = 0; i <= acnoNm.Count - 1; i++)
            {
                ValUpdate = acnoNm[i].Split(":");
                sv_no = int.Parse(ValUpdate[0]);
                newAcno = ValUpdate[1];
                MyList.Where(x => x.SvNo == sv_no).ToList().ForEach(x => x.Acno = newAcno);
            }
            DisableVoucherSaveButton = true;
            StateHasChanged();
        }
        protected void DrCrChange(string DrCr)
        {
            DebitCredit = DrCr;
            DisableAdd_SubVoucherButton = false;
        }
    }
    
}
