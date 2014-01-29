using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.UI;
using ConXedge.Model.Protocol;
using ConXEdge.Nhibernate;
using NHibernate.Criterion;
using B = ConXEdge.BLL;
using M = ConXedge.Model;

namespace ConXEdge.WebSite.Module.HardwareControl
{
    public partial class OperationHandler : AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ClearContent();
            string sType = Request["sType"];
            switch (sType)
            {
                case "GetEquivalentAge": Response.Write(GetEquivalentAge(Request["pourid"])); break;
                case "GetChart1Data": Response.Write(GetChart1Data(Request["pid"])); break;
                case "GetChart2Data": Response.Write(GetChart2Data(Request["pid"])); break;
                default: break;
            }
            Response.End();
        }

        /// <summary>
        /// 获取Equivalent Age
        /// </summary>
        /// <param name="pourid"></param>
        /// <returns></returns>
        private string GetEquivalentAge(string pourid)
        {
            StringBuilder sb = new StringBuilder();
            B.PourLoggerStatusBLL bllStatus = new B.PourLoggerStatusBLL();
            List<M.PourLoggerStatus> listStatus = bllStatus.GetListByPourID(pourid);

            B.PourTargetEquivalentAgeBLL bll = new B.PourTargetEquivalentAgeBLL();
            List<M.VwPourTargetEquivalentAge> listAge = bll.GetListByPourID(pourid);

            string CurrentLoggerCode = "";
            int CurrentChannNo = -1;
            
            foreach (M.VwPourTargetEquivalentAge child in listAge)
            {
                if (CurrentLoggerCode != child.LoggerCode
                    || CurrentChannNo != child.ChannelNo)
                {
                    if (!string.IsNullOrEmpty(CurrentLoggerCode))
                    {
                        sb.AppendFormat(";");
                    }
                    CurrentLoggerCode = child.LoggerCode;
                    CurrentChannNo = child.ChannelNo;                    
                    foreach (M.PourLoggerStatus c in listStatus)
                    {
                        if (c.Pourid == child.Pourid
                            && c.Loggerid == child.Loggerid
                            && c.ChannelNo == child.ChannelNo)
                        {
                            sb.AppendFormat("{0}|{1}|{2}",
                                c.LoggingStarted==null?"": ((DateTime)c.LoggingStarted).ToString("dd/MM/yyyy HH:mm:ss")
                                , c.Temp
                                , c.EquivalentAge);
                        }
                    }                    
                }
                sb.AppendFormat("|{0}|{1}", child.CurrentTime, child.Temp);
            }
            sb.AppendFormat(";");
            return sb.ToString();
        }

        /// <summary>
        /// 获取Chart1-Temp ver Elapsed Time数据
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        private string GetChart1Data(string pid)
        {
            StringBuilder sb = new StringBuilder();
            string[] sTmp = pid.Split('|');

            B.PourLoggerTrackBLL bll = new B.PourLoggerTrackBLL();
            List<M.PourLoggerTrack> listResult = bll.GetListByPourID(sTmp[0], sTmp[1], sTmp[2]);

            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));

            sb.AppendFormat("[");
            foreach (M.PourLoggerTrack m in listResult)
            {
                sb.AppendFormat("[{0},{1}],"
                    , (m.CurrentTime - startTime).TotalMilliseconds, m.Temp);
            }
            if (listResult.Count > 0)
                sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// 获取Chart2-EA ver Elapsed Time数据
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        private string GetChart2Data(string pid)
        {
            StringBuilder sb = new StringBuilder();
            string[] sTmp = pid.Split('|');

            B.PourLoggerTrackBLL bll = new B.PourLoggerTrackBLL();
            List<M.PourLoggerTrack> listResult = bll.GetListByPourID(sTmp[0], sTmp[1], sTmp[2]);

            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));

            sb.AppendFormat("[");
            foreach (M.PourLoggerTrack m in listResult)
            {
                sb.AppendFormat("[{0},{1}],"
                    , (m.CurrentTime - startTime).TotalMilliseconds, m.EquivalentAge);
            }
            if (listResult.Count > 0)
                sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }
    }
}
