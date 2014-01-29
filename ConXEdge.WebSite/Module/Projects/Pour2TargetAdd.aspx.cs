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
    public partial class Pour2TargetAdd : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["pourid"]))
                {
                       this.hfpid.Value = Request["pourid"];
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.Pour2TargetBLL bll = new B.Pour2TargetBLL();
            M.Pour2Target model = new M.Pour2Target();
            model.Id = Guid.NewGuid().ToString();
            model.Pourid = this.hfpid.Value;
            model.Purpose = Purpose.Text;
            model.Target = int.Parse(Target.Text);
             
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