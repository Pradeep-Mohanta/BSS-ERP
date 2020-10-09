using BSSApp.FA.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class DisplayAccountFooterBase:ComponentBase
    {
        [Parameter]
        public AcMaster AcMaster { get; set; } = new AcMaster();

        [Parameter]
        public Boolean Disable_Flag { get; set; }

        public DateTime CreatedDate;
        public DateTime AuthorisedDate;

        protected async override Task OnInitializedAsync()
        {
            CreatedDate =(AcMaster.CreatedDate.ToString() == "1/1/0001 12:00:00 AM" ? DateTime.Today : AcMaster.CreatedDate);
            AuthorisedDate = (AcMaster.AuthorisedDate.ToString() == "1/1/0001 12:00:00 AM" ? DateTime.Today : AcMaster.AuthorisedDate);
            await Task.Delay(10);
        }
    }
}
