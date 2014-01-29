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
    public partial class Pour2TargetEdit : ConXEdge.WebSite.AppCode.PageBase
    {
        protected string pourid = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            B.Pour2TargetBLL bll = new B.Pour2TargetBLL();
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                M.Pour2Target m = bll.GetModelByID(Request["pid"]);
                this.hfpid.Value = m.Id;
                this.hfPourID.Value = m.Pourid;
                this.Purpose.Text = m.Purpose;
                this.Target.Text = m.Target.ToString();
                pourid = m.Pourid;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.Pour2TargetBLL bll = new B.Pour2TargetBLL();
            M.Pour2Target model = bll.GetModelByID(this.hfpid.Value);
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
            ResponseScript(" window.close();");
        }

    }
}