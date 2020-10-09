using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Services
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStates();
        Task<State> GetState(int Id);
        Task<IEnumerable<State>> GetStatesForCountry(int CID);
    }
}
