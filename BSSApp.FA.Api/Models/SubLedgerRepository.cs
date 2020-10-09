using BSSApp.FA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class SubLedgerRepository : ISubLedgerRepository
    {
        private readonly AppDbContext appDbContext;

        public SubLedgerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<SubLedger> GetSubLedger(int id)
        {
            return await appDbContext.SubLedgers.FirstOrDefaultAsync(s=>s.SubLedgerID==id);
        }

        public async Task<IEnumerable<SubLedger>> GetSubLedgers()
        {
            return await appDbContext.SubLedgers.ToListAsync();
        }

        //public async Task<IEnumerable<SubLedger>> GetSubLedger_lcode(string LedgerCode)
        public async Task<List<SubLedger>> GetSubLedger_lcode(string LedgerCode)
        {
            IQueryable<SubLedger> result= appDbContext.SubLedgers.Where(s=>s.LedgerCode==LedgerCode);
            return await result.ToListAsync();
        }
    }
}
