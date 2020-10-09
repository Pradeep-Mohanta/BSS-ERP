using BSSApp.FA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class AccountGroupMasterRepository : IAccountGroupMasterRepository
    {
        private readonly AppDbContext appDbContext;

        public AccountGroupMasterRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<AccountGroupMaster> GetAccountGroupMaster(int id)
        {
            return await appDbContext.AccountGroupMaster.FirstOrDefaultAsync(g => g.AccountGroupID == id);
        }

        public async Task<List<AccountGroupMaster>> GetAccountGroupMasters()
        {
            return await appDbContext.AccountGroupMaster.ToListAsync();
        }

        //public async Task<List<AccountGroupMaster>> GetAccountGroupMastersWithCode(string GCode)
        public async Task<List<AccountGroupMaster>> GetAccountGroupMastersWithCode(string GCode)
        {
            //IQueryable<AccountGroupMaster> myval;
            int zeroPos = GCode.IndexOf("0");
            string Sub_GCode =GCode.Substring(0, zeroPos+1);
            IQueryable<AccountGroupMaster> query = appDbContext.AccountGroupMaster
                                //.First(x => x.AccountGroupCode == (appDbContext.AccountGroupMaster.Max(y => y.AccountGroupCode.Contains(Sub_GCode))));
                                .Where(a =>a.AccountGroupCode.Contains(Sub_GCode))
                                .OrderByDescending(a => a.AccountGroupCode)
                                .Take(1);

            //IQueryable<AccountGroupMaster> query = from Acct in appDbContext.AccountGroupMaster
            //                                       where Acct.AccountGroupCode.Contains(Sub_GCode)
            //                                       select Acct;

            return await query.ToListAsync();
            //return await myval;
        }
    }
}
