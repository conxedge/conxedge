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
    public class Pour2LevelBLL
    {
        BaseDAL dal = new BaseDAL(typeof(Pour2LevelBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.Pour2Level model)
        {
            M.Message m = IsExtits(model.Pourid, model.Levelid);
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
                M.Pour2Level model = GetModelByID(id);
                return dal.Delete<M.Pour2Level>(model);
            }
            else
            {
                return m;
            }
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string pourid, string levelid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pourid", pourid));
            Conditions.Add(Expression.Eq("Levelid", levelid));

            List<M.Pour2Level> list = dal.GetList<M.Pour2Level>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Pour to level is not exists!";
            }
            else
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Pour to level is exists!";
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
        public List<M.Pour2Level> GetList()
        {
            return dal.GetList<M.Pour2Level>();
        }

        /// <summary>
        /// 根据PourID获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.VwPour2Level> GetListByPourID(string PourID)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("_pourid", PourID));

            return dal.GetList<M.VwPour2Level>(Conditions, null);
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.Pour2Level GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.Pour2Level>(keyid);
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
            dal.DoPager<M.VwPour2Level>(pi);
        }
    }
}
