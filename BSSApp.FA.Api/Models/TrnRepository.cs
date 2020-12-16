using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class TrnRepository : ITrnRepository
    {
        private readonly AppDbContext appDbContext;

        public TrnRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Trn> GetTrn(int TrnID)
        {
            return await appDbContext.Trn
                .Include(b=>b.Ledger)
                .Include(c=>c.SubLedger)
                .Include(d=>d.AcMaster)
                .Include(e=>e.BookMaster)
                .Include(f=>f.CostCenter)
                .FirstOrDefaultAsync(a=>a.TrnID==TrnID);
        }

        public async Task<IEnumerable<Trn>> GetTrns()
        {
            return await appDbContext.Trn
                .Take(1)
                .ToListAsync();
        }

        public async Task<IEnumerable<Trn>> GetTrnsVno(string Vno, DateTime Vdt, int BookNo)
        {
            IQueryable<Trn> trnQuery = appDbContext.Trn
                        .Include(b => b.Ledger)
                        .Include(c => c.SubLedger)
                        .Include(d => d.AcMaster)
                        .Include(e => e.BookMaster)
                        .Include(f => f.CostCenter)
                        .Where(a => a.Vno==Vno && a.Vdt == Vdt && a.BookNo == BookNo)
                        .OrderBy(a => a.Vno)
                        .ThenBy(a => a.SvNo);

            return await trnQuery.ToListAsync();
        }
        public async Task<Trn> AddTrn(Trn trn)
        {
            var addResult= await appDbContext.Trn.AddAsync(trn);
            await appDbContext.SaveChangesAsync();
            return addResult.Entity;
        }

        public async Task<Trn> DeleteTrn(int TrnID)
        {
            var delResult=await appDbContext.Trn.FirstOrDefaultAsync(a => a.TrnID == TrnID);
            if (delResult != null)
            {
                appDbContext.Trn.Remove(delResult);
                await appDbContext.SaveChangesAsync();
                return delResult;
            }
            return null;
        }

        public async Task<Trn> UpdateTrn(Trn trn)
        {
            var updResult=await appDbContext.Trn.FirstOrDefaultAsync(a => a.TrnID == trn.TrnID);
            if (updResult != null)
            {
                updResult.Vno = trn.Vno;
                updResult.SvNo = trn.SvNo;
                updResult.Vdt = trn.Vdt;
                updResult.LedgerID = trn.LedgerID;
                updResult.Slcd = trn.Slcd;
                updResult.SubLedgerID = trn.SubLedgerID;
                updResult.SubLcd = trn.SubLcd;
                updResult.AcMasterID = trn.AcMasterID;
                updResult.Acno = trn.Acno;
                updResult.Narr1 = trn.Narr1;
                updResult.Narr2 = trn.Narr2;
                updResult.Narr3 = trn.Narr3;
                updResult.Dc = trn.Dc;
                updResult.PairNo = trn.PairNo;
                updResult.Amount = trn.Amount;
                updResult.Entrydate = trn.Entrydate;
                updResult.BookMasterID = trn.BookMasterID;
                updResult.BookNo = trn.BookNo;
                updResult.Username = trn.Username;
                updResult.CostCenterID = trn.CostCenterID;
                updResult.Comp_Id = trn.Comp_Id;
                updResult.ChequeNo = trn.ChequeNo;
                updResult.ChqBr = trn.ChqBr;
                updResult.RefModuleCode = trn.RefModuleCode;
                updResult.ShareTrnNo = trn.ShareTrnNo;
                updResult.BranchCode = trn.BranchCode;

                await appDbContext.SaveChangesAsync();
                return updResult;
            }
            return null;
        }

        public async Task<IEnumerable<Trn>> GetTrnVdtBook(DateTime vdt, int BookNo)
        {
            IQueryable<Trn> trnQuery = appDbContext.Trn
                        .Include(b => b.Ledger)
                        .Include(c => c.SubLedger)
                        .Include(d => d.AcMaster)
                        .Include(e => e.BookMaster)
                        .Include(f => f.CostCenter)
                        .Where(a => a.Vdt == vdt && a.BookNo == BookNo)
                        .OrderBy(a => a.Vno)
                        .ThenBy(a => a.SvNo);


            return await trnQuery.ToListAsync();
        }

        public async Task<Trn[]> GetTrnVNoMonthlyYearly(string monthYear, DateTime vdt, int BookNo)
        {
            Trn[] trn;
            trn = await appDbContext.Trn.FromSqlRaw("execute GetMaxAcno @p0,@p1,@p2", monthYear,vdt,BookNo).ToArrayAsync();
            return trn;
        }
    }
}
