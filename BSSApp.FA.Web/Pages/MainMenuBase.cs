using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class MainMenuBase:ComponentBase
    {
        [Inject]
        public IModuleObjectMasterService ModuleObjectMasterService { get; set; }
        public IEnumerable<ModuleObjectMaster> ModuleObjectMaster { get; set; }
        public IEnumerable<ModuleObjectMaster> ModuleObjectMasterTrans { get; set; }

        public IEnumerable<ModuleObjectMaster> ModuleObjectMasterRpt { get; set; }

        [Parameter]
        public  string clickModule { get; set; }

        [Parameter]
        public string login_usr { get; set; }
        protected async override Task OnInitializedAsync()
        {
            if (clickModule == "FA")
            {
                ModuleObjectMaster = await ModuleObjectMasterService.GetModuleObjects_user_ModuleWise(login_usr, 1, "Master");
                ModuleObjectMasterTrans = await ModuleObjectMasterService.GetModuleObjects_user_ModuleWise(login_usr, 1, "Tran");
                ModuleObjectMasterRpt = await ModuleObjectMasterService.GetModuleObjects_user_ModuleWise(login_usr, 1, "Report");
            }
        }
    }
}
