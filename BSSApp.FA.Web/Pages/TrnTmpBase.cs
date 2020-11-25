using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class TrnTmpBase:ComponentBase
    {
        public IEnumerable<TrnTmp> TrnsTmp { get; set; }

    }
}
