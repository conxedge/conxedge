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
    public partial class LoggerTrackChart2 : System.Web.UI.Page
    {
        protected string strNames = string.Empty;
        protected string strTooltips = string.Empty;
        protected string strPlotLines = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                string pid = Request.QueryString["pid"];
                B.PourLocationBLL bllLoc = new B.PourLocationBLL();
                List<M.VwPourLocation> listLoc = bllLoc.GetListByPourID(pid);
                strNames += "[";
                strTooltips += "[";
                strPlotLines += "[";
                foreach (M.VwPourLocation c in listLoc)
                {
                    if (c.MonitorType == "1")
                    {
                        strNames += string.Format("'{0}|{1}|{2}',", c.Pourid, c.Loggerid, c.ChannelNo);
                        strTooltips += string.Format("'Logger{0}-Channel{1}',", c.LoggerCode, c.ChannelNo);
                        B.PourLocation2TargetBLL bllTarget = new B.PourLocation2TargetBLL();
                        List<M.PourLocation2Target> listTarget = bllTarget.GetListByLocationID(c.Id);
                        if (chkShowTarget.Checked)
                        {
                            foreach (M.PourLocation2Target c1 in listTarget)
                            {
                                string tmp = string.Format("Logger{0}-Channel{1}-Target[{2}]", c.LoggerCode, c.ChannelNo, c1.Target);
                                strPlotLines += "{ value: " + c1.Target + ",color:'red',dashStyle: 'shortdash',width: 2,label: {text: '" + tmp + "'}},";
                            }
                        }
                    }
                }
                if (strNames.Length > 1)
                    strNames = strNames.Remove(strNames.Length - 1, 1);
                strNames += "]";
                if (strTooltips.Length > 1)
                    strTooltips = strTooltips.Remove(strTooltips.Length - 1, 1);
                strTooltips += "]";
                if (strPlotLines.Length > 1)
                    strPlotLines = strPlotLines.Remove(strPlotLines.Length - 1, 1);
                strPlotLines += "]";
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

        protected void chkShowTarget_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}