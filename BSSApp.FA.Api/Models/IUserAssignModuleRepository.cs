﻿using BSSApp.FA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public interface IUserAssignModuleRepository
    {
        Task<IEnumerable<UserAssignModule>> GetUserAssignModules();
        Task<UserAssignModule> GetUserAssignModule(int id);
        Task<IEnumerable<UserAssignModule>> GetUserAssignModules_userName(string userName);
    }
}
