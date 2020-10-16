using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BioScan.Components
{
    public class BssMessagePopupBase:ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public string cancelButtonText { get; set; } ="Cancel";

        [Parameter]
        public bool DisplayCancelButton { get; set; } = true;

        [Parameter]
        public bool DisplayOKlButton { get; set; } = true;


        [Parameter]
        public string OKButtonText { get; set; } = "OK";

        [Parameter]
        public string confirmationTitle { get; set; } = "User Message";

        [Parameter]
        public string confirmationMessage { get; set; } = "Want to take action";
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        public void show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(value);
        }
    }

}
