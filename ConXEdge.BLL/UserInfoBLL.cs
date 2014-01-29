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
    public class UserInfoBLL
    {
        BaseDAL dal = new BaseDAL(typeof(ProjectInfoBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.UserInfo model)
        {
            M.Message m = IsExtits(model.UserName, "");
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
        public M.Message Update(M.UserInfo model)
        {
            M.Message m = IsExtits(model.UserName, model.Userid);
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
        public M.Message SaveOrUpdate(M.UserInfo model)
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
            M.Message m = new M.Message();
            m = dal.Execute(string.Format("delete UserInfo where UserID='{0}'", id));
            return m;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.UserInfo> GetList()
        {
            return dal.GetList<M.UserInfo>();
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.UserInfo GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.UserInfo>(keyid);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Pwd">MD5加密后的用户密码</param>
        /// <returns>实体类</returns>
        public M.UserInfo UserLogin(string UserName, string Pwd)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("UserName", UserName));
            Conditions.Add(Expression.Eq("Password", Pwd));
            List<M.UserInfo> list = dal.GetList<M.UserInfo>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[0];
            }
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string Name, string pid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("UserName", Name));

            List<M.UserInfo> list = dal.GetList<M.UserInfo>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "User name is not exists!";
            }
            else
            {
                if (!string.IsNullOrEmpty(pid) && pid == list[0].Userid)
                {
                    msg.State = M.MessageState.Success;
                    msg.Msg = "User name is not exists!";
                }
                else
                {
                    msg.State = M.MessageState.Failure;
                    msg.Msg = "User name is exists!";
                }
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
            dal.DoPager<M.UserInfo>(pi);
        }

    }
}
