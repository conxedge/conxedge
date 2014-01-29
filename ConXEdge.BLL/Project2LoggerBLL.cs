using System;
using System.Collections.Generic;
using System.Text;
using M = ConXedge.Model;
using NHibernate.Criterion;
using B = ConXEdge.BLL;
using ConXEdge.DAL;
using ConXEdge.Nhibernate;

namespace ConXEdge.BLL
{
    public class Project2LoggerBLL
    {
        BaseDAL dal = new BaseDAL(typeof(Project2LoggerBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.Project2Logger model)
        {
            M.Message m = IsExtits(model.Loggerid, model.Projectid);
            if (m.State == M.MessageState.Success)
            {
                return dal.Add(model);
            }
            else
            {
                return m;
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>false：删除失败，true：删除成功</returns>
        public M.Message DeleteByID(string id)
        {           
            M.Message m = IsUsed(id);
            if (m.State == M.MessageState.Success)
            {
                M.Project2Logger model = GetModelByID(id);
                return dal.Delete<M.Project2Logger>(model);
            }
            else
            {
                return m;
            }
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string loggerid, string pid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Projectid", pid));
            Conditions.Add(Expression.Eq("Loggerid", loggerid));

            List<M.Project2Logger> list = dal.GetList<M.Project2Logger>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Project to logger is not exists!";
            }
            else
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Project to logger is exists!";
            }
            return msg;
        }

        /// <summary>
        /// 根据编号判断是否被其它关联表使用。
        /// </summary>
        public M.Message IsUsed(string pid)
        {
            M.Message msg = new M.Message();
            msg.State = M.MessageState.Success;
            return msg;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.Project2Logger> GetList()
        {
            return dal.GetList<M.Project2Logger>();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.VwProject2Logger> GetListByProjectID(string ProjectID)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("_projectid", ProjectID));

            return dal.GetList<M.VwProject2Logger>(Conditions, null);
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.Project2Logger GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.Project2Logger>(keyid);
        }

        /// <summary>
        /// 事务处理
        /// </summary>
        /// <param name="model">实体类</param> 
        /// <returns>0：操作失败，1：操作成功</returns>
        public M.Message EntitesOperations(List<EntityModel> list)
        {
            return dal.EntitesOperations(list);
        }

        /// <summary>
        /// 分页方法，按过滤Projectid过滤
        /// </summary>
        /// <param name="pi"></param>
        public void DoPager(M.PageInfo pi)
        {
            dal.DoPager<M.VwProject2Logger>(pi);
        }
    }
}
