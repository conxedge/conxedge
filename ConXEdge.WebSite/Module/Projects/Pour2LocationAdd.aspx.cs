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
    public partial class Pour2LocationAdd : ConXEdge.WebSite.AppCode.PageBase
    {
        protected string projectId = string.Empty;
        protected string PourType = string.Empty;
        protected string PourID = string.Empty;
        protected string strLoggingStarted = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {                
                if (!string.IsNullOrEmpty(Request["pourid"]))
                {
                    this.hfpid.Value = Request["pourid"];
                    B.PourInfoBLL bll = new B.PourInfoBLL();                 
                    M.PourInfo model = bll.GetModelByID(this.hfpid.Value);
                    projectId = model.Projectid;
                    PourType = model.PourType;
                    PourID = model.Pourid;

                    if (model.PourType == "2")
                    {
                        strLoggingStarted = "<tr><th>Logging Start:</th><td colspan='3'>";
                        strLoggingStarted +="<select id='ddlLoggingStart' class='easyui-combobox' style='width: 350px;' panelheight='150px' required='true' runat='server'>";
                        strLoggingStarted += "</select>";
                        strLoggingStarted += "</td></tr>";
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            B.PourLocationBLL bll = new B.PourLocationBLL();
            M.PourLocation model = new M.PourLocation();
            model.Id = Guid.NewGuid().ToString();
            model.Pourid = this.hfpid.Value;
            model.Locationid = LocationID.Text;
            model.LocationDescription = LocationDescription.Text;
            model.Details = Details.Text;
            model.Loggerid = hdLogger.Value;
            model.ChannelNo = int.Parse(hdChannelNo.Value);
            model.MonitorType = hdMonitorType.Value;
            if(!string.IsNullOrEmpty(hdLoggingStart.Value))
                model.LogginStart = Convert.ToDateTime(hdLoggingStart.Value);

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