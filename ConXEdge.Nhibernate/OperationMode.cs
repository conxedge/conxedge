using System;
using System.Collections.Generic;
using System.Text;

namespace ConXEdge.Nhibernate
{
    /// <summary>
    /// Nhibernate操作模式
    /// </summary>
    public enum OperationMode
    {
        /// <summary>
        /// 新增记录
        /// </summary>
        Add = 1,
        /// <summary>
        /// 更新记录
        /// </summary>
        Update = 2,
        /// <summary>
        /// 删除记录
        /// </summary>
        Delete = 3,
        /// <summary>
        /// 新增或更新记录，自动判断
        /// </summary>
        AddOrUpdate = 4
    }
}
