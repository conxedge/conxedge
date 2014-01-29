using System.Collections.Generic;
using ConXEdge.DAL;
using ConXEdge.Nhibernate;
using NHibernate.Criterion;
using M = ConXedge.Model;

namespace ConXEdge.BLL
{
    public class LoggerEventsBLL
    {
        BaseDAL dal = new BaseDAL(typeof(LoggerEventsBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.LoggerEvents model)
        {
            M.Message m = IsExtits(model.Eventid,model.Loggerid);
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
        public M.Message Update(M.LoggerEvents model)
        {
            M.Message m = IsExtits(model.Eventid, model.Loggerid);
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
            M.LoggerEvents model = GetModelByID(id);
            return dal.Delete<M.LoggerEvents>(model);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.LoggerEvents> GetList()
        {
            return dal.GetList<M.LoggerEvents>();
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.LoggerEvents GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.LoggerEvents>(keyid);
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(decimal datapointid, string loggerid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Eventid", datapointid));
            Conditions.Add(Expression.Eq("Loggerid", loggerid));

            List<M.LoggerTrack> list = dal.GetList<M.LoggerTrack>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Logger event is not exists!";
            }
            else
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Logger event is exists!";
            }
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
            dal.DoPager<M.LoggerEvents>(pi);
        }
    }
}
