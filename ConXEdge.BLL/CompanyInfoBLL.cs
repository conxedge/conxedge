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
    public class CompanyInfoBLL
    {
        BaseDAL dal = new BaseDAL(typeof(CompanyInfoBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.CompanyInfo model)
        {
            if (model == null)
                return new M.Message();
            M.Message m = IsExtits(model.CompanyName,"");
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
        public M.Message Update(M.CompanyInfo model)
        {
            M.Message m = IsExtits(model.CompanyName,model.Companyid);
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
        public M.Message SaveOrUpdate(M.CompanyInfo model)
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
                M.CompanyInfo model = GetModelByID(id);
                return dal.Delete<M.CompanyInfo>(model);
            }
            else
            {
                return m;
            }
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.CompanyInfo> GetList()
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            return dal.GetList<M.CompanyInfo>();
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.CompanyInfo GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.CompanyInfo>(keyid);
        }

        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string Code,string pid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("CompanyName", Code));

            List<M.CompanyInfo> list = dal.GetList<M.CompanyInfo>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Company is not exists!";
            }
            else
            {
                if (!string.IsNullOrEmpty(pid) && pid == list[0].Companyid)
                {
                    msg.State = M.MessageState.Success;
                    msg.Msg = "Company is not exists!";
                }
                else
                {
                    msg.State = M.MessageState.Failure;
                    msg.Msg = "Company is exists!";
                }
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
            Conditions.Add(Expression.Eq("Companyid", pid));

            List<M.UserInfo> list = dal.GetList<M.UserInfo>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Company has not been used!";
            }
            else
            {
                msg.State = M.MessageState.Failure;
                msg.Msg = "Company has been used in pour!";
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
            dal.DoPager<M.CompanyInfo>(pi);
        }
    }
}
