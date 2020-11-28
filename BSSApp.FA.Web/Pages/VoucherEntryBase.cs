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
        public IEnumerable<Trn> TrnFind { get; set; } = new List<Trn>();
        [Inject]
        public ILedgerService LedgerService { get; set; }
        public IEnumerable<Ledger> Ledgers { get; set; } = new List<Ledger>();

        [Inject]
        public ISubLedgerService SubLedgerService { get; set; }
        public List<SubLedger> SubLedger { get; set; }

        [Inject]
        public IBookMasterService BookMasterService { get; set; }
        //public List<BookMaster> BookMaster { get; set; }
        public string VoucherNo { get; set; }
        public bool Dis_Find { get; set; } = false;
        public bool Dis_Add { get; set; } = false;
        public string LedgerID { get; set; }
        public string SubLedgerID { get; set; }
        public DateTime CurDate { get; set; } = DateTime.Now;
        
        public IEnumerable<BookMaster> BookMaster { get; set; } = new List<BookMaster>();
        public string BookNo { get; set; }
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
            Int32.TryParse(BookNo, out int BkNo);
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
            BookNo = value;
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
            string[] sublCodestr = val.Split(",");
            string sublcode = sublCodestr[1];
            LedgerID = val;
            SubLedger =(await SubLedgerService.GetSubLedgersInLedger(sublcode)).ToList();
            StateHasChanged();
        }
        protected void SubLedger_Change(string myval)
        {
            SubLedgerID = myval;
        }
    }
}
