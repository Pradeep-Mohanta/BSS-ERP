using BSSApp.FA.Models;
using BSSApp.FA.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class DisplayAccountGLViewBase:ComponentBase
    {
        [Parameter]
        public AcMaster AcMaster { get; set; } = new AcMaster();

        //public DateTime Ason;

        [Inject]
        public ITypeMastService TypeMastService { get; set; }
        public List<TypeMast> TypeMasts { get; set; }
        //public string TypeMastID;

        [Inject]
        public IBSheetGroupService BSheetGroupService { get; set; }
        public List<BSheetGroup> BSheetGroups { get; set; }
        //public string BSheetGroupID;

        [Inject]
        public ICostCenterService CostCenterService { get; set; }
        public List<CostCenter> CostCenters { get; set; }
        //public string CostCenterID;
        protected async override Task OnInitializedAsync()
        {
            //Ason = (AcMaster.Ason.ToString() == "1/1/0001 12:00:00 AM" ? DateTime.Today : AcMaster.Ason);
            //TypeMastID = (AcMaster.TypeMastID.ToString() == "0" ? "0" : AcMaster.TypeMastID.ToString());
            //BSheetGroupID = (AcMaster.BSheetGroupID.ToString() == "0" ? "0" : AcMaster.BSheetGroupID.ToString());
            //CostCenterID = (AcMaster.CostCenterID.ToString() == "0" ? "0" : AcMaster.CostCenterID.ToString());

            TypeMasts = (await TypeMastService.GetTypeMasts()).ToList();
            BSheetGroups = (await BSheetGroupService.GetBSheetGroups()).ToList();
            CostCenters = (await CostCenterService.GetCostCenters()).ToList();
        }
    }
}
