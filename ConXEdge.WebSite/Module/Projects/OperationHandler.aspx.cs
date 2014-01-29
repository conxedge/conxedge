using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using B = ConXEdge.BLL;
using M = ConXedge.Model;
using Hzjg.Common;
using ConXEdge.Nhibernate;
using NHibernate.Criterion;

namespace ConXEdge.WebSite.Module.Projects
{
    public partial class OperationHandler : AppCode.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ClearContent();
            string sType = Request["sType"];
            switch (sType)
            {
                case "delProject": Response.Write(delProjectInfo()); break;
                case "delProduct": Response.Write(delProductInfo()); break;
                case "delLogger": Response.Write(delLoggerInfo()); break;
                case "removeBinding": Response.Write(removeBinding()); break;
                case "delPour": Response.Write(delPourInfo()); break;
                case "delContact": Response.Write(delContactInfo()); break;
                case "delDefaultTarget": Response.Write(delDefaultTarget()); break;
                case "delLevel": Response.Write(delLevelInfo()); break;
                case "delProject2Logger": Response.Write(delProject2Logger()); break;
                case "delPour2Level": Response.Write(delPour2Level()); break;
                case "delPour2Target": Response.Write(delPour2Target()); break;
                case "delPour2Location": Response.Write(delPour2Location()); break;                    
                case "getProject": Response.Write(GetProjectJSON()); break;
                case "getLogger": Response.Write(GetLoggerJSON(Request["projectid"])); break;
                case "getProduct": Response.Write(GetProductJSON()); break;
                case "getChannelNo": Response.Write(GetChannelNoJSON()); break;
                case "getMaturityMethod": Response.Write(GetMaturityMethodJSON()); break;
                case "getContact": Response.Write(GetContactJSON()); break;
                case "getStopType": Response.Write(GetStopTypeJSON()); break;
                case "getPourType": Response.Write(GetPourTypeJSON()); break;
                case "getMonitorType": Response.Write(GetMonitorTypeJSON()); break;                    
                case "getLoggingStart": Response.Write(GetLoggingStartJSON(Request["LoggerID"], Request["ChannelID"])); break;
                case "PourStart": Response.Write(PourStart(Request["pourid"])); break;
                default: break;
            }
            Response.End();
        }

        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <returns></returns>
        private string delProjectInfo()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.ProjectInfoBLL bll = new B.ProjectInfoBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除产品信息
        /// </summary>
        /// <returns></returns>
        private string delProductInfo()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.ProductInfoBLL bll = new B.ProductInfoBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除Logger信息
        /// </summary>
        /// <returns></returns>
        private string delLoggerInfo()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.LoggerInfoBLL bll = new B.LoggerInfoBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除logger绑定信息
        /// </summary>
        /// <returns></returns>
        private string removeBinding()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.LoggerInfoBLL bll = new B.LoggerInfoBLL();
            M.Message msg = bll.RemoveBinding(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除Pour信息
        /// </summary>
        /// <returns></returns>
        private string delPourInfo()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.PourInfoBLL bll = new B.PourInfoBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除Contact信息
        /// </summary>
        /// <returns></returns>
        private string delContactInfo()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.ContactInfoBLL bll = new B.ContactInfoBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除Default Target信息
        /// </summary>
        /// <returns></returns>
        private string delDefaultTarget()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.DefaultTargetBLL bll = new B.DefaultTargetBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除Level信息
        /// </summary>
        /// <returns></returns>
        private string delLevelInfo()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.LevelInfoBLL bll = new B.LevelInfoBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除Project2Logger信息
        /// </summary>
        /// <returns></returns>
        private string delProject2Logger()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.Project2LoggerBLL bll = new B.Project2LoggerBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除Pour2Level信息
        /// </summary>
        /// <returns></returns>
        private string delPour2Level()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.Pour2LevelBLL bll = new B.Pour2LevelBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除Pour2Target信息
        /// </summary>
        /// <returns></returns>
        private string delPour2Target()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.Pour2TargetBLL bll = new B.Pour2TargetBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 删除Pour2Location信息
        /// </summary>
        /// <returns></returns>
        private string delPour2Location()
        {
            string sResult = string.Empty;
            string pid = Request["pid"];
            B.PourLocationBLL bll = new B.PourLocationBLL();
            M.Message msg = bll.DeleteByID(pid);
            if (msg.State != M.MessageState.Success)
            {
                sResult = msg.Msg;
            }
            return sResult;
        }

        /// <summary>
        /// 获取项目信息
        /// </summary>
        /// <returns></returns>
        private string GetProjectJSON()
        {
            string _strResult = string.Empty;
            B.ProjectInfoBLL bll = new B.ProjectInfoBLL();
            List<M.ProjectInfo> list = bll.GetList(base.CurrentUserInfo.Companyid);
            if (list.Count > 0)
            {
                _strResult = JsonHelper.ToJson(list);
                _strResult = _strResult.Substring(1, _strResult.Length - 1);
                _strResult = "[{\"_projectid\":\"\",\"_projectname\":\"　\"},"
                    + _strResult;//添加全部 默认选择
            }
            else
            {
                _strResult = "[{\"_projectid\":\"\",\"_projectname\":\"　\"}]";
            }
            return _strResult;
        }

        /// <summary>
        /// 获取Logger信息
        /// </summary>
        /// <returns></returns>
        private string GetLoggerJSON(string ProjectID)
        {
            string _strResult = string.Empty;
            B.Project2LoggerBLL bll = new B.Project2LoggerBLL();
            List<M.VwProject2Logger> list = bll.GetListByProjectID(ProjectID);
            if (list.Count > 0)
            {
                _strResult = JsonHelper.ToJson(list);
                _strResult = _strResult.Substring(1, _strResult.Length - 1);
                _strResult = "[{\"_loggerid\":\"\",\"_loggercode\":\"　\"}," + _strResult;//添加全部 默认选择
            }
            else
            {
                _strResult = "[{\"_loggerid\":\"\",\"_loggercode\":\"　\"}]";
            }
            return _strResult;
        }

        /// <summary>
        /// 获取Product信息
        /// </summary>
        /// <returns></returns>
        private string GetProductJSON()
        {
            string _strResult = string.Empty;
            B.ProductInfoBLL bll = new B.ProductInfoBLL();
            List<M.ProductInfo> list = bll.GetList(base.CurrentUserInfo.Companyid);
            if (list.Count > 0)
            {
                _strResult = JsonHelper.ToJson(list);
                _strResult = _strResult.Substring(1, _strResult.Length - 1);
                _strResult = "[{\"_productid\":\"\",\"_code\":\"　\"},"
                    + _strResult;//添加全部 默认选择
            }
            else
            {
                _strResult = "[{\"_productid\":\"\",\"_code\":\"　\"}]";
            }
            return _strResult;
        }

        /// <summary>
        /// 获取Contact信息
        /// </summary>
        /// <returns></returns>
        private string GetContactJSON()
        {
            string _strResult = string.Empty;
            B.ContactInfoBLL bll = new B.ContactInfoBLL();
            List<M.ContactInfo> list = bll.GetList(base.CurrentUserInfo.Companyid);
            if (list.Count > 0)
            {
                _strResult = JsonHelper.ToJson(list);
                _strResult = _strResult.Substring(1, _strResult.Length - 1);
                _strResult = "[{\"_contactid\":\"\",\"_contact\":\"　\"},"
                    + _strResult;//添加全部 默认选择
            }
            else
            {
                _strResult = "[{\"_contactid\":\"\",\"_contact\":\"　\"}]";
            }
            return _strResult;
        }

        /// <summary>
        /// 获取ChannelNo信息
        /// </summary>
        /// <returns></returns>
        private string GetChannelNoJSON()
        {
            string _strResult = string.Empty;
            _strResult = "[{\"value\":\"\",\"text\":\"　\"},{\"value\":\"1\",\"text\":\"1\"},{\"value\":\"2\",\"text\":\"2\"},{\"value\":\"3\",\"text\":\"3\"},{\"value\":\"4\",\"text\":\"4\"}]";
            return _strResult;
        }

        /// <summary>
        /// 获取Maturity Method信息
        /// </summary>
        /// <returns></returns>
        private string GetMaturityMethodJSON()
        {
            string _strResult = string.Empty;
            _strResult = "[{\"value\":\"\",\"text\":\"　\"},{\"value\":\"Arenhius\",\"text\":\"Arenhius\"},{\"value\":\"Nurse Saul\",\"text\":\"Nurse Saul\"}]";
            return _strResult;
        }

        /// <summary>
        /// 获取Stop Type信息
        /// </summary>
        /// <returns></returns>
        private string GetStopTypeJSON()
        {
            string _strResult = string.Empty;
            _strResult = "[{\"value\":\"\",\"text\":\"　\"},{\"value\":\"1\",\"text\":\"Channel Achieves Final Target\"},{\"value\":\"2\",\"text\":\"All Channels Have Achieved Final Targets\"},{\"value\":\"3\",\"text\":\"X Hours After Channel Achieves Final Target\"},{\"value\":\"4\",\"text\":\"X Hours After All Channels Have Achieved Final Targets\"},{\"value\":\"5\",\"text\":\"Logger is Stopped\"}]";
            return _strResult;
        }

        /// <summary>
        /// 获取Pour Type信息
        /// </summary>
        /// <returns></returns>
        private string GetPourTypeJSON()
        {
            string _strResult = string.Empty;
            _strResult = "[{\"value\":\"\",\"text\":\"　\"},{\"value\":\"1\",\"text\":\"Start logger later\"},{\"value\":\"2\",\"text\":\"Logger already started\"}]";
            return _strResult;
        }

        /// <summary>
        /// 获取Monitor Type信息
        /// </summary>
        /// <returns></returns>
        private string GetMonitorTypeJSON()
        {
            string _strResult = string.Empty;
            _strResult = "[{\"value\":\"\",\"text\":\"　\"},{\"value\":\"1\",\"text\":\"Equivalent Age\"},{\"value\":\"2\",\"text\":\"Temperature Only\"}]";
            return _strResult;
        }

        private string GetLoggingStartJSON(string LoggerID, string ChannelNo)
        {
            StringBuilder sb = new StringBuilder();
            NHibernateProxy proxy = new NHibernateProxy();
            List<ICriterion>  Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Loggerid", LoggerID));
            Conditions.Add(Expression.Eq("ChannelNo", int.Parse(ChannelNo)));
            Conditions.Add(Expression.Eq("EventType", 22));
            Conditions.Add(Expression.Eq("Flags", 0));
            //Conditions.Add(Expression.Eq("EventType", 18));
            
            List<Order>  orders = new List<Order>();
            orders.Add(new Order("CurrentTime", false));
            IList<M.LoggerEvents> listEvents = proxy.GetEntities<M.LoggerEvents>(Conditions, orders);
            sb.Append("[{\"value\":\" \",\"text\":\"　\"}");
            if (listEvents.Count > 0)
            {
                for (int i = 0; i < (listEvents.Count >= 3 ? 3 : listEvents.Count); i++)
                {
                    sb.Append(",{\"value\":\"");
                    sb.Append(listEvents[i].CurrentTime);
                    sb.Append("\",\"text\":\"");
                    Conditions = new List<ICriterion>();
                    Conditions.Add(Expression.Eq("EventStartid", listEvents[i].Eventid));
                    IList<M.LoggerEvents> listEndEvents = proxy.GetEntities<M.LoggerEvents>(Conditions, null);
                    if (listEndEvents != null && listEndEvents.Count > 0)
                    {
                        sb.Append(listEvents[i].CurrentTime.ToString("dd/MM/yyyy HH:mm:ss") 
                            + "["
                            + listEndEvents[0].CurrentTime.ToString("dd/MM/yyyy HH:mm:ss")
                            + "]") ;
                    }
                    else
                    {
                        sb.Append(listEvents[i].CurrentTime.ToString("dd/MM/yyyy HH:mm:ss"));
                    }
                    sb.Append("\"}");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        private string PourStart(string pid) 
        {
            string str = "";
            NHibernateProxy proxy = new NHibernateProxy();
            List<EntityModel> listModel = new List<EntityModel>();
            B.PourInfoBLL bll = new B.PourInfoBLL();
            M.PourInfo model = bll.GetModelByID(pid);
            if (model != null)
            {
                B.LoggerInfoBLL bllLogger = new B.LoggerInfoBLL();
                B.PourLocationBLL bllLoc = new B.PourLocationBLL();
                List<M.VwPourLocation> listLoc = bllLoc.GetListByPourID(pid);
                foreach (M.VwPourLocation c in listLoc)
                {
                    if (!(c.Status == "0" || c.Status == "1"))
                        continue;
                    #region 判断Logger是否已经被其它Pour使用，并更新LoggerInfo
                    bool bFlag = false;
                    foreach (EntityModel em in listModel)
                    {
                        if (em.Entity.GetType() == typeof(M.LoggerInfo))
                        {
                            if (((M.LoggerInfo)em.Entity).Loggerid == c.Loggerid)
                            {
                                bFlag = true;
                            }
                        }
                    }
                    if (!bFlag)
                    {
                        M.LoggerInfo logger = bllLogger.GetModelByID(c.Loggerid);
                        if (logger != null && !string.IsNullOrEmpty(logger.CurrentPourid))
                        {
                            B.PourInfoBLL bllPour = new B.PourInfoBLL();
                            M.PourInfo modelPour = bllPour.GetModelByID(logger.CurrentPourid);
                            str = string.Format("Logger[{0}] has been userd by Pour[{1}]!"
                                , logger.LoggerCode, modelPour.PourName);
                            return str;
                        }
                        logger.CurrentPourid = c.Pourid;
                        listModel.Add(new EntityModel(logger, OperationMode.Update));
                    }
                    #endregion
                    M.PourLoggerStatus loggerStatus = new M.PourLoggerStatus();
                    loggerStatus.Id = Guid.NewGuid().ToString();
                    loggerStatus.ChannelNo = (int)c.ChannelNo;
                    loggerStatus.Loggerid = c.Loggerid;
                    loggerStatus.Pourid = c.Pourid;
                    loggerStatus.EquivalentAge = 0;
                    loggerStatus.Status = "0";
                    listModel.Add(new EntityModel(loggerStatus, OperationMode.Add));

                    if (model.PourType == "2" && c.LogginStart != null)
                    {
                        #region 插入所有的pour设置之前的已经开始的记录
                        string sql = "Insert into PourLoggerTrack(ID,Pourid,Loggerid,ChannelNo,DataPointid,CurrentTime,Temp) ";
                        sql += string.Format(" select NewID(),'{0}',Loggerid,ChannelNo,DataPointid,CurrentTime,Temp from LoggerTrack t1 ", model.Pourid);
                        sql += string.Format(" where t1.Loggerid='{0}' and t1.ChannelNo='{1}' and t1.CurrentTime>='{2}'"
                            , c.Loggerid, c.ChannelNo, c.LogginStart == null ? "" : Convert.ToDateTime(c.LogginStart).ToString("dd/MM/yyyy HH:mm:ss"));
                        proxy.Execute(sql);

                        sql = "Insert into PourLoggerEvents(ID,Pourid,EventID,Flags,CurrentTime,EventType,LoggerID,ChannelNo,EventStartID) ";
                        sql += string.Format(" select NewID(),'{0}',EventID,Flags,CurrentTime,EventType,LoggerID,ChannelNo,EventStartID from LoggerEvents t1 ", model.Pourid);
                        sql += string.Format(" where t1.Loggerid='{0}' and t1.ChannelNo='{1}' and t1.CurrentTime>='{2}'"
                            , c.Loggerid, c.ChannelNo, c.LogginStart == null ? "" : Convert.ToDateTime(c.LogginStart).ToString("dd/MM/yyyy HH:mm:ss"));
                        proxy.Execute(sql);
                        #endregion 插入所有的pour设置之前的已经开始的记录
                    }
                }

                B.PourLocation2TargetBLL bllLocTarget = new B.PourLocation2TargetBLL();
                List<M.VwPourLocation2Target> list = bllLocTarget.GetListByPourID(pid);
                foreach (M.VwPourLocation2Target c in list)
                {
                    M.PourTargetEquivalentAge age = new M.PourTargetEquivalentAge();
                    age.Id = Guid.NewGuid().ToString();
                    age.ChannelNo = (int)c.ChannelNo;
                    age.CurrentTime = "";
                    age.Loggerid = c.Loggerid;
                    age.Pour2Targetid = c.Pour2Targetid;
                    age.Pourid = c.Pourid;
                    age.Target = c.Target;
                    age.Temp = "";
                    age.IsFinal = IsFinal(list, c) ? "1" : "0";
                    listModel.Add(new EntityModel(age, OperationMode.Add));
                }

                model.Status = "1";
                listModel.Add(new EntityModel(model, OperationMode.Update));

                M.Message msg = bllLocTarget.EntitesOperations(listModel);
                if (msg.State != M.MessageState.Success)
                {
                    str = msg.Msg;
                }
            }
            else
            {
                str = "Pour is not exists!";
            }
            return str;
        }

        private bool IsFinal(List<M.VwPourLocation2Target> list, M.VwPourLocation2Target model)
        {
            foreach (M.VwPourLocation2Target c in list)
            {
                if (model.Pourid == c.Pourid
                    && model.Loggerid == c.Loggerid
                    && model.ChannelNo == c.ChannelNo
                    && c.Target > model.Target)
                    return false;
            }
            return true;
        }
    }
}
