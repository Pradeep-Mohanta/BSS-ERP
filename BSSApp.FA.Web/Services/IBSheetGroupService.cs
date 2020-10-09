using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public interface IBSheetGroupService
    {
        Task<IEnumerable<BSheetGroup>> GetBSheetGroups();
        Task<BSheetGroup> GetBSheetGroup(int id);
    }
}
