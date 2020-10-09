using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class FetchModalDataBase:ComponentBase
    {
        [CascadingParameter] 
        BlazoredModalInstance BlazoredModal { get; set; }
        
        [Parameter] 
        public string Message { get; set; }= "Data Update Successfully";


        protected void Cancel() => BlazoredModal.Close();
        
    }
}
