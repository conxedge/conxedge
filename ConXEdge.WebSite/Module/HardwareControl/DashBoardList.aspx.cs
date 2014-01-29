using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using NHibernate.Criterion;
using M = ConXedge.Model;
using B = ConXEdge.BLL;

namespace ConXEdge.WebSite.Module.HardwareControl
{
    public partial class DashBoardList : ConXEdge.WebSite.AppCode.PageBase
    {
        protected int _nPageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            //分页查询结果
            this.PagerBar1.PageSize = _nPageSize;
            M.PageInfo pInfo = new M.PageInfo();
            pInfo.Conditions = new List<ICriterion>();
            //查询条件过滤
            if (!string.IsNullOrEmpty(Request.QueryString["Name"]))
            {
                pInfo.Conditions.Add(Expression.Like("_pourname", Request.QueryString["Name"].Trim(), MatchMode.Anywhere));
            }
            pInfo.Conditions.Add(Expression.Eq("_status", "1"));
            pInfo.Conditions.Add(Expression.Eq("_companyid", base.CurrentUserInfo.Companyid));
            pInfo.OrderFields = new List<Order>();
            pInfo.OrderFields.Add(new Order("_pourname", true));

            pInfo.PageSize = this.PagerBar1.PageSize;
            pInfo.PageIndex = this.PagerBar1.CurrentPage;
            new B.PourInfoBLL().DoPager(pInfo);
            this.Repeater1.DataSource = pInfo.List;
            this.Repeater1.DataBind();
            this.PagerBar1.RecordCount = pInfo.RecordCount;
        }

        public string ConvertStopType(string StopType)
        {
            switch (StopType)
            {
                case "1":
                    StopType = "Channel Achieves Final Target";
                    break;
                case "2":
                    StopType = "All Channels Have Achieved Final Targets";
                    break;
                case "3":
                    StopType = "X Hours After Channel Achieves Final Target";
                    break;
                case "4":
                    StopType = "X Hours After All Channels Have Achieved Final Targets";
                    break;
                case "5":
                    StopType = "Logger is Stopped";
                    break;
                default:
                    break;
            }
            return StopType;
        }

        public string ConvertPourType(string PourType)
        {
            switch (PourType)
            {
                case "1":
                    PourType = "Pour Before Logger Start";
                    break;
                case "2":
                    PourType = "Pour After Logger Start";
                    break;
                default:
                    break;
            }
            return PourType;
        }
    }
}