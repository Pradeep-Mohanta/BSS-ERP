using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public interface ITrnService
    {
        Task<IEnumerable<Trn>> GetTrns();
        Task<Trn> GetTrn(int id);
        Task<Trn> AddTrn(Trn newTrn);
        Task<Trn[]> GetTrnsVno(string Vno, DateTime vdt, int BookNo);
        Task<Trn[]> GetTrnVdtBook(DateTime vdt, int BookNo);
    }
}
