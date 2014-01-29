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
    public class LoggerTrackBLL
    {
        BaseDAL dal = new BaseDAL(typeof(LoggerTrackBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.LoggerTrack model)
        {
            M.Message m = IsExtits(model.DataPointid,model.Loggerid);
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
        public M.Message Update(M.LoggerTrack model)
        {
            M.Message m = IsExtits(model.DataPointid, model.Loggerid);
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
            M.LoggerTrack model = GetModelByID(id);
            return dal.Delete<M.LoggerTrack>(model);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.LoggerTrack> GetList()
        {
            return dal.GetList<M.LoggerTrack>();
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.LoggerTrack GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.LoggerTrack>(keyid);
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(decimal datapointid, string loggerid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("DataPointid", datapointid));
            Conditions.Add(Expression.Eq("Loggerid", loggerid));

            List<M.LoggerTrack> list = dal.GetList<M.LoggerTrack>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Logger track is not exists!";
            }
            else
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Logger track is exists!";
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
            dal.DoPager<M.LoggerTrack>(pi);
        }

        /// <summary>
        /// 分页方法LoggerTemp
        /// </summary>
        /// <param name="pi"></param>
        public void DoPager4LoggerTemp(M.PageInfo pi)
        {
            dal.DoPager<M.VwLoggerTemp>(pi);
        }
    }
}
