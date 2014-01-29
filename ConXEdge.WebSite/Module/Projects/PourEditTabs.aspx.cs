using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConXEdge.WebSite.Module.Projects
{
    public partial class PourEditTabs : System.Web.UI.Page
    {
        protected string pid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                pid = Request["pid"];
            }
        }
    }
}