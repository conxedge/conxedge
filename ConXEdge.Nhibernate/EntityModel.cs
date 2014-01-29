using System;
using System.Collections.Generic;
using System.Text;

namespace ConXEdge.Nhibernate
{
    public class EntityModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityModel()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="operation">实体操作</param>
        public EntityModel(object entity, OperationMode operation)
            : this()
        {
            Entity = entity;
            Operation = operation;
        }

        /// <summary>
        /// 实体对象
        /// </summary>
        public object Entity
        {
            get;
            set;
        }

        /// <summary>
        /// 实体对象主键值，用于更新操作
        /// </summary>
        public object Key
        {
            get;
            set;
        }

        /// <summary>
        /// 实体操作
        /// </summary>
        public OperationMode Operation
        {
            get;
            set;
        }
    }
}
