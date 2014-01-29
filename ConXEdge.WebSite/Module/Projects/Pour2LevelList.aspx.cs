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
    public partial class Pour2LevelList : ConXEdge.WebSite.AppCode.PageBase
    {
        protected int _nPageSize = 10;
        public string pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            //分页查询结果
            this.PagerBar1.PageSize = _nPageSize;
            M.PageInfo pInfo = new M.PageInfo();
            pInfo.Conditions = new List<ICriterion>();
            //查询条件过滤
            if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                pid = Request.QueryString["pid"].Trim();
                pInfo.Conditions.Add(Expression.Eq("_pourid", pid));
            }
            pInfo.OrderFields = new List<Order>();
            pInfo.OrderFields.Add(new Order("_levelname", true));

            pInfo.PageSize = this.PagerBar1.PageSize;
            pInfo.PageIndex = this.PagerBar1.CurrentPage;
            new B.Pour2LevelBLL().DoPager(pInfo);
            this.Repeater1.DataSource = pInfo.List;
            this.Repeater1.DataBind();
            this.PagerBar1.RecordCount = pInfo.RecordCount;
        }
    }
}