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

namespace ConXEdge.WebSite.Module.Projects
{
    public partial class LoggerList : ConXEdge.WebSite.AppCode.PageBase
    {
        protected int _nPageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            //分页查询结果
            this.PagerBar1.PageSize = _nPageSize;
            M.PageInfo pInfo = new M.PageInfo();
            pInfo.Conditions = new List<ICriterion>();
            //查询条件过滤
            if (!string.IsNullOrEmpty(Request.QueryString["Code"]))
            {
                pInfo.Conditions.Add(Expression.Like("_loggercode", Request.QueryString["Code"].Trim(), MatchMode.Anywhere));
            }
            pInfo.Conditions.Add(Expression.Eq("_companyid", base.CurrentUserInfo.Companyid));
            pInfo.OrderFields = new List<Order>();
            pInfo.OrderFields.Add(new Order("_loggercode", true));

            pInfo.PageSize = this.PagerBar1.PageSize;
            pInfo.PageIndex = this.PagerBar1.CurrentPage;
            new B.LoggerInfoBLL().DoPager(pInfo);
            this.Repeater1.DataSource = pInfo.List;
            this.Repeater1.DataBind();
            this.PagerBar1.RecordCount = pInfo.RecordCount;
        }

        public string GetOperation(string pid ,string pourName)
        {
            string str = "";
            str = " &nbsp;<a href=\"javascript:editItem('" + pid + "');\">Edit</a>";
            str += " &nbsp;<a href=\"javascript:Delete('" + pid + "');\">Delete</a>";
            if (!string.IsNullOrEmpty(pourName))
            {                
                str += " &nbsp;<a href=\"javascript:RemoveBinding('" + pid + "');\">Remove Binding</a>";
            }
            return str;
        }
    }
}