using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConXEdge.WebSite.Module.HardwareControl
{
    public partial class LoggerTrackTabs : System.Web.UI.Page
    {
        public string pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["pid"] != null)
            {
                pid = Request["pid"];
            }
        }
    }
}