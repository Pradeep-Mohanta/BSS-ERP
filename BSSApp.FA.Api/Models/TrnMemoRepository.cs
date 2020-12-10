using BSSApp.FA.Api.Models;
using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api
{
    public class TrnMemoRepository : ITrnMemoRepository
    {
        private readonly AppDbContext appDbContext;

        //private TrnMemo trnMemos=new List<TrnMemo>;
        public TrnMemoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        

        async Task <TrnMemo> ITrnMemoRepository.Add(TrnMemo trnMemo)
        {
            var result=await appDbContext.TrnMemo.AddAsync(trnMemo);
            return result.Entity;
        }
    }
}
