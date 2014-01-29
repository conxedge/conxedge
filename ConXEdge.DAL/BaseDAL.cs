using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NH = ConXEdge.Nhibernate;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;
using M = ConXedge.Model;
using System.Data;
using System.Reflection;

namespace ConXEdge.DAL
{
    public class BaseDAL
    {
       // private static log4net.ILog log = log4net.LogManager.GetLogger("BaseDAL");
        M.Message msg = new M.Message();
        public log4net.ILog log = null;
        public BaseDAL()
        {
            log = log4net.LogManager.GetLogger("BaseDAL");
        }
        public BaseDAL(Type classType)
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        #region 事务处理
        /// <summary>
        /// 事务处理
        /// </summary>
        /// <param name="model">实体类</param> 
        /// <returns>0：操作失败，1：操作成功</returns>
        public M.Message EntitesOperations(List<NH.EntityModel> list)
        {
            M.Message msg = new M.Message();
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                proxy.EntitesOperations(list);
            }
            catch (Exception ex)
            {
                msg.State = M.MessageState.Deny;
                msg.Msg = "EntitesOperations." + ex.ToString();
                log.Error("EntitesOperations", ex);
            }
            return msg;

        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pi"></param>
        public M.Message GetList<T>(ref M.PageInfo pi)
        {
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();

                //创建实体
                //T model = (T)System.Activator.CreateInstance(typeof(T));
                if (pi.SelectType == 2)
                {
                    pi.List = proxy.GetEntities<T>(pi.Conditions, pi.OrderFields).ToList();
                }
                else
                {
                    int rCount = 0;
                    //创建实体
                    //T model = (T)System.Activator.CreateInstance(typeof(T));
                    pi.List = proxy.GetEntities<T>(pi.Conditions, pi.OrderFields, pi.PageIndex, pi.PageSize, ref rCount).ToList();
                    pi.RecordCount = rCount;
                    //总页数  
                    pi.PageCount = pi.RecordCount % pi.PageSize == 0 ? pi.RecordCount / pi.PageSize :
                        pi.RecordCount / pi.PageSize + 1;
                }
            }
            catch (Exception ex)
            {
                msg.State = M.MessageState.Deny;
                msg.Msg = "GetList:ModelType-" + typeof(T) + "." + ex.ToString();
                log.Error("GetList:ModelType-" + typeof(T), ex);
            }
            return msg;
        }

        /// <summary>
        /// 根据ID获取一条记录
        /// </summary>
        /// <param name="keyid">主键ID</param>
        /// <returns>实体类</returns>
        public T GetModelByID<T>(string keyid) where T : class
        {
            //创建实体
            T model = (T)System.Activator.CreateInstance(typeof(T));
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                model = (T)proxy.Get(typeof(T).FullName, keyid);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return model;
        }
        /// <summary>
        /// 获取所有类别信息
        /// </summary>
        /// <param name="delStatus">删除状态</param>
        /// <returns>实体集合</returns>
        public List<T> GetList<T>() where T : class
        {
            List<T> _listInfoType = new List<T>();
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                string _strTsql = string.Format(" from {0} c ", typeof(T).FullName);

                _listInfoType = proxy.GetEntities<T>(_strTsql).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return _listInfoType;
        }

        /// <summary>
        /// 用于分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pi"></param>
        public List<T> GetList<T>(List<ICriterion> Conditions, List<Order> OrderFields) where T : class
        {
            List<T> _listInfoType = new List<T>();
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                _listInfoType = proxy.GetEntities<T>(Conditions, OrderFields).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            return _listInfoType;
        }

        /// <summary>
        /// 用于分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pi"></param>
        public void DoPager<T>(M.PageInfo pi) where T : class
        {
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                int rCount = 0;
                //创建实体
                //T model = (T)System.Activator.CreateInstance(typeof(T));
                pi.List = proxy.GetEntities<T>(pi.Conditions, pi.OrderFields, pi.PageIndex, pi.PageSize, ref rCount).ToList();
                pi.RecordCount = rCount;
                //总页数  
                pi.PageCount = pi.RecordCount % pi.PageSize == 0 ? pi.RecordCount / pi.PageSize :
                    pi.RecordCount / pi.PageSize + 1;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }
           
        #endregion

        #region 增删改
        /// <summary>
        /// 新增或修改数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：操作失败，1：操作成功</returns>
        public M.Message SaveOrUpdate<T>(T model)
        {
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                proxy.SaveOrUpdate(model);
            }
            catch (Exception ex)
            {
                msg.State = M.MessageState.Deny;
                msg.Msg = "SaveOrUpdate:" + model.GetType() + "." + ex.ToString();
                log.Error("SaveOrUpdate:" + model.GetType(), ex);
            }
            return msg;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：添加失败，其它：添加成功（值为主键ID）</returns>
        public M.Message Add<T>(T model)
        {
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                object obj = proxy.Create(model);
            }
            catch (Exception ex)
            {
                log.Error("Add:" + model.GetType(), ex);
                msg.State = M.MessageState.Deny;
                msg.Msg = "Add:" + model.GetType() + "." + ex.ToString();
            }
            return msg;
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>0：修改失败，1：修改成功</returns>
        public M.Message Update<T>(T model)
        {
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                proxy.Update(model);
            }
            catch (Exception ex)
            {
                log.Error("Update:" + model.GetType(), ex);
                msg.State = M.MessageState.Deny;
                msg.Msg = "Update:" + model.GetType() + "." + ex.ToString();
            }
            return msg;
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>false：删除失败，true：删除成功</returns>
        public M.Message Delete<T>(T model)
        {
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                if (model != null)
                {
                    proxy.Delete(model);
                }
            }
            catch (Exception ex)
            {
                log.Error("Delete:" + model.GetType(), ex);
                msg.State = M.MessageState.Deny;
                msg.Msg = "Delete:" + model.GetType() + "." + ex.ToString();
            }
            return msg;
        }
        #endregion

        #region 获取记录
        /// <summary>
        /// 获取行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mse"></param>
        /// <returns></returns>
        public int GetCountSql(string sql,ref M.Message mse)
        {
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                return proxy.Query(sql).Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                mse.State = M.MessageState.Deny;
                mse.Msg = "GetCountSql:" + sql + "." + ex.ToString();
                log.Error("GetCountSql:" + sql, ex);
            }
            return 0;
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSetBySql(string sql,ref M.Message mse)
        {
            DataSet ds = new DataSet();
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                ds = proxy.Query(sql);
            }
            catch (Exception ex)
            {
                mse.State = M.MessageState.Deny;
                mse.Msg = "GetDataSetBySql:" + sql + "." + ex.ToString();
                log.Error("GetDataSetBySql:" + sql, ex);
            }
            return ds;
        }
        #endregion

        #region 执行Sql
        /// <summary>
        /// 执行Sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public M.Message Execute(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                NH.NHibernateProxy proxy = new NH.NHibernateProxy();
                proxy.Execute(sql);
            }
            catch (Exception ex)
            {
                msg.State = M.MessageState.Deny;
                msg.Msg = "Execute:" + sql + "." + ex.ToString();
                log.Error("Execute:" + sql, ex);
            }
            return msg;
        }
        #endregion
    }
}
