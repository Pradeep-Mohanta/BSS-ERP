using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public interface ISubLedgerRepository
    {
        Task<IEnumerable<SubLedger>> GetSubLedgers();
        Task<List<SubLedger>> GetSubLedger_lcode(string LedgerCode);
        Task<SubLedger> GetSubLedger(int id);
    }
}
