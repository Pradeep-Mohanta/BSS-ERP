using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSApp.FA.Web.Pages
{
    public class HomeBase: ComponentBase
    {
        public string txtVal { get; set; }
        public string findVal { get; set; }
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        protected void Button_Click()
        {
            CreateUrl(txtVal);
        }
        public void CreateUrl(string val)
        {
            string genUrl = "";
            genUrl = "http://tinyurl.com/api-create.php?url="+val.ToLower();
            System.Net.HttpWebRequest httpWebRequest;
            System.Net.HttpWebResponse httpWebResponse;
            System.IO.StreamReader streamReader;
            string strHtml;
            
            httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(genUrl);
            httpWebRequest.Method = "GET";

            httpWebResponse= (System.Net.HttpWebResponse)httpWebRequest.GetResponse();

            streamReader = new System.IO.StreamReader(httpWebResponse.GetResponseStream());

            strHtml = streamReader.ReadToEnd();

            streamReader.Close();
            httpWebResponse.Close();
            httpWebRequest.Abort();
            findVal =strHtml;
            
        }
    }
}
