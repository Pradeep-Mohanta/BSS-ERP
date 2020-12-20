using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public interface ITrnRepository
    {
        Task<IEnumerable<Trn>> GetTrns();
        Task<Trn> GetTrn(int TrnID);
        Task<IEnumerable<Trn>> GetTrnsVno(string Vno,DateTime vdt,int BookNo);
        Task<IEnumerable<Trn>> GetTrnVdtBook(DateTime vdt, int BookNo);
        Task<Trn[]> GetMaxVNoMonthlyYearly(string monthOrYear,DateTime vdt, int BookNo);
        Task<Trn> AddTrn(Trn trn);
        Task<Trn> UpdateTrn(Trn trn);
        Task<Trn> DeleteTrn(int TrnID);
    }
}
