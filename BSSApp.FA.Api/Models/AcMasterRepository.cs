using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class AcMasterRepository : IAcMasterRepository
    {
        private readonly AppDbContext appDbContext;

        public AcMasterRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        //public async Task<AcMaster> AddAcMaster(AcMaster acMaster)
        //{
        //}

        async Task<AcMaster> IAcMasterRepository.AddAcMaster(AcMaster acMaster)
        {
            var result = await appDbContext.AcMasters.AddAsync(acMaster);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
        async Task<AcMaster> IAcMasterRepository.DeleteAcMaster(int AcMasterId)
        {
            var result=await appDbContext.AcMasters
                .FirstOrDefaultAsync(a => a.AcMasterID == AcMasterId);
            if (result != null)
            {
                appDbContext.AcMasters.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        async Task<IEnumerable<AcMaster>> IAcMasterRepository.GetAcMasters()
        {
            return await appDbContext.AcMasters.ToListAsync();
        }

        async Task<AcMaster> IAcMasterRepository.GetAcMaster(int AcMasterId)
        {
            return await appDbContext.AcMasters
                .Include(a => a.Ledger)
                .Include(a => a.TypeMast)
                .Include(b => b.Country)
                .Include(c => c.CostCenter)
                .Include(x => x.BSheetGroup)
                .Include(y => y.State)
                .FirstOrDefaultAsync(a => a.AcMasterID == AcMasterId);
        }

        async Task<AcMaster> IAcMasterRepository.UpdateAcMaster(AcMaster acMaster)
        {
            var result=await appDbContext.AcMasters
                    .FirstOrDefaultAsync(a => a.AcMasterID == acMaster.AcMasterID);
            if (result != null)
            {
                result.LedgerCode = acMaster.LedgerCode;
                result.Acno = acMaster.Acno;
                result.Acname = acMaster.Acname;
                result.Compcode = acMaster.Compcode;
                result.Opbal = acMaster.Opbal;
                result.Ason = acMaster.Ason;
                result.DrCr = acMaster.DrCr;
                result.Acad1 = acMaster.Acad1;
                result.Acad2 = acMaster.Acad2;
                result.Acad3 = acMaster.Acad3;
                result.Acad4 = acMaster.Acad4;
                result.City = acMaster.City;
                result.Pin = acMaster.Pin;
                result.TypeMastID = acMaster.TypeMastID;
                result.BSheetGroupID = acMaster.BSheetGroupID;
                result.Descr = acMaster.Descr;
                result.Panno = acMaster.Panno;
                result.Tanno = acMaster.Tanno;
                result.STaxno = acMaster.STaxno;
                result.Tin_VatNo = acMaster.Tin_VatNo;
                result.Phone = acMaster.Phone;
                result.Mobile1 = acMaster.Mobile1;
                result.Mobile2 = acMaster.Mobile2;
                result.FaxNo = acMaster.FaxNo;
                result.EMail = acMaster.EMail;
                result.ContactPerson = acMaster.ContactPerson;
                result.GroupSeries = acMaster.GroupSeries;
                result.LimitAmount = acMaster.LimitAmount;
                result.CreditAmount = acMaster.CreditAmount;
                result.Dob = acMaster.Dob;
                result.StateID = acMaster.StateID;
                result.CountryID = acMaster.CountryID;
                result.CreatedBy = acMaster.CreatedBy;
                result.CreatedDate = acMaster.CreatedDate;
                result.AuthorisedBy = acMaster.AuthorisedBy;
                result.AuthorisedAc = acMaster.AuthorisedAc;
                result.AuthorisedDate = acMaster.AuthorisedDate;
                result.CostCenterID = acMaster.CostCenterID;
                result.CorporateName = acMaster.CorporateName;
                result.GSTCode = acMaster.GSTCode;
                result.ServiceCode = acMaster.ServiceCode;
                result.AdharNo = acMaster.AdharNo;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<AcMaster>> AccountSearch(string ledgerCode)
        {
            IQueryable<AcMaster> query = appDbContext.AcMasters
                                .Include(a => a.Ledger)
                                .Where(a => a.LedgerCode.Contains(ledgerCode))
                                .OrderBy(a=>a.Acname);
            //IQueryable<AcMaster> query=appDbContext.AcMasters.Where(a=>a.Acname.Contains(AcName));
            //IQueryable<AcMaster> query = appDbContext.AcMasters.Where(a => a.LedgerCode==ledgerCode && a.Acname.Contains(AcName));
            //if (string.IsNullOrEmpty(ledgerCode))
            //{
            //    query = appDbContext.AcMasters.Where(a=>a.LedgerCode==ledgerCode && a.Acname.Contains(AcName));
            //}

            //if (!string.IsNullOrEmpty(AcName))
            //{
            //    query = query.Where(a => a.Acname.Contains(AcName));
            //}
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<AcMaster>> LedgerOfAccounts(string ledgerCode)
        {
            IQueryable<AcMaster> query = appDbContext.AcMasters.Where(a => a.LedgerCode.Contains(ledgerCode));
            //IQueryable<AcMaster> query=appDbContext.AcMasters.Where(a=>a.Acname.Contains(AcName));
            //IQueryable<AcMaster> query = appDbContext.AcMasters.Where(a => a.LedgerCode==ledgerCode && a.Acname.Contains(AcName));
            //if (string.IsNullOrEmpty(ledgerCode))
            //{
            //    query = appDbContext.AcMasters.Where(a=>a.LedgerCode==ledgerCode && a.Acname.Contains(AcName));
            //}

            //if (!string.IsNullOrEmpty(AcName))
            //{
            //    query = query.Where(a => a.Acname.Contains(AcName));
            //}
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<AcMaster>> GetMaxAccountNo(string gcode)
        {
            int zeroPos = gcode.IndexOf("0");
            string sub_gcode = gcode.Substring(0, zeroPos + 1);
            IQueryable<AcMaster> query=appDbContext.AcMasters.Where(a => a.Acno.Contains(sub_gcode))
                                  .OrderByDescending(a=>a.Acno)
                                  .Take(1);
            return await query.ToListAsync();
        }

        public async Task<AcMaster[]> GetMaxAcNo_sp(string gcode)
        {
            AcMaster[] acs;
            acs = await appDbContext.AcMasters.FromSqlRaw("execute GetMaxAcno @p0", gcode).ToArrayAsync() ;
            return acs;
        }

    }
}
