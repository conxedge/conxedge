using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using M = ConXedge.Model;
using B = ConXEdge.BLL;

namespace ConXEdge.WebSite.Module.HardwareControl
{
    public partial class LoggerTrackChart1 : System.Web.UI.Page
    {
        protected string strNames = string.Empty;
        protected string strTooltips = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                string pid = Request.QueryString["pid"];
                B.PourLocationBLL bllLoc = new B.PourLocationBLL();
                List<M.VwPourLocation> listLoc = bllLoc.GetListByPourID(pid);
                strNames += "[";
                strTooltips += "[";
                foreach (M.VwPourLocation c in listLoc)
                {
                    strNames += string.Format("'{0}|{1}|{2}',", c.Pourid, c.Loggerid, c.ChannelNo);
                    strTooltips += string.Format("'Logger{0}-Channel{1}',", c.LoggerCode, c.ChannelNo);
                }
                if (strNames.Length > 0)
                    strNames = strNames.Remove(strNames.Length - 1, 1);
                strNames += "]";
                if (strTooltips.Length > 0)
                    strTooltips = strTooltips.Remove(strTooltips.Length - 1, 1);
                strTooltips += "]";
            }
        }

        private string RenderChart(List<M.PourLoggerTrack> list)
        {      
            StringBuilder sb = new StringBuilder();
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); 
                
            sb.AppendFormat("[");
            foreach (M.PourLoggerTrack m in list)
            {
                sb.AppendFormat("[{0},{1}],"
                    , (m.CurrentTime - startTime).TotalMilliseconds,m.Temp.ToString("#.##"));
            }
            if (list.Count > 0)
                sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }
    }
}