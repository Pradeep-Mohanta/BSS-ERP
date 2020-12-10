using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public interface ITrnMemoService
    {
        Task<TrnMemo> AddTrnMemo(TrnMemo NewTrnMemo);
        //Task<IEnumerable<TrnMemo>> AddTrnMemo_ext(Trn trnMemoNew);
    }
}
