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
    public partial class ProjectEdit : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            B.ProjectInfoBLL bll = new B.ProjectInfoBLL();
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                M.ProjectInfo m = bll.GetModelByID(Request["pid"]);
                this.hfpid.Value = m.Projectid;
                this.Name.Text = m.ProjectName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.ProjectInfoBLL bll = new B.ProjectInfoBLL();
            M.ProjectInfo model = bll.GetModelByID(this.hfpid.Value);
            model.ProjectName = Name.Text;
             
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
            ResponseScript("window.location.href='ProjectList.aspx';");
        }

    }
}