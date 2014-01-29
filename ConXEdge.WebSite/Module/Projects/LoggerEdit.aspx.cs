using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using M = ConXedge.Model;
using B = ConXEdge.BLL;

namespace ConXEdge.WebSite.Module.Projects
{
    public partial class LoggerEdit : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            B.LoggerInfoBLL bll = new B.LoggerInfoBLL();
            SerialNumber.Enabled = false;
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                M.LoggerInfo m = bll.GetModelByID(Request["pid"]);
                this.hfpid.Value = m.Loggerid;
                this.Code.Text = m.LoggerCode;
                this.SerialNumber.Text = m.SerialNumber;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.LoggerInfoBLL bll = new B.LoggerInfoBLL();
            M.LoggerInfo model = bll.GetModelByID(this.hfpid.Value);
            model.LoggerCode = Code.Text;
             
            M.Message msg = bll.Update(model);
            if (msg.State == M.MessageState.Success)
            {
                ResponseScript("alert('Edit Success!');window.close();");
            }
            else
            {
                ResponseScript(string.Format("alert('Edit Failure:{0}');", msg.Msg));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResponseScript("window.location.href='LoggerList.aspx';");
        }

    }
}