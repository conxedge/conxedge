using System;
using System.Collections.Generic;
using System.Text;
using B = ConXEdge.BLL;
using M = ConXedge.Model;

namespace ConXEdge.WebSite.Module.HardwareControl
{
    public partial class LoggerTrackSetup : ConXEdge.WebSite.AppCode.PageBase
    {
        public string TableDetails;
        public string DefaultTarget;
        private StringBuilder sb;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                B.PourInfoBLL bll = new B.PourInfoBLL();
                M.VwPourInfo model = bll.GetViewModelByID(Request.QueryString["pid"]);
                if (model != null)
                {
                    this.PourName.Text = model.PourName;
                    this.PourVolume.Text = model.PourVolume.ToString();
                    this.ProjectName.Text = model.ProjectName;
                    this.CreateDate.Text = model.CreateDate.ToString("dd/MM/yyyy");
                    this.SetupBy.Text = model.SetupBy;
                    this.ProductCode.Text = model.Code;
                    this.Supplier.Text = model.Supplier;
                    this.ProductDescription.Text = model.Description;
                    this.MaturityMethod.Text = model.MaturityMethod;
                    this.Email.Text = model.Email;
                    switch (model.StopType)
                    {
                        case "1":
                            this.StopType.Text = "Channel Achieves Final Target";
                            break;
                        case "2":
                            this.StopType.Text = "All Channels Have Achieved Final Targets";
                            break;
                        case "3":
                            this.StopType.Text = "X Hours After Channel Achieves Final Target";
                            break;
                        case "4":
                            this.StopType.Text = "X Hours After All Channels Have Achieved Final Targets";
                            break;
                        case "5":
                            this.StopType.Text = "Logger is Stopped";
                            break;
                        default:
                            break;
                    }
                    if (model.Xhours != 0)
                        this.XHours.Text = model.Xhours.ToString();

                    Levels.Items.Clear();
                    B.Pour2LevelBLL bllLevel = new B.Pour2LevelBLL();
                    List<M.VwPour2Level> listLevel = bllLevel.GetListByPourID(model.Pourid);
                    foreach (M.VwPour2Level c in listLevel)
                    {
                        Levels.Items.Add(c.LevelName);
                    }

                    sb = new StringBuilder();
                    B.Pour2TargetBLL bllTarget = new B.Pour2TargetBLL();
                    List<M.Pour2Target> listTarget = bllTarget.GetListByPourID(model.Pourid);
                    sb.Append("<tr>");
                    sb.AppendFormat("<th rowspan='{0}'>", listTarget.Count + 2);
                    sb.Append("Pour Targets & Notification Requirements:");
                    sb.Append("</th>");
                    sb.Append("<th colspan='5'>");
                    sb.Append("Target");
                    sb.Append("</th>");
                    sb.Append("<th rowspan='2'>");
                    sb.Append("EA Target");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<th>");
                    sb.Append("No.");
                    sb.Append("</th>");
                    sb.Append("<th colspan='4'>");
                    sb.Append("Purpose");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    for (int i = 0; i < listTarget.Count; i++)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.AppendFormat("{0}", i + 1);
                        sb.Append("</td>");
                        sb.Append("<td colspan='4'>");
                        sb.AppendFormat("{0}", listTarget[i].Purpose);
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.AppendFormat("{0}", listTarget[i].Target);
                        sb.Append("</td>");
                        sb.Append("</tr>");
                    }
                    this.DefaultTarget = sb.ToString();

                    int columnCount = listTarget.Count + 6;
                    sb = new StringBuilder();
                    sb.Append("<table class='t2'>");
                    sb.Append("<tr>");
                    sb.AppendFormat("<th colspan='{0}'>", columnCount);
                    sb.Append("Evaluation Details:");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<th colspan='3'>");
                    sb.Append("Location");
                    sb.Append("</th>");
                    sb.Append("<th rowspan='2' colspan='2'>");
                    sb.Append("Logger / Channel Details");
                    sb.Append("</th>");
                    sb.Append("<th rowspan='2'>");
                    sb.Append("Details");
                    sb.Append("</th>");
                    sb.AppendFormat("<th colspan='{0}'>", listTarget.Count);
                    sb.Append("Target");
                    sb.Append("</th>");
                    sb.Append("</tr>");

                    sb.Append("<tr>");
                    sb.Append("<th>");
                    sb.Append("ID");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("Description");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("Monitor Type");
                    sb.Append("</th>");
                    for (int i = 1; i <= listTarget.Count; i++)
                    {
                        sb.Append("<th>");
                        sb.AppendFormat("{0}", i);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");

                    B.PourLocationBLL bllLoc = new B.PourLocationBLL();
                    List<M.VwPourLocation> listLoc = bllLoc.GetListByPourID(model.Pourid);
                    foreach (M.VwPourLocation c in listLoc)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.AppendFormat("{0}", c.Locationid);
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.AppendFormat("{0}", c.LocationDescription);
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.AppendFormat("{0}", c.MonitorType == "1" ? "Equivalent Age" : "Temperature Only");
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.AppendFormat("{0}", c.LoggerCode);
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.AppendFormat("{0}", c.ChannelNo);
                        sb.Append("</td>");

                        sb.Append("<td>");
                        sb.AppendFormat("{0}", c.Details);
                        sb.Append("</td>");

                        B.PourLocation2TargetBLL bllLocTarget = new B.PourLocation2TargetBLL();
                        List<M.PourLocation2Target> listLocTarget = bllLocTarget.GetListByLocationID(c.Id);
                        foreach (M.PourLocation2Target c1 in listLocTarget)
                        {
                            sb.Append("<td>");
                            if (c.MonitorType == "1")
                            {
                                sb.AppendFormat("{0}", c1.Target);
                            }
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");

                    TableDetails = sb.ToString();
                }
            }
        }
    }
}