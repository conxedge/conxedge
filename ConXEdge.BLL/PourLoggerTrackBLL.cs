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
    public class PourLoggerTrackBLL
    {
        BaseDAL dal = new BaseDAL(typeof(PourLoggerTrackBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.PourLoggerTrack model)
        {
            M.Message m = IsExtits(model.Pourid, model.Loggerid, model.ChannelNo,model.DataPointid);
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
        /// 更新数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Update(M.PourLoggerTrack model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.PourLoggerTrack> GetListByPourID(string PourID)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pourid", PourID));

            List<Order> Orders = new List<Order>();
            Orders.Add(new Order("CurrentTime",true));
            return dal.GetList<M.PourLoggerTrack>(Conditions, Orders);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.PourLoggerTrack> GetListByPourID(string PourID,string LoggerID,string ChannelNo)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pourid", PourID));
            Conditions.Add(Expression.Eq("Loggerid", LoggerID));
            Conditions.Add(Expression.Eq("ChannelNo", int.Parse(ChannelNo)));
            Conditions.Add(Expression.IsNotNull("EquivalentAge"));

            List<Order> Orders = new List<Order>();
            Orders.Add(new Order("CurrentTime", true));
            return dal.GetList<M.PourLoggerTrack>(Conditions, Orders);
        }

        /// <summary>
        /// 判断是否存在。
        /// </summary>
        public M.Message IsExtits(string pourid, string loggerid, int channelno, decimal datapointid)
        {
            M.Message msg = new M.Message();
            msg.State = M.MessageState.Success;
            msg.Msg = "Pour Logger Track is not exists!";

            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pourid", pourid));
            Conditions.Add(Expression.Eq("Loggerid", loggerid));
            Conditions.Add(Expression.Eq("ChannelNo", channelno));
            Conditions.Add(Expression.Eq("DataPointid", datapointid));

            List<M.PourLoggerTrack> list = dal.GetList<M.PourLoggerTrack>(Conditions, null);
            if (list.Count > 0)
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Pour Logger Track is exists!";
            }
            return msg;
        }
    }
}
