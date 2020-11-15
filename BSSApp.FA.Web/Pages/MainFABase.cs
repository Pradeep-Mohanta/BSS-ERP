using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class MainFABase:ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public IModuleObjectMasterService ModuleObjectMasterService { get; set; }
        public IEnumerable<ModuleObjectMaster> ModuleObjectMaster { get; set; }
        public IEnumerable<ModuleObjectMaster> ModuleObjectMasterTrans { get; set; }

        public IEnumerable<ModuleObjectMaster> ModuleObjectMasterRpt { get; set; }
        public string currentUserName { get; set; }
        protected async override Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;
            currentUserName = authenticationState.User.Identity.Name;

            ModuleObjectMaster = await ModuleObjectMasterService.GetModuleObjects_user_ModuleWise(currentUserName, 1, "Master");
            ModuleObjectMasterTrans = await ModuleObjectMasterService.GetModuleObjects_user_ModuleWise(currentUserName, 1, "Tran");
            ModuleObjectMasterRpt = await ModuleObjectMasterService.GetModuleObjects_user_ModuleWise(currentUserName, 1, "Report");

            //ModuleObjectMaster = await ModuleObjectMasterService.GetModuleObjects_user_ModuleWise("pradeep", 1, "Master");
            //ModuleObjectMasterTrans = await ModuleObjectMasterService.GetModuleObjects_user_ModuleWise("pradeep", 1, "Tran");
            //ModuleObjectMasterRpt = await ModuleObjectMasterService.GetModuleObjects_user_ModuleWise("pradeep", 1, "Report");
        }
    }
}
