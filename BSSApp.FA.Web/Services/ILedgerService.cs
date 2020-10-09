using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public interface ILedgerService
    {
        Task<IEnumerable<Ledger>> GetLedgers();
        Task<Ledger> GetLedger(int id);
    }
}
