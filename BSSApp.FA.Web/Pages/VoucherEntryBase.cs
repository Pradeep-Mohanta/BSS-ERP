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
        public Trn Trns { get; set; } = new Trn();
        public TrnMemo TrnMemos { get; set; }
        
        public List<Trn> MyList { get; set; } = new List<Trn>();

        public Trn TrnMemoNew { get; set; }
        public TrnMemo TrnMemo_sec { get; set; } = new TrnMemo();
        public IEnumerable<Trn> TrnFind { get; set; } = new List<Trn>();
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
        

        public string VoucherNo { get; set; }
        public bool Dis_Find { get; set; } = false;
        public bool Dis_Add { get; set; } = false;

        public string FetchLedgerID { get; set; }
        public string LedgerID { get; set; }
        public string LedgerCode { get; set; }

        public string FetchSubLedger { get; set; }
        public string SubLedgerID { get; set; }
        public string SubLedgerCode { get; set; }

        public string FetchAccountCode { get; set; }
        public string AccountID { get; set; }
        public string AccountNo { get; set; }

        public string CostCenterID { get; set; }
        public DateTime CurDate { get; set; } = DateTime.Now;

        public string SelectBookID { get; set; }
        public string SelectBookNo { get; set; }
        public string FetchBookNo { get; set; }

        public int Ctr { get; set; } = 0;

        //public List<Trn> Trnm;
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
            TrnFind = await TrnService.GetTrnVdtBook(CurDate, BkNo);
            //if (TrnFind.Count() > 0)
            //{
            //    foreach(var ftrn in TrnFind)
            //    {
            //        TrnFindNew = new Trn
            //        {
            //            AcMaster=ftrn.AcMaster,
            //            AcMasterID = ftrn.AcMasterID,
            //            Acno = ftrn.Acno,
            //            Amount = ftrn.Amount,
            //            BookMaster = ftrn.BookMaster,
            //            BookMasterID = ftrn.BookMasterID,
            //            BookNo = ftrn.BookNo,
            //            BranchCode = ftrn.BranchCode,
            //            ChequeNo = ftrn.ChequeNo,
            //            ChqBr = ftrn.ChqBr,
            //            Comp_Id = ftrn.Comp_Id,
            //            CostCenter=ftrn.CostCenter,
            //            CostCenterID = ftrn.CostCenterID,
            //            Dc = ftrn.Dc,
            //            Entrydate = ftrn.Entrydate,
            //            Ledger=ftrn.Ledger,
            //            LedgerID = ftrn.LedgerID,
            //            Narr1 = ftrn.Narr1,
            //            Narr2 = ftrn.Narr2,
            //            Narr3 = ftrn.Narr3,
            //            PairNo = ftrn.PairNo,
            //            RefModuleCode = ftrn.RefModuleCode,
            //            ShareTrnNo = ftrn.ShareTrnNo,
            //            Slcd = ftrn.Slcd,
            //            SubLedger=ftrn.SubLedger,
            //            SubLcd = ftrn.SubLcd,
            //            SubLedgerID = ftrn.SubLedgerID,
            //            SvNo = ftrn.SvNo,
            //            TrnID = ftrn.TrnID,
            //            Username = ftrn.Username,
            //            Vdt = ftrn.Vdt,
            //            Vno = ftrn.Vno
            //        };
            //    }
            //}
            //Trn = (Trn)await TrnService.GetTrns();
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
            VoucherNo = Vno;
            string[] get_values = Vno.Split(",");
            int get_bookno = Int32.Parse(get_values[1]);
            DateTime get_vdt = Convert.ToDateTime(get_values[2]);
            string get_vno = get_values[3];
            TrnFindNew = await TrnService.GetTrnsVno(get_vno, get_vdt, get_bookno);
            StateHasChanged();
            //if (TrnFindNew.Count() > 0)
            //{
            //    foreach (var ftrn in TrnFindNew)
            //    {
            //        Trn = new Trn
            //        {
            //            AcMaster = ftrn.AcMaster,
            //            AcMasterID = ftrn.AcMasterID,
            //            Acno = ftrn.Acno,
            //            Amount = ftrn.Amount,
            //            BookMaster = ftrn.BookMaster,
            //            BookMasterID = ftrn.BookMasterID,
            //            BookNo = ftrn.BookNo,
            //            BranchCode = ftrn.BranchCode,
            //            ChequeNo = ftrn.ChequeNo,
            //            ChqBr = ftrn.ChqBr,
            //            Comp_Id = ftrn.Comp_Id,
            //            CostCenter = ftrn.CostCenter,
            //            CostCenterID = ftrn.CostCenterID,
            //            Dc = ftrn.Dc,
            //            Entrydate = ftrn.Entrydate,
            //            Ledger = ftrn.Ledger,
            //            LedgerID = ftrn.LedgerID,
            //            Narr1 = ftrn.Narr1,
            //            Narr2 = ftrn.Narr2,
            //            Narr3 = ftrn.Narr3,
            //            PairNo = ftrn.PairNo,
            //            RefModuleCode = ftrn.RefModuleCode,
            //            ShareTrnNo = ftrn.ShareTrnNo,
            //            Slcd = ftrn.Slcd,
            //            SubLedger = ftrn.SubLedger,
            //            SubLcd = ftrn.SubLcd,
            //            SubLedgerID = ftrn.SubLedgerID,
            //            SvNo = ftrn.SvNo,
            //            TrnID = ftrn.TrnID,
            //            Username = ftrn.Username,
            //            Vdt = ftrn.Vdt,
            //            Vno = ftrn.Vno
            //        };
            //    }
            //}
        }
        protected void AddVoucher()
        {
            Dis_Find = false;
            Dis_Add = true;
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
        }
        protected void CostCenter_Change(string value)
        {
            CostCenterID = value;
        }
        protected void AddSubVoucher()
        {
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
            MyList.Add(new Trn 
                    {
                        AcMaster = Trns.AcMaster,
                        BookMaster = Trns.BookMaster,
                        CostCenter = Trns.CostCenter,
                        Ledger = Trns.Ledger,
                        SubLedger = Trns.SubLedger,
                        AcMasterID = int.Parse(AccountID),
                        Acno = AccountNo,
                        Amount = Trns.Amount,
                        BranchCode = "01",
                        BookNo = int.Parse(SelectBookNo),
                        BookMasterID = int.Parse(SelectBookID),
                        ChqBr = "",
                        ChequeNo = Trns.ChequeNo,
                        Comp_Id = "001",
                        CostCenterID = int.Parse(CostCenterID),
                        Dc = Trns.Dc,
                        Entrydate = CurDate,
                        LedgerID = int.Parse(LedgerID),
                        Narr1 = Trns.Narr1,
                        Narr2 = "",
                        Narr3 = "",
                        PairNo = "",
                        RefModuleCode = "FA",
                        ShareTrnNo = "",
                        Slcd = LedgerCode,
                        SubLedgerID = int.Parse(SubLedgerID),
                        SubLcd = SubLedgerCode,
                        SvNo = Ctr== 0 ? 1 : MyList.Max(a=> a.SvNo) + 1,
                        Username = "admin",
                        Vdt = Trns.Vdt,
                        Vno = "0000001"
                    });
            Ctr += 1;
            //trnMemo_sec.AcMaster = TrnMemoNew.AcMaster;
            //trnMemo_sec.AcMasterID = TrnMemoNew.AcMasterID;
            //trnMemo_sec.Acno = TrnMemoNew.Acno;
            //TrnMemos = await TrnMemoService.AddTrnMemo(trnMemo_sec);
        }
       
    }
}
