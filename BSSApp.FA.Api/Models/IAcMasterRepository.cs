using BSSApp.FA.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
        Task<AcMaster[]> UpdateAcMasterAuthorization_sp(int AcMasterId, string AuthoBy, Boolean AuthoAc, DateTime AuthoDate);
        //Task<AcMaster> UpdatePatchAcMaster(int AcMasterId,[FromBody]JsonPatchDocument<AcMaster> patchDocument);
    }
}
