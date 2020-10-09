using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public interface ISubLedgerService
    {
        Task<List<SubLedger>> GetSubLedgers(string lcode);
        //Task<SubLedger> GetsubLedger(int id);
    }
}
