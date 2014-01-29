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
    public class PourLocationBLL
    {
        BaseDAL dal = new BaseDAL(typeof(PourLocationBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.PourLocation model)
        {
            M.Message m = IsExtits(model.Pourid, model.Locationid , "");
            if (m.State == M.MessageState.Success)
            {
                List<EntityModel> listEntity = new List<EntityModel>();
                listEntity.Add(new EntityModel(model, OperationMode.Add));

                Pour2TargetBLL bll = new Pour2TargetBLL();
                List<M.Pour2Target> list = bll.GetListByPourID(model.Pourid);
                foreach (M.Pour2Target c in list)
                {
                    M.PourLocation2Target entity = new M.PourLocation2Target();
                    entity.Id = Guid.NewGuid().ToString();
                    entity.Pourid = model.Pourid;
                    entity.Pour2Targetid = c.Id;
                    entity.PourLocationid = model.Id;
                    entity.Target = c.Target;
                    listEntity.Add(new EntityModel(entity, OperationMode.Add));
                }

                return EntitesOperations(listEntity);
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
        public M.Message Update(M.PourLocation model)
        {
            M.Message m = IsExtits(model.Pourid, model.Locationid, model.Id);
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
        /// 删除实体
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>false：删除失败，true：删除成功</returns>
        public M.Message DeleteByID(string id)
        {
            M.Message m = IsUsed(id);
            if (m.State == M.MessageState.Success)
            {
                try
                {
                    m = dal.Execute(string.Format("delete PourLocation where ID='{0}'", id));
                    m = dal.Execute(string.Format("delete PourLocation2Target where PourLocationID='{0}'", id));
                }
                catch (Exception ex)
                {
                    m.State = M.MessageState.Failure;
                    m.Msg = ex.Message;
                }
            }
            return m;
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string pourid, string locationid, string pid)
        {
            M.Message msg = new M.Message();
            msg.State = M.MessageState.Success;
            msg.Msg = "Pour location is not exists!";

            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pourid", pourid));
            Conditions.Add(Expression.Eq("Locationid", locationid));

            List<M.PourLocation> list = dal.GetList<M.PourLocation>(Conditions, null);
            if (list.Count > 0 && (list[0].Id != pid || string.IsNullOrEmpty(pid)))
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Pour location is exists!";
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
        public List<M.PourLocation> GetList()
        {
            return dal.GetList<M.PourLocation>();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.VwPourLocation> GetListByPourID(string PourID)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("_pourid", PourID));

            List<Order> Orders = new List<Order>();
            Orders.Add(new Order("_loggercode",true));
            Orders.Add(new Order("_channelno", true));

            return dal.GetList<M.VwPourLocation>(Conditions, Orders);
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.PourLocation GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.PourLocation>(keyid);
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
            dal.DoPager<M.VwPourLocation>(pi);
        }
    }
}
