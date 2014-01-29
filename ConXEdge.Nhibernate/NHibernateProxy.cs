using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;

namespace ConXEdge.Nhibernate
{
    public class NHibernateProxy
    {
        private ISession session;
        private static Configuration DynamicCfg = null;
        private static ISessionFactory sessionFactory;
        private static Hashtable htDataTable = null;
        private static string _configFileName = "";
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(NHibernateProxy));

        /// <summary>
        /// 数据访问基类
        /// </summary>
        /// <param name="configFileName">配置文件名称：默认为空，如果连接多数据库时传入配置文件名称，配置文件需放置在根目录下</param>
        public NHibernateProxy(string configFileName = "")
        {
            if (configFileName != _configFileName)
            {
                _configFileName = configFileName;
                if (sessionFactory != null)
                    sessionFactory = null;
            }
            if (sessionFactory == null)
            {
                if (string.IsNullOrEmpty(configFileName))
                {
                    DynamicCfg = new Configuration().Configure();
                    sessionFactory = DynamicCfg.BuildSessionFactory();
                }
                else
                {
                    string _strConfigAddress = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + configFileName;//指定数据库配置
                    DynamicCfg = new Configuration().Configure(_strConfigAddress);
                    sessionFactory = DynamicCfg.BuildSessionFactory();
                }
                if (htDataTable == null)
                {
                    htDataTable = new Hashtable();
                }
            }
        }

        /// <summary>
        /// 创建实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        public object Create(object entity)
        {
            Object newID = null;
            try
            {
                NHibernate.ITransaction transaction = this.Session.BeginTransaction();
                newID = this.Session.Save(entity);
                transaction.Commit();
            }
            catch (Exception exception)
            {
                this.Session.Transaction.Rollback();
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
            return newID;
        }

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void Delete(object entity)
        {
            try
            {
                NHibernate.ITransaction transaction = this.Session.BeginTransaction();
                this.Session.Delete(entity);
                transaction.Commit();
            }
            catch (Exception exception)
            {
                this.Session.Transaction.Rollback();
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
        }

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="query">查询语句</param>
        public void Delete(string query)
        {
            try
            {
                NHibernate.ITransaction transaction = this.Session.BeginTransaction();
                this.Session.Delete(query);
                transaction.Commit();
            }
            catch (Exception exception)
            {
                this.Session.Transaction.Rollback();
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
        }

        /// <summary>
        /// 删除多个实体对象
        /// </summary>
        /// <param name="entitys">实体对象集合</param>
        public void Delete(IList entitys)
        {
            try
            {
                NHibernate.ITransaction transaction = this.Session.BeginTransaction();
                foreach (object entity in entitys)
                    this.Session.Delete(entity);
                transaction.Commit();
            }
            catch (Exception exception)
            {
                this.Session.Transaction.Rollback();
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
        }

        /// <summary>
        /// 执行多表操作
        /// </summary>
        /// <param name="list">操作对象的列表，包含操作对象，操作内容等值</param>
        public void EntitesOperations(IList<EntityModel> list)
        {
            try
            {
                NHibernate.ITransaction transaction = this.Session.BeginTransaction();
                foreach (EntityModel entityModel in list)
                {
                    switch (entityModel.Operation)
                    {
                        case OperationMode.Add:
                            this.Session.Save(entityModel.Entity);
                            break;
                        case OperationMode.Delete:
                            this.Session.Delete(entityModel.Entity);
                            break;
                        case OperationMode.Update:
                            if (entityModel.Key != null)
                                this.Session.Update(entityModel.Entity, entityModel.Key);
                            else
                                this.Session.Update(entityModel.Entity);
                            break;
                        case OperationMode.AddOrUpdate:
                            this.Session.SaveOrUpdate(entityModel.Entity);
                            break;
                    }
                }
                if (!transaction.IsActive)
                {
                    transaction = this.Session.BeginTransaction();
                }
                transaction.Commit();
            }
            catch (Exception exception)
            {
                this.Session.Transaction.Rollback();
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
        }

        /// <summary>
        /// 根据HQL，获取实体对象集合
        /// </summary>
        /// <param name="HQL">HQL SQL查询语句</param>
        /// <returns>实体对象集合</returns>
        public IList GetEntities(string HQL)
        {
            IList list = null;
            try
            {
                IQuery query = this.Session.CreateQuery(HQL);
                list = query.List();
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
            return list;
        }

        /// <summary>
        /// 根据HQL，返回DataSet对象，包括查询列名
        /// </summary>
        /// <param name="HQL">HQL语句</param>
        /// <returns></returns>
        public DataSet Query(string HQL)
        {
            DataSet ds = new DataSet("returnList");
            try
            {
                IDbCommand cmd = this.Session.Connection.CreateCommand();
                cmd.CommandText = HQL;
                IDataReader rs = cmd.ExecuteReader();
                ds.Tables.Add(DataReaderToDataTable(rs));
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
            return ds;
        }

        /// <summary>
        /// 根据HQL，获取实体对象集合,一般情况只用于单表操作
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="HQL">HQL SQL查询语句</param>
        /// <returns>实体对象集合</returns>
        public IList<T> GetEntities<T>(string HQL)
        {
            IList<T> list = null;
            try
            {
                IQuery query = this.Session.CreateQuery(HQL);
                list = query.List<T>();
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
            return list;
        }

        /// <summary>
        /// 返回符合条件的所有记录
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="querylist">查询条件</param>
        /// <param name="orderList">排序条件</param>
        /// <returns></returns>
        public IList<T> GetEntities<T>(IList<ICriterion> querylist, IList<Order> orderList)
        {
            int iCount = 0;
            return GetEntities<T>(querylist, orderList, 0, 0, ref iCount);
        }

        /// <summary>
        /// 根据一定的条件查询出记录列表,当pageSize==0是，返回所有符合条件的记录，否则获取当前分页数据
        /// </summary>
        /// <typeparam name="T">要查询的对象的类型</typeparam>
        /// <param name="querylist">要查询的条件的</param>
        /// <param name="orderList">排序</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="recordCount">记录总数</param>
        /// <returns></returns>     
        public IList<T> GetEntities<T>(IList<ICriterion> querylist, IList<Order> orderList, int currentPageIndex, int pageSize, ref int recordCount)
        {
            IList<T> list = null;
            try
            {
                ICriteria criteria = this.Session.CreateCriteria(typeof(T));
                #region 组合查询条件
                if (querylist != null)
                {
                    foreach (ICriterion query in querylist)
                    {
                        criteria.Add(query);
                    }
                }
                #endregion
                ICriteria pageCrit = CriteriaTransformer.Clone(criteria);
                recordCount = Convert.ToInt32(criteria.SetProjection(Projections.RowCount()).UniqueResult());

                //设置排序
                if (orderList != null)
                {
                    foreach (Order order in orderList)
                    {
                        pageCrit.AddOrder(order);
                    }
                }
                //设置分页  
                if (pageSize > 0)
                    pageCrit.SetFirstResult((currentPageIndex - 1) * pageSize).SetMaxResults(pageSize);
                list = pageCrit.List<T>();
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
            return list;
        }

        /// <summary>
        /// 根据一定的条件查询出记录列表,当pageSize==0是，返回所有符合条件的记录，否则获取当前分页数据
        /// </summary>
        /// <param name="Hql">HQL语句</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="recordCount">记录总数</param>
        /// <returns></returns>     
        public DataTable GetRecordByHql(string Hql, int currentPageIndex, int pageSize, ref int recordCount)
        {
            IList list = null;
            DataTable dt = new DataTable();
            try
            {
                IQuery query = this.Session.CreateQuery(Hql);
                recordCount = query.List().Count;
                //设置分页  
                if (pageSize > 0)
                    query.SetFirstResult((currentPageIndex - 1) * pageSize).SetMaxResults(pageSize);
                list = query.List();
                Hql = Hql.ToLower().Trim();
                if (Hql.StartsWith("select "))//返回数据集合
                {
                    for (int i = 0; i < query.ReturnAliases.Length; i++)
                    {
                        dt.Columns.Add(query.ReturnAliases[i], query.ReturnTypes[i].ReturnedClass);
                    }
                    if (list != null && list.Count > 0)
                    {
                        if (dt.Columns.Count > 1 || currentPageIndex > 0)
                        {
                            foreach (object[] obj in list)
                            {
                                object[] objNew = new object[dt.Columns.Count];
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    objNew[i] = obj[i];
                                }
                                dt.LoadDataRow(objNew, true);
                            }
                        }
                        else
                        {
                            foreach (object obj in list)
                            {
                                dt.LoadDataRow(new object[] { obj }, true);
                            }
                        }
                    }
                }
                else//返回实体对象集合
                {
                    for (int i = 0; i < query.ReturnTypes.Length; i++)
                    {
                        PropertyInfo[] p = query.ReturnTypes[i].ReturnedClass.GetProperties();
                        for (int j = 0; j < p.Length - 2; j++)
                        {
                            dt.Columns.Add(string.Format("{0}.{1}", query.ReturnTypes[i].ReturnedClass.Name, p[j].Name), p[j].PropertyType);
                        }
                    }
                    if (list != null && list.Count > 0)
                    {
                        object[] objs = new object[dt.Columns.Count];
                        int iIndex = 0;
                        Hashtable htProperty = new Hashtable();   
                        foreach (object obj in list)
                        {
                            if (obj is IList)
                            {
                                int i = 0;
                                iIndex = 0;
                                foreach (object objEntity in (IList)obj)
                                {
                                    PropertyInfo[] p = null;
                                    if (htProperty[iIndex] != null)
                                        p = (PropertyInfo[])htProperty[iIndex];
                                    else
                                    {
                                        p = objEntity.GetType().GetProperties();
                                        htProperty.Add(iIndex, p);
                                    }
                                    for (int j = 0; j < p.Length - 2; j++)
                                    {
                                        objs[i] = p[j].GetValue(objEntity, null);
                                        i++;
                                    }
                                    iIndex++;
                                }
                            }
                            else
                            {
                                int i = 0;
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    objs[i] = obj.GetType().GetProperty(dc.ColumnName.Replace(obj.GetType().Name + ".", "")).GetValue(obj, null);
                                    i++;
                                }       
                            }
                            dt.LoadDataRow(objs, true);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
            return dt;
        }

        /// <summary>
        /// 取得实体对象
        /// </summary>
        /// <param name="entityName">实体名</param>
        /// <param name="entityID">实体ID</param>
        /// <returns>实体对象</returns>
        public object Get(string entityName, object entityID)
        {
            object obj2 = null;
            try
            {
                obj2 = this.Session.Get(entityName, entityID);
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {

                this.Session.Close();
            }
            return obj2;
        }

        /// <summary>
        /// 更新实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void Update(object entity)
        {
            try
            {
                NHibernate.ITransaction transaction = this.Session.BeginTransaction();
                this.Session.Update(entity);
                transaction.Commit();
            }
            catch (Exception exception)
            {
                this.Session.Transaction.Rollback();
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
        }

        /// <summary>
        /// 更新实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="key">主键</param>
        public void Update(object entity, object key)
        {
            try
            {
                NHibernate.ITransaction transaction = this.Session.BeginTransaction();
                this.Session.Update(entity, key);
                transaction.Commit();
            }
            catch (Exception exception)
            {
                this.Session.Transaction.Rollback();
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
        }

        /// <summary>
        /// 添加或者更新操作
        /// </summary>
        /// <param name="entity"></param>
        public void SaveOrUpdate(object entity)
        {
            try
            {
                NHibernate.ITransaction transaction = this.Session.BeginTransaction();
                this.Session.SaveOrUpdate(entity);
                transaction.Commit();
            }
            catch (Exception exception)
            {
                this.Session.Transaction.Rollback();
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
        }

        /// <summary>
        /// 操作存储过程
        /// </summary>
        /// <param name="ProduceName">存储过程名</param>
        /// <param name="obj">参数级</param>
        /// <returns>实体对象集合</returns>
        public IList GetNamedQuery(string ProduceName, object[] obj)
        {
            NHibernate.ITransaction transaction = this.Session.BeginTransaction();
            IQuery query = this.Session.GetNamedQuery(ProduceName);
            if (obj != null)
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    query.SetParameter(i, obj[i]);
                }
            }
            IList list = query.List();
            transaction.Commit();
            return list;
        }

        #region 内部函数
        /// <summary>
        /// 将IDataReader转成DataTable
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        private DataTable DataReaderToDataTable(IDataReader dataReader)
        {
            DataTable datatable = new DataTable();
            DataTable schemaTable = dataReader.GetSchemaTable();
            try
            {
                foreach (DataRow myRow in schemaTable.Rows)
                {
                    DataColumn myDataColumn = new DataColumn();
                    myDataColumn.DataType = myRow[0].GetType();
                    myDataColumn.ColumnName = myRow[0].ToString();
                    if (datatable.Columns.Contains(myDataColumn.ColumnName))
                    {
                        bool state = false;
                        int i = 1;
                        while (!state)
                        {
                            if (!datatable.Columns.Contains(myDataColumn.ColumnName + i))
                            {
                                state = true;
                                myDataColumn.ColumnName = myDataColumn.ColumnName + i;
                            }
                        }
                    }
                    datatable.Columns.Add(myDataColumn);
                }

                while (dataReader.Read())
                {
                    DataRow myDataRow = datatable.NewRow();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        myDataRow[i] = dataReader[i];
                    }
                    datatable.Rows.Add(myDataRow);
                }
                dataReader.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                log.Error(String.Format("{0}:{1}", "将IDataReader转化成DataTable时出错！", ex.Message));
                return null;
            }
        }

        /// <summary>
        /// 根据SQL获取DataTable表结构
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        private DataTable GetSchemaTable(string Sql)
        {
            IDbCommand cmd = this.Session.Connection.CreateCommand();
            cmd.CommandText = Sql;
            IDataReader rs = cmd.ExecuteReader();

            DataTable datatable = new DataTable();
            DataTable schemaTable = rs.GetSchemaTable();
            try
            {
                foreach (DataRow myRow in schemaTable.Rows)
                {
                    DataColumn myDataColumn = new DataColumn();
                    myDataColumn.DataType = Type.GetType(myRow["DataType"].ToString());
                    myDataColumn.ColumnName = myRow[0].ToString();
                    if (datatable.Columns.Contains(myDataColumn.ColumnName))
                    {
                        bool state = false;
                        int i = 1;
                        while (!state)
                        {
                            if (!datatable.Columns.Contains(myDataColumn.ColumnName + i))
                            {
                                state = true;
                                myDataColumn.ColumnName = myDataColumn.ColumnName + i;
                            }
                        }
                    }
                    datatable.Columns.Add(myDataColumn);
                }
                rs.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                log.Error(String.Format("{0}:{1}", "将IDataReader转化成DataTable时出错！", ex.Message));
                return null;
            }
        }

        /// <summary>
        /// 判断是否是MSSql数据库
        /// </summary>
        /// <returns></returns>
        public bool CheckIsMSSQL()
        {
            return DynamicCfg.GetProperty("dialect").ToLower().Contains("mssql");
        }

        #endregion 内部函数

        #region 非实体类表操作
        /// <summary>
        /// 非实体类表操作
        /// </summary>
        /// <param name="SQL">普通SQL语句</param>
        public void Execute(string SQL)
        {
            try
            {
                NHibernate.ITransaction transaction = this.Session.BeginTransaction();
                System.Data.IDbCommand cmd = this.session.Connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;
                transaction.Enlist(cmd);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception exception)
            {
                this.Session.Transaction.Rollback();
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {

                this.Session.Close();
            }
        }

        /// <summary>
        /// 根据SQL，返回DataSet对象，包括查询列名
        /// </summary>
        /// <param name="SQL">SQL原语语句</param>
        /// <returns></returns>
        public DataSet NativeQuery(string SQL)
        {
            DataSet ds = new DataSet();
            try
            {
                IDbCommand cmd = this.Session.Connection.CreateCommand();
                cmd.CommandText = SQL;
                IDataReader rs = cmd.ExecuteReader();
                ds.Tables.Add(DataReaderToDataTable(rs));
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
            return ds;
        }

        /// <summary>
        /// 根据SQL，返回DataSet对象，包括查询列名
        /// </summary>
        /// <param name="SQL">SQL原语语句</param>
        /// <param name="paramList">参数列表</param>
        /// <returns></returns>
        public DataSet NativeQuery(string SQL, List<SqlParameter> paramList)
        {
            DataSet ds = new DataSet();
            try
            {
                IDbCommand cmd = this.Session.Connection.CreateCommand();
                cmd.CommandText = SQL;
                if (paramList != null)
                {
                    foreach (SqlParameter o in paramList)
                    {
                        cmd.Parameters.Add(o);
                    }
                }
                IDataReader rs = cmd.ExecuteReader();
                ds.Tables.Add(DataReaderToDataTable(rs));
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
            return ds;
        }

        /// <summary>
        /// 根据一定的条件查询出记录列表,当pageSize==0是，返回所有符合条件的记录，否则获取当前分页数据
        /// </summary>
        /// <param name="Sql">Sql语句</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="recordCount">记录总数</param>
        /// <returns></returns>     
        public DataTable GetRecordBySql(string Sql, int currentPageIndex, int pageSize, ref int recordCount)
        {
            IList list = null;
            DataTable dt = new DataTable();
            try
            {
                ISQLQuery query = this.Session.CreateSQLQuery(Sql);
                recordCount = query.List().Count;
                //设置分页  
                if (pageSize > 0)
                {
                    if (CheckIsMSSQL())
                    {
                        if (!Sql.ToLower().Replace(" ", "").StartsWith("selecttop"))
                        {
                            int i = Sql.ToLower().IndexOf("select ");
                            Sql = string.Format("select top {0} {1}", recordCount, Sql.Substring(i + 7));
                            query = this.Session.CreateSQLQuery(Sql);
                        }
                    }
                    Sql = string.Format("Select * from ({0}) t1", Sql);
                    query = this.Session.CreateSQLQuery(Sql);
                    query.SetFirstResult((currentPageIndex - 1) * pageSize).SetMaxResults(pageSize);
                }
                list = query.List();
                if (htDataTable.Contains(Sql))
                {
                    List<DataColumn> listColumns = (List<DataColumn>)htDataTable[Sql];
                    dt.Columns.Clear();
                    foreach (DataColumn dc in listColumns)
                    {
                        DataColumn column = new DataColumn();
                        column.DataType = dc.DataType;
                        column.ColumnName = dc.ColumnName;
                        dt.Columns.Add(column);
                    }
                }
                else
                {
                    dt = this.GetSchemaTable(Sql);
                    dt.TableName = "table";
                    List<DataColumn> listColumns = new List<DataColumn>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        DataColumn column = new DataColumn();
                        column.DataType = dc.DataType;
                        column.ColumnName = dc.ColumnName;
                        listColumns.Add(column);
                    }
                    htDataTable.Add(Sql, listColumns);
                }
                if (list != null && list.Count > 0)
                {
                    if ((dt.Columns.Count > 1 || currentPageIndex > 0) && list[0] is object[])
                    {
                        foreach (object[] obj in list)
                        {
                            object[] objNew = new object[dt.Columns.Count];
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                objNew[i] = obj[i];
                            }
                            dt.LoadDataRow(objNew, true);
                        }
                    }
                    else
                    {
                        foreach (object obj in list)
                        {
                            dt.LoadDataRow(new object[] { obj }, true);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                throw exception;
            }
            finally
            {
                this.Session.Close();
            }
            return dt;
        }
        #endregion

        #region 属性
        /// <summary>
        /// Session
        /// </summary>
        protected ISession Session
        {
            get
            {
                if ((this.session == null) || !this.session.IsOpen)
                {
                    this.session = this.SessionFactory.OpenSession();
                }
                return this.session;
            }
        }

        /// <summary>
        /// SessionFactory
        /// </summary>
        protected ISessionFactory SessionFactory
        {
            get
            {
                return sessionFactory;
            }
        }
        #endregion 属性
    }
}
