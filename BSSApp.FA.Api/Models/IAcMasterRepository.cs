using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public interface IAcMasterRepository
    {
        Task<IEnumerable<AcMaster>> AccountSearch(string ledgerCode);
        Task<IEnumerable<AcMaster>> LedgerOfAccounts(string ledgerCode);
        Task<IEnumerable<AcMaster>> GetMaxAccountNo(string gcode);
        Task<AcMaster[]> GetMaxAcNo_sp(string gcode);
        Task<IEnumerable<AcMaster>> GetAcMasters();
        Task<AcMaster> GetAcMaster(int AcMasterId);
        Task<AcMaster> AddAcMaster(AcMaster acMaster);
        Task<AcMaster> UpdateAcMaster(AcMaster acMaster);
        Task<AcMaster> DeleteAcMaster(int AcMasterId);
    }
}
