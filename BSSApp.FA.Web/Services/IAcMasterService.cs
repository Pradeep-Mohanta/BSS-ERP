using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public interface IAcMasterService
    {
        Task<IEnumerable<AcMaster>> GetAcMasters();
        Task<AcMaster> GetAcMaster(int AcMasterId);
        Task<IEnumerable<AcMaster>> GetMaxAccountNo(string gcode);
        Task<IEnumerable<AcMaster>> LedgerOfAccounts(string Lcd);
        Task<AcMaster[]> GetMaxAcNo_sp(string gcode);
        Task<AcMaster> UpdateAcMaster(AcMaster updatedAcmaster);
        Task<AcMaster> AddAcMaster(AcMaster NewAccountMaster);
    }
}
