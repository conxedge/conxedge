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
    public partial class CompanyList : ConXEdge.WebSite.AppCode.PageBase
    {
        protected int _nPageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            //分页查询结果
            this.PagerBar1.PageSize = _nPageSize;
            M.PageInfo pInfo = new M.PageInfo();
            pInfo.Conditions = new List<ICriterion>();
            //查询条件过滤
            if (!string.IsNullOrEmpty(Request.QueryString["Company"]))
            {
                pInfo.Conditions.Add(Expression.Like("CompanyName", Request.QueryString["Company"].Trim(), MatchMode.Anywhere));                    
            }
            //pInfo.Conditions.Add(Expression.Eq("Companyid", base.CurrentUserInfo.Companyid));
            pInfo.OrderFields = new List<Order>();
            pInfo.OrderFields.Add(new Order("CompanyName", true));

            pInfo.PageSize = this.PagerBar1.PageSize;
            pInfo.PageIndex = this.PagerBar1.CurrentPage;
            new B.CompanyInfoBLL().DoPager(pInfo);
            this.Repeater1.DataSource = pInfo.List;
            this.Repeater1.DataBind();
            this.PagerBar1.RecordCount = pInfo.RecordCount;
        }

        public string ConvertType(string Type)
        {
            switch (Type)
            {
                case "01":
                    Type = "HMI";
                    break;
                case "02":
                    Type = "Large Company";
                    break;
                case "03":
                    Type = "Medium sized companies";
                    break;
                case "04":
                    Type = "Small Company";
                    break;
                default:
                    break;
            }
            return Type;
        }
    }
}