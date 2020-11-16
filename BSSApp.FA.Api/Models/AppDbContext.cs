using BSSApp.FA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Api.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
            {
            }
        public DbSet<AcMaster> AcMasters { get; set; }
        public DbSet<BSheetGroup> BSheetGroups { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TypeMast> TypeMasts { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<SubLedger> SubLedgers { get; set; }
        public DbSet<AccountGroupMaster> AccountGroupMaster { get; set; }
        public DbSet<ModuleMaster> ModuleMaster { get; set; }
        public DbSet<ModuleObjectMaster> ModuleObjectMaster { get; set; }
        public DbSet<ModuleObjectMasterR> ModuleObjectMasterR { get; set; }
        public DbSet<UserObjectAssignMaster> UserObjectAssignMaster { get; set; }
        public DbSet<UserAssignModule> UserAssignModule { get; set; }
    }
}
