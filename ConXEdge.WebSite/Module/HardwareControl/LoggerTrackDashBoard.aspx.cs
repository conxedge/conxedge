using System;
using System.Collections.Generic;
using System.Text;
using B = ConXEdge.BLL;
using M = ConXedge.Model;

namespace ConXEdge.WebSite.Module.HardwareControl
{
    public partial class LoggerTrackDashBoard : ConXEdge.WebSite.AppCode.PageBase
    {
        public string TableDetails;
        public int ColumnCount;
        public int TargetCount;
        private StringBuilder sb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                B.PourInfoBLL bll = new B.PourInfoBLL();
                M.VwPourInfo model = bll.GetViewModelByID(Request.QueryString["pid"]);
                if (model != null)
                {
                    this.hfpid.Value = model.Pourid;

                    B.PourLocationBLL bllLoc = new B.PourLocationBLL();
                    List<M.VwPourLocation> listLoc = bllLoc.GetListByPourID(model.Pourid);

                    //后台组装表格输出到前台
                    ColumnCount = listLoc.Count + 5;

                    sb = new StringBuilder();
                    sb.Append("<table class='t2'>");
                    #region 第一个表格
                    //Logger / Channel:
                    sb.Append("<tr>");
                    sb.Append("<th colspan='5'>");
                    sb.Append("Logger / Channel:");
                    sb.Append("</th>");
                    foreach (M.VwPourLocation c in listLoc)
                    {
                        sb.Append("<th>");
                        sb.AppendFormat("{0} / {1}", c.LoggerCode, c.ChannelNo);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    //Pour Started:
                    sb.Append("<tr>");
                    sb.Append("<td colspan='5'>");
                    sb.Append("Pour Started:");
                    sb.Append("</td>");
                    for (int i = 0; i < ColumnCount - 5; i++)
                    {
                        sb.Append("<th>");
                        sb.AppendFormat("{0}", model.Started.ToString("dd/MM/yyyy HH:mm:ss"));
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    //Pour Finnished:
                    sb.Append("<tr>");
                    sb.Append("<td colspan='5'>");
                    sb.Append("Pour Finnished:");
                    sb.Append("</td>");
                    for (int i = 0; i < ColumnCount - 5; i++)
                    {
                        sb.Append("<th>");
                        sb.AppendFormat("{0}", model.Finished.ToString("dd/MM/yyyy HH:mm:ss"));
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    //Monitor Type:
                    sb.Append("<tr>");
                    sb.Append("<td colspan='5'>");
                    sb.Append("Monitor Type:");
                    sb.Append("</td>");
                    foreach (M.VwPourLocation c in listLoc)
                    {
                        sb.Append("<th>");
                        sb.AppendFormat("{0}", c.MonitorType == "1" ? "Equivalent Age" : "Temperature Only");
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    //Location:
                    sb.Append("<tr>");
                    sb.Append("<th colspan='5'>");
                    sb.Append("Location:");
                    sb.Append("</th>");
                    foreach (M.VwPourLocation c in listLoc)
                    {
                        sb.Append("<th>");
                        sb.AppendFormat("{0}", c.LocationDescription);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    //Logging Started:
                    sb.Append("<tr>");
                    sb.Append("<td colspan='5'>");
                    sb.Append("Logging Started:");
                    sb.Append("</td>");
                    for (int i = 0; i < ColumnCount - 5; i++)
                    {
                        sb.Append("<th>");
                        //要重新替换成events获取的数据
                        sb.AppendFormat("<input id='LoggingStarted{0}' type='text' value='' />"
                            , i);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    #endregion 第一个表格

                    #region 分割行
                    sb.Append("<tr>");
                    sb.AppendFormat("<td colspan='{0}'>", ColumnCount);
                    sb.Append("</tr>");
                    #endregion 分割行

                    #region Current Performance:
                    sb.Append("<tr>");
                    sb.Append("<th colspan='2' rowspan='4'>");
                    sb.Append("Current Performance:");
                    sb.Append("</th>");
                    //Date & Time:
                    sb.Append("<th colspan='2'>");
                    sb.Append("Date & Time:");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("</th>");
                    for (int i = 0; i < ColumnCount - 5; i++)
                    {
                        sb.Append("<th>");
                        sb.AppendFormat("<input id='DateTime{0}' type='text' value='' />"
                            , i);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    //Elapsed Time:
                    sb.Append("<tr>");
                    sb.Append("<th colspan='2' >");
                    sb.Append("Elapsed Time:");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("(hh:mm)");
                    sb.Append("</th>");
                    for (int i = 0; i < ColumnCount - 5; i++)
                    {
                        sb.Append("<th>");
                        sb.AppendFormat("<input id='ElapsedTime{0}' type='text' value='' />"
                            , i);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    //Temperature:
                    sb.Append("<tr>");
                    sb.Append("<th colspan='2' >");
                    sb.Append("Temperature:");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("(℃)");
                    sb.Append("</th>");
                    for (int i = 0; i < ColumnCount - 5; i++)
                    {
                        sb.Append("<th>");
                        sb.AppendFormat("<input id='Temperature{0}' type='text' value='' />"
                            , i);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    //Equivalent Age:
                    sb.Append("<tr>");
                    sb.Append("<th colspan='2' >");
                    sb.Append("Equivalent Age:");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("(℃/hrs)");
                    sb.Append("</th>");
                    for (int i = 0; i < ColumnCount - 5; i++)
                    {
                        sb.Append("<th>");
                        if (listLoc[i].MonitorType == "1")
                        {
                            sb.AppendFormat("<input id='EquivalentAge{0}' type='text' value='90' />"
                                , i);
                        }
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    #endregion Current Performance:

                    #region 分割行
                    sb.Append("<tr>");
                    sb.AppendFormat("<td colspan='{0}'>", ColumnCount);
                    sb.Append("</tr>");
                    #endregion 分割行

                    #region Performance Against Targets
                    sb.Append("<tr>");
                    sb.Append("<th>");
                    sb.Append("Target");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("Purpose");
                    sb.Append("</th>");
                    sb.AppendFormat("<th colspan='{0}'>", ColumnCount - 2);
                    sb.Append("Performance Against Targets");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    B.Pour2TargetBLL bllTarget = new B.Pour2TargetBLL();
                    List<M.Pour2Target> listTarget = bllTarget.GetListByPourID(model.Pourid);
                    TargetCount = listTarget.Count;
                    for (int i = 0; i < listTarget.Count; i++)
                    {
                        sb.Append("<tr>");
                        sb.Append("<th rowspan='5'>");
                        sb.Append(i + 1);
                        sb.Append("</th>");
                        sb.Append("<th rowspan='5'>");
                        sb.Append(listTarget[i].Purpose);
                        sb.Append("</th>");
                        sb.Append("<td colspan='2'>");
                        sb.Append("Target Equivalent Age (TEA):");
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("(℃/hrs)");
                        sb.Append("</td>");
                        List<M.VwPourLocation2Target> listLocationTarget
                                = bllTarget.GetTargetListByPourID(model.Pourid);
                        for (int j = 0; j < ColumnCount - 5; j++)
                        {
                            sb.Append("<td>");
                            foreach (M.VwPourLocation2Target c in listLocationTarget)
                            {
                                if (c.Pour2Targetid == listTarget[i].Id
                                    && c.LoggerCode == listLoc[j].LoggerCode
                                    && c.ChannelNo == listLoc[j].ChannelNo)
                                {
                                    if (listLoc[j].MonitorType == "1")
                                    {
                                        sb.AppendFormat("<input id='Target{0}Loc{1}EquivalentAge' type='text' value='{2}' />"
                                , i, j, c.Target);
                                    }
                                    break;
                                }
                            }
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");

                        sb.Append("<tr>");
                        sb.Append("<td colspan='2'>");
                        sb.Append("% Target:");
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("(%)");
                        sb.Append("</td>");
                        for (int j = 0; j < ColumnCount - 5; j++)
                        {
                            sb.Append("<td>");
                            if (listLoc[j].MonitorType == "1")
                            {
                                sb.AppendFormat("<input id='Target{0}Per{1}' type='text' value='' />"
                                , i, j);
                            }
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");

                        sb.Append("<tr>");
                        sb.Append("<td rowspan='3'>");
                        sb.Append("Target Achieved:");
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("Date & Time:");
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("");
                        sb.Append("</td>");
                        for (int j = 0; j < ColumnCount - 5; j++)
                        {
                            sb.Append("<td>");
                            if (listLoc[j].MonitorType == "1")
                            {
                                sb.AppendFormat("<input id='Target{0}Loc{1}DateTime' type='text' value='' />"
                                , i, j);
                            }
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");

                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append("Elapsed Time:");
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("(hh:mm)");
                        sb.Append("</td>");
                        for (int j = 0; j < ColumnCount - 5; j++)
                        {
                            sb.Append("<td>");
                            if (listLoc[j].MonitorType == "1")
                            {
                                sb.AppendFormat("<input id='Target{0}Loc{1}ElapsedTime' type='text' value='' />"
                                , i, j);
                            }
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");

                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append("Temperature:");
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("(℃)");
                        sb.Append("</td>");
                        for (int j = 0; j < ColumnCount - 5; j++)
                        {
                            sb.Append("<td>");
                            if (listLoc[j].MonitorType == "1")
                            {
                                sb.AppendFormat("<input id='Target{0}Loc{1}Temperature' type='text' value='' />"
                                , i, j);
                            }
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    #endregion
                    sb.Append("</table>");

                    TableDetails = sb.ToString();
                }
            }
        }
    }
}