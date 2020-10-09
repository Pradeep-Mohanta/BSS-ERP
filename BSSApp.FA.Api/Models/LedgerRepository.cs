using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class LedgerRepository : ILedgerRepository
    {
        private readonly AppDbContext appDbContext;

        public LedgerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Ledger> GetLedger(int id)
        {
            return await appDbContext.Ledgers.FirstOrDefaultAsync(l => l.LedgerID == id);
        }

        public async Task<IEnumerable<Ledger>> GetLedgers()
        {
            return await appDbContext.Ledgers.ToListAsync();
        }
    } 
}
