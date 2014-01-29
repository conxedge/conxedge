using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using NHibernate.Criterion;

namespace ConXedge.Model
{
    /// <summary>
    /// 分页类
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// 初始化PageInfo分页类
        /// </summary>
        public PageInfo() { }
        /// <summary>
        /// 初始化PageInfo分页类
        /// </summary>
        /// <param name="entityType">实体类类型</param>
        /// <param name="pageIndex">起始页</param>
        public PageInfo(Type entityType, int pageIndex)
        {
            this._entityType = entityType;
            this._pageIndex = pageIndex;
        }
        /// <summary>
        /// 初始化PageInfo分页类
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="conditions"></param>
        public PageInfo(Type entityType, int pageIndex, List<ICriterion> conditions)
        {
            this._entityType = entityType;
            this._pageIndex = pageIndex;
            this._conditions = conditions;
        }
        /// <summary>
        /// 初始化PageInfo分页类
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="conditions"></param>
        /// <param name="orders"></param>
        public PageInfo(Type entityType, int pageIndex, List<ICriterion> conditions, List<Order> orders)
        {
            this._entityType = entityType;
            this._pageIndex = pageIndex;
            this._conditions = conditions;
            this._orderFields = orders;
        }

        private Type _entityType;//类  
        /// <summary>
        /// 实体类类型
        /// </summary>
        public Type EntityType
        {
            get { return _entityType; }
            set { _entityType = value; }
        }
        private int _pageIndex = 1;//页号  
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        private List<ICriterion> _conditions;//条件  
        /// <summary>
        /// 查询条件参数列表
        /// </summary>
        public List<ICriterion> Conditions
        {
            get { return _conditions; }
            set { _conditions = value; }
        }
        private List<Order> _orderFields;//排序  
        /// <summary>
        /// 排序
        /// </summary>
        public List<Order> OrderFields
        {
            get { return _orderFields; }
            set { _orderFields = value; }
        }
        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }


        private int _recordCount;

        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }
        private int pageCount;

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }
        private System.Collections.IList list;

        public IList List
        {
            get { return list; }
            set { list = value; }
        }

        private int _selectType;
        public int SelectType
        {
            get { return _selectType; }
            set { _selectType = value; }
        }
    }  
}
