using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Globalization;
using NHibernate.Criterion;
using M = ConXedge.Model;
using B = ConXEdge.BLL;

namespace ConXEdge.WebSite.Module.Projects
{
    public partial class LoggerTempList : ConXEdge.WebSite.AppCode.PageBase
    {
        protected int _nPageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            IFormatProvider culture = new CultureInfo("en-AU", true);

            //分页查询结果
            this.PagerBar1.PageSize = _nPageSize;
            M.PageInfo pInfo = new M.PageInfo();
            pInfo.Conditions = new List<ICriterion>();
            //查询条件过滤
            if (!string.IsNullOrEmpty(Request.QueryString["ProjectName"]))
            {
                pInfo.Conditions.Add(Expression.Like("_projectname", Request.QueryString["ProjectName"].Trim(), MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(Request.QueryString["PourName"]))
            {
                pInfo.Conditions.Add(Expression.Like("_pourname", Request.QueryString["PourName"].Trim(), MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(Request.QueryString["LoggerCode"]))
            {
                pInfo.Conditions.Add(Expression.Like("_loggercode", Request.QueryString["LoggerCode"].Trim(), MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(Request.QueryString["StartTime"]))
            {                
                DateTime StartTime = DateTime.Parse(Request.QueryString["StartTime"], culture);

                pInfo.Conditions.Add(Expression.Ge("_currenttime", StartTime));
            }
            if (!string.IsNullOrEmpty(Request.QueryString["EndTime"]))
            {
                DateTime EndTime = DateTime.Parse(Request.QueryString["EndTime"], culture);

                pInfo.Conditions.Add(Expression.Le("_currenttime", EndTime));
            }
            pInfo.Conditions.Add(Expression.Eq("_companyid", base.CurrentUserInfo.Companyid));
            pInfo.OrderFields = new List<Order>();
            pInfo.OrderFields.Add(new Order("_currenttime", false));

            pInfo.PageSize = this.PagerBar1.PageSize;
            pInfo.PageIndex = this.PagerBar1.CurrentPage;
            new B.LoggerTrackBLL().DoPager4LoggerTemp(pInfo);
            this.Repeater1.DataSource = pInfo.List;
            this.Repeater1.DataBind();
            this.PagerBar1.RecordCount = pInfo.RecordCount;
        }
    }
}