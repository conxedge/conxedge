﻿using System;
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
    public partial class Project2LoggerList : ConXEdge.WebSite.AppCode.PageBase
    {
        protected int _nPageSize = 10;
        protected string pid;
        protected string ProjectName;

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
                B.ProjectInfoBLL bll = new B.ProjectInfoBLL();
                ProjectName = bll.GetModelByID(pid).ProjectName;
                pInfo.Conditions.Add(Expression.Like("_projectid", pid, MatchMode.Anywhere));
            }
            pInfo.OrderFields = new List<Order>();
            pInfo.OrderFields.Add(new Order("_loggercode", true));

            pInfo.PageSize = this.PagerBar1.PageSize;
            pInfo.PageIndex = this.PagerBar1.CurrentPage;
            new B.Project2LoggerBLL().DoPager(pInfo);
            this.Repeater1.DataSource = pInfo.List;
            this.Repeater1.DataBind();
            this.PagerBar1.RecordCount = pInfo.RecordCount;
        }
    }
}