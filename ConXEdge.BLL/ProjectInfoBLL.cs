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
    public class ProjectInfoBLL
    {
        BaseDAL dal = new BaseDAL(typeof(ProjectInfoBLL));

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add(M.ProjectInfo model)
        {
            M.Message m = IsExtits(model.ProjectName, "");
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
        public M.Message Update(M.ProjectInfo model)
        {
            M.Message m = IsExtits(model.ProjectName, model.Projectid);
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
        public M.Message SaveOrUpdate(M.ProjectInfo model)
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
            
            M.ProjectInfo model = GetModelByID(id);            
       
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("ProjectID", id));
            M.PourInfo[] listPourInfo = dal.GetList<M.PourInfo>(Conditions, null).ToArray();
            foreach (M.PourInfo child in listPourInfo)
            {
                try
                {
                    m = dal.Execute(string.Format("delete Pour2Level where PourID='{0}'", child.Pourid));
                    m = dal.Execute(string.Format("delete Pour2Target where PourID='{0}'", child.Pourid));
                    m = dal.Execute(string.Format("delete PourInfo where PourID='{0}'", child.Pourid));
                    m = dal.Execute(string.Format("delete PourLocation where PourID='{0}'", child.Pourid));
                    m = dal.Execute(string.Format("delete PourLocation2Target where PourID='{0}'", child.Pourid));                    
                }
                catch (Exception ex)
                {
                    m.State = M.MessageState.Failure;
                    m.Msg = ex.Message;
                }
            }
            m = dal.Execute(string.Format("delete Project2Logger where ProjectID='{0}'", id));
            m = dal.Execute(string.Format("delete ProjectInfo where ProjectID='{0}'", id));
            return m;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public List<M.ProjectInfo> GetList(string CompanyID)
        {
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Companyid", CompanyID));
            return dal.GetList<M.ProjectInfo>(Conditions, null);
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public M.ProjectInfo GetModelByID(string keyid)
        {
            return dal.GetModelByID<M.ProjectInfo>(keyid);
        }


        /// <summary>
        /// 根据编号判断是否存在。
        /// </summary>
        public M.Message IsExtits(string Name, string pid)
        {
            M.Message msg = new M.Message();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("ProjectName", Name));

            List<M.ProjectInfo> list = dal.GetList<M.ProjectInfo>(Conditions, null);
            if (list == null || list.Count == 0)
            {
                msg.State = M.MessageState.Success;
                msg.Msg = "Project name is not exists!";
            }
            else
            {
                if (!string.IsNullOrEmpty(pid) && pid == list[0].Projectid)
                {
                    msg.State = M.MessageState.Success;
                    msg.Msg = "Project name is not exists!";
                }
                else
                {
                    msg.State = M.MessageState.Failure;
                    msg.Msg = "Project name is exists!";
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
            dal.DoPager<M.ProjectInfo>(pi);
        }

    }
}
