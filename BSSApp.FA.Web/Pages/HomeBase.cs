using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
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
        protected void Button_Clickme()
        {
            string path = @"e:\VS2019Projects\BSS-ERP\BSSApp.FA.Web\Pages\MainEC.razor";
            //string path = @"c:\Temp\MyTest.razor";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("<div class=\"row ml - 1 mr - 1\">");
                    sw.WriteLine("<div class=\"col - sm - 12 text - center btn - gradian1 text - white - 50\">");
                    sw.WriteLine("<h3>ERP System Configuration</h3>");
                    sw.WriteLine("</div>");
                    sw.WriteLine("</div>");
                    sw.WriteLine("<MainERPLayout selectedModule=10></MainERPLayout>");
                }
            }
        }
    }
}
