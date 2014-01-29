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
    public class PourLoggerEventsBLL
    {
        BaseDAL dal = new BaseDAL(typeof(PourLoggerEventsBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.PourLoggerEvents model)
        {
            M.Message m = IsExtits(model.Pourid, model.Loggerid, model.ChannelNo,model.Eventid);
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
        /// 判断是否存在。
        /// </summary>
        public M.Message IsExtits(string pourid, string loggerid, int channelno, decimal datapointid)
        {
            M.Message msg = new M.Message();
            msg.State = M.MessageState.Success;
            msg.Msg = "Pour Logger Events is not exists!";

            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Pourid", pourid));
            Conditions.Add(Expression.Eq("Loggerid", loggerid));
            Conditions.Add(Expression.Eq("ChannelNo", channelno));
            Conditions.Add(Expression.Eq("Eventid", datapointid));

            List<M.PourLoggerEvents> list = dal.GetList<M.PourLoggerEvents>(Conditions, null);
            if (list.Count > 0)
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Pour Logger Events is exists!";
            }
            return msg;
        }
    }
}
