using System;
using System.Collections.Generic;
using System.Text;

namespace ConXedge.Model
{
    /// <summary>
    /// 数据库操作类型。
    /// </summary>
    public class Message
    {
        public Message() {
            _state = MessageState.Success;
        }
        private string _msg;
        private DateTime _operateTime;
        private MessageState _state;
        /// <summary>
        /// 操作信息
        /// </summary>
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime OperateTime 
        {
            get { return _operateTime; }
            set { _operateTime = value; }
        }
        /// <summary>
        /// 操作结果
        /// </summary>
        public MessageState State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
    /// <summary>
    /// 操作结果类型
    /// </summary>
    public enum MessageState
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 操作失败
        /// </summary>
        Failure = 1,
        /// <summary>
        /// 操作异常
        /// </summary>
        Deny = 2
    }
}
