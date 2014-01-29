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
    public partial class DefaultTargetEdit : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            B.DefaultTargetBLL bll = new B.DefaultTargetBLL();
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                M.DefaultTarget m = bll.GetModelByID(Request["pid"]);
                this.hfpid.Value = m.Targetid;
                this.Purpose.Text = m.Purpose;
                this.Target.Text = m.Target.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.DefaultTargetBLL bll = new B.DefaultTargetBLL();
            M.DefaultTarget model = bll.GetModelByID(this.hfpid.Value);
            model.Purpose = Purpose.Text;
            model.Target = int.Parse(Target.Text);
             
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
            ResponseScript("window.location.href='DefaultTargetList.aspx';");
        }

    }
}