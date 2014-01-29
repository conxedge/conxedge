using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using M = ConXedge.Model;
using B = ConXEdge.BLL;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;

namespace ConXEdge.WebSite.Module.Projects
{
    public partial class LoggerAdd : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.LoggerInfoBLL bll = new B.LoggerInfoBLL();
            M.LoggerInfo model = new M.LoggerInfo();
            M.Message msg = bll.IsReg(SerialNumber.Text);
            if (msg.State == M.MessageState.Failure)
            {
                ResponseScript("alert('Serial Number has been used!');");
                return;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["LoggerServiceUrl"]);

            // Blocking call! 
            HttpResponseMessage response = client.GetAsync("api/loggers").Result;
            if (response.IsSuccessStatusCode)
            {
                var loggerStatus = response.Content.ReadAsStringAsync();
                if (!loggerStatus.Result.Contains(string.Format(":\"{0}\"", SerialNumber.Text)))
                {
                    ResponseScript("alert('Serial Number Not Exists!');");
                }
                else
                {
                    model.Loggerid = Guid.NewGuid().ToString();
                    model.LoggerCode = Code.Text;
                    model.SerialNumber = SerialNumber.Text;
                    model.Companyid = base.CurrentUserInfo.Companyid;

                    msg = bll.Add(model);
                    if (msg.State == M.MessageState.Success)
                    {
                        ResponseScript("alert('Save Success!');window.close();");
                    }
                    else
                    {
                        ResponseScript(string.Format("alert('Save Failure:{0}');", msg.Msg));
                    }
                }
            }
            else
            {
                ResponseScript("alert('Can't get register infomation!');");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResponseScript("window.location.href='LoggerList.aspx';");
        }

    }
}