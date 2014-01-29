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
    public class PourInfoBLL
    {
        BaseDAL dal = new BaseDAL(typeof(PourInfoBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.PourInfo model)
        {
            M.Message m = IsExtits(model.PourName, "");
            if (m.State == M.MessageState.Success)
            {
                List<EntityModel> listEntity = new List<EntityModel>();
                listEntity.Add(new EntityModel(model, OperationMode.Add));

                DefaultTargetBLL bll = new DefaultTargetBLL();
                List<M.DefaultTarget> list = bll.GetList();
                foreach (M.DefaultTarget c in list)
                {
                    M.Pour2Target entity = new M.Pour2Target();
                    entity.Id = Guid.NewGuid().ToString();
                    entity.Pourid = model.Pourid;
                    entity.Purpose = c.Purpose;
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
        public M.Message Update(M.PourInfo model)
        {
            M.Message m = IsExtits(model.PourName, model.Pourid);
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
        public M.Message SaveOrUpdate(M.PourInfo model)
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
                try
                {
                    m = dal.Execute(string.Format("delete Pour2Level where PourID='{0}'",id));
                    m = dal.Execute(string.Format("delete Pour2Target where PourID='{0}'", id));
                    m = dal.Execute(string.Format("delete PourInfo where PourID='{0}'", id));
                    m = dal.Execute(string.Format("delete PourLocation where PourID='{0}'", id));
                    m = dal.Execute(string.Format("delete PourLocation2Target where PourID='{0}'", id));
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
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.VwPourInfo> GetList()
        {
            return dal.GetList<M.VwPourInfo>();
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.PourInfo GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.PourInfo>(keyid);
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.VwPourInfo GetViewModelByID(string keyid)
        {
            return dal.GetModelByID<M.VwPourInfo>(keyid);
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string Name, string pid)
        {
            M.Message msg = new M.Message();
            msg.State = M.MessageState.Success;
            return msg;
        }

        /// <summary>
        /// 根据编号判断是否被其它关联表使用。
        /// </summary>
        public M.Message IsUsed(string pid)
        {
            M.Message msg = new M.Message();

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
            dal.DoPager<M.VwPourInfo>(pi);
        }
    }
}
