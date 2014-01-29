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
    public partial class Pour2LevelAdd : ConXEdge.WebSite.AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["pid"]))
                {
                    this.hfpid.Value = Request["pid"];
                }
                ddlLevel.Items.Clear();
                ddlLevel.Items.Add(new ListItem("", ""));
                B.LevelInfoBLL bll = new B.LevelInfoBLL();
                List<M.LevelInfo> list = bll.GetList();
                foreach (M.LevelInfo c in list)
                {
                    ddlLevel.Items.Add(new ListItem(c.LevelName, c.Levelid));
                }
                ddlLevel.SelectedIndex = 0;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.Pour2LevelBLL bll = new B.Pour2LevelBLL();
            M.Pour2Level model = new M.Pour2Level();
            model.Id = Guid.NewGuid().ToString();
            model.Pourid = this.hfpid.Value;
            model.Levelid = ddlLevel.SelectedItem.Value;
             
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