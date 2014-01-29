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
    public class Pour2TargetBLL
    {
        BaseDAL dal = new BaseDAL(typeof(Pour2TargetBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.Pour2Target model)
        {
            M.Message m = IsExtits(model.Pourid, model.Purpose , "");
            if (m.State == M.MessageState.Success)
            {
                List<EntityModel> listModel = new List<EntityModel>();
                B.PourLocationBLL bll = new PourLocationBLL();
                List<M.VwPourLocation> list = bll.GetListByPourID(model.Pourid);
                foreach(M.VwPourLocation c in list)
                {
                    M.PourLocation2Target entity = new M.PourLocation2Target();
                    entity.Id = Guid.NewGuid().ToString();
                    entity.Pour2Targetid = model.Id;
                    entity.Pourid = model.Pourid;
                    entity.PourLocationid = c.Id;
                    entity.Target = model.Target;
                    listModel.Add(new EntityModel(entity, OperationMode.Add));
                }
                listModel.Add(new EntityModel(model, OperationMode.Add));

                return EntitesOperations(listModel);
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
        public M.Message Update(M.Pour2Target model)
        {
            M.Message m = IsExtits(model.Pourid, model.Purpose,model.Id);
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
                    M.Pour2Target model = GetModelByID(id);
                    NHibernateProxy proxy = new NHibernateProxy();
                    proxy.Execute(string.Format("Delete PourLocation2Target where Pour2TargetID='{0}'", id));
                    return dal.Delete<M.Pour2Target>(model);
                }
                catch(Exception ex)
                {
                    m.Msg = ex.Message;
                    m.State = M.MessageState.Failure;
                    return m;
                }
            }
            else
            {
                return m;
            }
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string pourid, string purpose, string pid)
        {
            M.Message msg = new M.Message();
            msg.State = M.MessageState.Success;
            msg.Msg = "Pour to target is not exists!";

            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pourid", pourid));
            Conditions.Add(Expression.Eq("Purpose", purpose));

            List<M.Pour2Target> list = dal.GetList<M.Pour2Target>(Conditions, null);
            if (list.Count > 0 && (list[0].Id != pid || string.IsNullOrEmpty(pid)))
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Pour to target is exists!";
            }
            return msg;
        }

        /// <summary>
        /// 根据编号判断是否被其它关联表使用。
        /// </summary>
        public M.Message IsUsed(string pid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pour2Targetid", pid));

            List<M.PourInfo> list = dal.GetList<M.PourInfo>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Target has not been used!";
            }
            else
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Target has been used in location!";
            }
            msg.State = M.MessageState.Success;
            return msg;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.Pour2Target> GetList()
        {
            return dal.GetList<M.Pour2Target>();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.Pour2Target> GetListByPourID(string PourID)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pourid", PourID));

            List<Order> Orders = new List<Order>();
            Orders.Add(new Order("Target", true));

            return dal.GetList<M.Pour2Target>(Conditions, Orders);
        }

        /// <summary>
        /// 获取Target列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.VwPourLocation2Target> GetTargetListByPourID(string PourID)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("_pourid", PourID));

            List<Order> Orders = new List<Order>();
            Orders.Add(new Order("_loggercode", true));
            Orders.Add(new Order("_channelno", true));

            return dal.GetList<M.VwPourLocation2Target>(Conditions, null);
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.Pour2Target GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.Pour2Target>(keyid);
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
            dal.DoPager<M.Pour2Target>(pi);
        }
    }
}
