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
    public partial class Project2LoggerAdd : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["pid"]))
                {
                    this.hfpid.Value = Request["pid"];
                }
                ddlLogger.Items.Clear();
                ddlLogger.Items.Add(new ListItem("", ""));
                B.LoggerInfoBLL bll = new B.LoggerInfoBLL();
                List<M.LoggerInfo> list = bll.GetList();
                foreach (M.LoggerInfo c in list)
                {
                    ddlLogger.Items.Add(new ListItem(c.LoggerCode, c.Loggerid));
                }
                ddlLogger.SelectedIndex = 0;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.Project2LoggerBLL bll = new B.Project2LoggerBLL();
            M.Project2Logger model = new M.Project2Logger();
            model.Id = Guid.NewGuid().ToString();
            model.Projectid = this.hfpid.Value;
            model.Loggerid = ddlLogger.SelectedItem.Value;
             
            M.Message msg = bll.Add(model);
            if (msg.State == M.MessageState.Success)
            {
                ResponseScript("alert('Save Success!');window.close();");
            }
            else
            {
                ResponseScript(string.Format("alert('Save Failure:{0}');",msg.Msg));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResponseScript(" window.close();");
        }

    }
}