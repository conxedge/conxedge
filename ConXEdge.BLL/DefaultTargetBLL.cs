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
    public class DefaultTargetBLL
    {
        BaseDAL dal = new BaseDAL(typeof(DefaultTargetBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.DefaultTarget model)
        {
            M.Message m = IsExtits(model.Purpose,"");
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
        /// 修改数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：修改失败，1：修改成功</returns>
        public M.Message Update(M.DefaultTarget model)
        {
            M.Message m = IsExtits(model.Purpose,model.Targetid);
            if (m.State == M.MessageState.Success)
            {
                return dal.Update(model);
            }
            else
            {
                return m;
            }            
        }

        /// <summary>
        /// 新增或修改数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：操作失败，1：操作成功</returns>
        public M.Message SaveOrUpdate(M.DefaultTarget model)
        {
            return dal.SaveOrUpdate(model);
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
                M.DefaultTarget model = GetModelByID(id);
                return dal.Delete<M.DefaultTarget>(model);
            }
            else
            {
                return m;
            }
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.DefaultTarget> GetList()
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order("Target",true));

            List<M.DefaultTarget> list = dal.GetList<M.DefaultTarget>(null, orders);
            return dal.GetList<M.DefaultTarget>();
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.DefaultTarget GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.DefaultTarget>(keyid);
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string Code,string pid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Purpose", Code));

            List<M.DefaultTarget> list = dal.GetList<M.DefaultTarget>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Default target is not exists!";
            }
            else
            {
                if (!string.IsNullOrEmpty(pid) && pid == list[0].Targetid)
                {
                    msg.State = M.MessageState.Success;
                    msg.Msg = "Default target is not exists!";
                }
                else
                {
                    msg.State = M.MessageState.Failure;
                    msg.Msg = "Default target is exists!";
                }
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
        /// 事务处理
        /// </summary>
        /// <param name="model">实体类</param> 
        /// <returns>0：操作失败，1：操作成功</returns>
        public M.Message EntitesOperations(List<EntityModel> list)
        {
            return dal.EntitesOperations(list);
        }

        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="pi"></param>
        public void DoPager(M.PageInfo pi)
        {
            dal.DoPager<M.DefaultTarget>(pi);
        }
    }
}
