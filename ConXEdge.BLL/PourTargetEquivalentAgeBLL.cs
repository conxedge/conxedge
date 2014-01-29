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
    public class PourTargetEquivalentAgeBLL
    {
        BaseDAL dal = new BaseDAL(typeof(PourTargetEquivalentAgeBLL));

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：修改失败，1：修改成功</returns>
        public M.Message Update(M.PourTargetEquivalentAge model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.VwPourTargetEquivalentAge> GetListByPourID(string PourID)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("_pourid", PourID));

            List<Order> Orders = new List<Order>();
            Orders.Add(new Order("_loggercode",true));
            Orders.Add(new Order("_channelno", true));
            Orders.Add(new Order("_target", true));

            return dal.GetList<M.VwPourTargetEquivalentAge>(Conditions, Orders);
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.PourTargetEquivalentAge GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.PourTargetEquivalentAge>(keyid);
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
            dal.DoPager<M.VwPourTargetEquivalentAge>(pi);
        }
    }
}
