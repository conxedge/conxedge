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
    public class PourLoggerStatusBLL
    {
        BaseDAL dal = new BaseDAL(typeof(PourLoggerStatusBLL));

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：修改失败，1：修改成功</returns>
        public M.Message Update(M.PourLoggerStatus model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.PourLoggerStatus> GetListByPourID(string PourID)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pourid", PourID));

            return dal.GetList<M.PourLoggerStatus>(Conditions, null);
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.PourLoggerStatus GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.PourLoggerStatus>(keyid);
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
            dal.DoPager<M.PourLoggerStatus>(pi);
        }
    }
}
