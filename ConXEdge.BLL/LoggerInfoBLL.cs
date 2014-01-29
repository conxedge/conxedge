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
    public class LoggerInfoBLL
    {
        BaseDAL dal = new BaseDAL(typeof(LoggerInfoBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.LoggerInfo model)
        {
            M.Message m = IsExtits(model.LoggerCode, "");
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
        public M.Message Update(M.LoggerInfo model)
        {
            M.Message m = IsExtits(model.LoggerCode, model.Loggerid);
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
        public M.Message SaveOrUpdate(M.LoggerInfo model)
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
                M.LoggerInfo model = GetModelByID(id);
                return dal.Delete<M.LoggerInfo>(model);
            }
            else
            {
                return m;
            }
        }

        /// <summary>
        /// 删除绑定信息
        /// </summary>
        /// <param name="id">loggerid</param>
        /// <returns>false：删除失败，true：删除成功</returns>
        public M.Message RemoveBinding(string id)
        {
            M.Message m = new M.Message();
            M.LoggerInfo model = GetModelByID(id);
            if (model != null)
            {
                model.CurrentPourid = "";
                return dal.Update(model);
            }
            else
            {
                m.State = M.MessageState.Failure;
                m.Msg = "Logger is not exists!";
                return m;
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.LoggerInfo> GetList()
        {
            return dal.GetList<M.LoggerInfo>();
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.LoggerInfo GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.LoggerInfo>(keyid);
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string Code, string pid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("LoggerCode", Code));

            List<M.LoggerInfo> list = dal.GetList<M.LoggerInfo>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Logger code is not exists!";
            }
            else
            {
                if (!string.IsNullOrEmpty(pid) && pid == list[0].Loggerid)
                {
                    msg.State = M.MessageState.Success;
                    msg.Msg = "Logger code is not exists!";
                }
                else
                {
                    msg.State = M.MessageState.Failure;
                    msg.Msg = "Logger code is exists!";
                }
            }
            return msg;
        }

        /// <summary>
        /// 是否已经注册。
        /// </summary>
        public M.Message IsReg(string SerialNumber)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("SerialNumber", SerialNumber));

            List<M.LoggerInfo> list = dal.GetList<M.LoggerInfo>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Serial Number is not exists!";
            }
            else
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Serial Number is exists!";
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
            Conditions.Add(Expression.Eq("Loggerid", pid));

            List<M.Project2Logger> list = dal.GetList<M.Project2Logger>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Logger has not been used!";
            }
            else
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Logger has been used in project!";
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
            dal.DoPager<M.VwLoggerInfo>(pi);
        }
    }
}
