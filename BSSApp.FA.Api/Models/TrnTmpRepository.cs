using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class TrnTmpRepository : ITrnTmpRepository
    {
        private List<TrnTmp> _TrnTmpList;
        public TrnTmp AddTrnTmp(TrnTmp trnTmp)
        {
           _TrnTmpList.Add(trnTmp);
            return trnTmp;
        }
    }
}
