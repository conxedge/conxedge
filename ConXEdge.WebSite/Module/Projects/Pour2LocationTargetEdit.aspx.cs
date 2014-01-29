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
    public partial class Pour2LocationTargetEdit : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            B.PourLocation2TargetBLL bll = new B.PourLocation2TargetBLL();
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                M.VwPourLocation2Target m = bll.GetViewModelByID(Request["pid"]);
                this.hfpid.Value = m.Id;
                this.hfPourID.Value = m.PourLocationid;
                this.Purpose.Text = m.Purpose;
                this.Target.Text = m.Target.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.PourLocation2TargetBLL bll = new B.PourLocation2TargetBLL();
            M.PourLocation2Target model = bll.GetModelByID(this.hfpid.Value);
            model.Target = int.Parse(this.Target.Text);

            M.Message msg = bll.Update(model);
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