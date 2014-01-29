using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using ConXedge.Model;
using ConXedge.Model.Protocol;
using ConXEdge.BLL;
using ConXEdge.Nhibernate;
using log4net;
using NHibernate.Criterion;
using B = ConXEdge.BLL;
using M = ConXedge.Model;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ConXEdge.Server
{
    public class ServiceControl
    {
        private System.Timers.Timer timerTrack = new System.Timers.Timer();
        private System.Timers.Timer timerEvents = new System.Timers.Timer();
        private System.Timers.Timer timerGenerate = new System.Timers.Timer();
        private log4net.ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private bool bRun = false;
        private string LoggerServiceUrl;
        private string url = ConfigurationManager.AppSettings["LoggerServiceUrl"];
        private string emailType = ConfigurationManager.AppSettings["emailType"];
        private string emailName = ConfigurationManager.AppSettings["emailName"];
        private string emailPass = ConfigurationManager.AppSettings["emailPass"];

        /// <summary>
        /// Arenhius算法参数1
        /// </summary>
        private decimal ArenhiusParam1;
        /// <summary>
        /// Arenhius算法参数2
        /// </summary>
        private decimal ArenhiusParam2;
        /// <summary>
        /// Nurse Saul算法参数1
        /// </summary>
        private decimal NurseSaulParam1;
        
        /// <summary>
        /// 启动服务
        /// </summary>
        public void Start()
        {
            try
            {
                logger.Info("Server-Start");

                bRun = true;
                //Logger服务地址   
                LoggerServiceUrl = ConfigurationManager.AppSettings["LoggerServiceUrl"];

                B.ParamInfoBLL bll = new ParamInfoBLL();
                List<M.ParamInfo> list = bll.GetList();
                foreach (M.ParamInfo c in list)
                {
                    switch (c.ParamName.ToLower())
                    {
                        case "arenhiusparam1":
                            ArenhiusParam1 = c.ParamValue;
                            break;
                        case "arenhiusparam2":
                            ArenhiusParam2 = c.ParamValue;
                            break;
                        case "nursesaulparam1":
                            NurseSaulParam1 = c.ParamValue;
                            break;
                    }
                }

                //启动获取记录点监控程序
                timerTrack = new System.Timers.Timer();
                timerTrack.Interval = 1000 * 20;
                timerTrack.Enabled = true;
                timerTrack.Elapsed += new System.Timers.ElapsedEventHandler(timerTrack_Elapsed);

                //启动事件监控程序
                timerEvents = new System.Timers.Timer();
                timerEvents.Interval = 1000;
                timerEvents.Enabled = true;
                timerEvents.Elapsed += new System.Timers.ElapsedEventHandler(timerEvents_Elapsed);

                //启动数据生成监控程序
                timerGenerate = new System.Timers.Timer();
                timerGenerate.Interval = 1000;
                timerGenerate.Enabled = true;
                timerGenerate.Elapsed += new System.Timers.ElapsedEventHandler(timerGenerate_Elapsed);
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
            }
        }

        void timerGenerate_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timerGenerate.Enabled = false;

                GenerateAge();

                timerGenerate.Enabled = true;
            }
            catch (Exception ex)
            {
                
                timerGenerate.Enabled = true;
                logger.Error(ex.StackTrace, ex);
            }
           
        }

        void timerEvents_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timerEvents.Enabled = false;

                NHibernateProxy proxy = new NHibernateProxy();
                IList<LoggerInfo> list = proxy.GetEntities<LoggerInfo>(null, null);
                foreach (LoggerInfo c in list)
                {
                    GetEvents(c);
                }
                
                timerEvents.Enabled = true;
            }
            catch (Exception ex)
            {
                timerEvents.Enabled = true;
                logger.Error(ex.StackTrace, ex);
            }
        }

        void timerTrack_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timerTrack.Enabled = false;

                NHibernateProxy proxy = new NHibernateProxy();
                IList<LoggerInfo> list = proxy.GetEntities<LoggerInfo>(null, null);
                foreach (LoggerInfo c in list)
                {
                    GetDataPoints(c);
                }

                timerTrack.Enabled = true;
            }
            catch (Exception ex)
            {
                timerTrack.Enabled = false;
                logger.Error(ex.StackTrace, ex);
            }
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            try
            {
                bRun = false;
                this.timerTrack.Enabled = false;
                this.timerTrack.Dispose();
                this.timerEvents.Enabled = false;
                this.timerEvents.Dispose();
                this.timerGenerate.Enabled = false;
                this.timerGenerate.Dispose();
                logger.Info("Server-Stop");
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
            }
        }

        /// <summary>
        /// 获取当前数据点信息
        /// </summary>
        /// <returns></returns>
        private void GetDataPoints(LoggerInfo modelLogger)
        {
            try
            {
                LoggerInfoBLL bllLogger = new LoggerInfoBLL();

                LoggerTrackBLL bll = new LoggerTrackBLL();
                B.PourLoggerTrackBLL bllTrack = new PourLoggerTrackBLL();

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                // Add an Accept header for SSE format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

                // Blocking call! 
                HttpResponseMessage response = client.GetAsync("api/loggers/" + modelLogger.LoggerCode + "/dataPoints?from="
                + (modelLogger.DataPointid+1)).Result;
                if (response.IsSuccessStatusCode)
                {
                    byte[] tmpBytes;
                    // Parse the response body. Blocking!
                    var loggerStatus = response.Content.ReadAsStringAsync();
                    byte[] data = System.Convert.FromBase64String(loggerStatus.Result);
                    var reader = new BinaryReader(new MemoryStream(data), Encoding.ASCII);

                    DataPoints myDataPoints = new DataPoints();
                    //myDataPoints.dataPoints = new List<DataPoint>();
                    myDataPoints.version = reader.ReadByte();
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        if (!bRun)
                            break;
                        DataPoint dataPoint = new DataPoint();

                        tmpBytes = reader.ReadBytes(8);
                        Array.Reverse(tmpBytes);
                        dataPoint.id = BitConverter.ToInt64(tmpBytes, 0);

                        tmpBytes = reader.ReadBytes(8);
                        Array.Reverse(tmpBytes);
                        dataPoint.timestamp = BitConverter.ToInt64(tmpBytes, 0);

                        tmpBytes = reader.ReadBytes(4);
                        Array.Reverse(tmpBytes);
                        dataPoint.logger = BitConverter.ToInt32(tmpBytes, 0);

                        dataPoint.sensor = reader.ReadByte();

                        dataPoint.flags = reader.ReadByte();

                        tmpBytes = reader.ReadBytes(4);
                        Array.Reverse(tmpBytes);
                        dataPoint.value = BitConverter.ToInt32(tmpBytes, 0);
                       
                        LoggerTrack loggerTrack = new LoggerTrack();
                        loggerTrack.Id = System.Guid.NewGuid().ToString();
                        loggerTrack.ChannelNo = dataPoint.sensor + 1;
                        loggerTrack.CurrentTime = new DateTime(1970, 1, 1).AddMilliseconds(dataPoint.timestamp);
                        loggerTrack.DataPointid = dataPoint.id;
                        loggerTrack.Flags = dataPoint.flags;
                        loggerTrack.Loggerid = modelLogger.Loggerid;
                        loggerTrack.Temp = (decimal)dataPoint.value / 1000;                        

                        if (dataPoint.id > modelLogger.DataPointid)
                        {
                            modelLogger.DataPointid = dataPoint.id;
                            bllLogger.Update(modelLogger);
                        }

                        if (loggerTrack.CurrentTime.AddDays(-1) <= DateTime.Now)
                        {
                            bll.Add(loggerTrack);
                            if (!string.IsNullOrEmpty(modelLogger.CurrentPourid))
                            {
                                PourLoggerTrack pourLoggerTrack = new PourLoggerTrack();
                                pourLoggerTrack.Id = System.Guid.NewGuid().ToString();
                                pourLoggerTrack.Pourid = modelLogger.CurrentPourid;
                                pourLoggerTrack.ChannelNo = loggerTrack.ChannelNo;
                                pourLoggerTrack.CurrentTime = loggerTrack.CurrentTime;
                                pourLoggerTrack.DataPointid = loggerTrack.DataPointid;
                                pourLoggerTrack.Loggerid = loggerTrack.Loggerid;
                                pourLoggerTrack.Temp = loggerTrack.Temp;
                                bllTrack.Add(pourLoggerTrack);
                            }
                        }
                    }
                }
                else
                {
                    logger.Info(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
            }
        }

        /// <summary>
        /// 获取当前事件信息
        /// </summary>
        /// <returns></returns>
        private void GetEvents(LoggerInfo modelLogger)
        {
            try
            {
                B.LoggerInfoBLL bllLogger = new LoggerInfoBLL();

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                // Add an Accept header for SSE format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

                // Blocking call! 
                HttpResponseMessage response = client.GetAsync("api/loggers/" + modelLogger.LoggerCode + "/events?from="
                + (modelLogger.Eventid+1)).Result;
                if (response.IsSuccessStatusCode)
                {
                    byte[] tmpBytes;
                    // Parse the response body. Blocking!
                    var loggerStatus = response.Content.ReadAsStringAsync();
                    byte[] data = System.Convert.FromBase64String(loggerStatus.Result);
                    var reader = new BinaryReader(new MemoryStream(data), Encoding.ASCII);

                    Events events = new Events();
                    events.version = reader.ReadByte();
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        tmpBytes = reader.ReadBytes(8);
                        Array.Reverse(tmpBytes);
                        events.id = BitConverter.ToInt64(tmpBytes, 0);

                        events.flags = reader.ReadByte();
                        //转换flags 0-表示start 1-表示end
                        bool end = (events.flags & 0x02) != 0;
                        bool reset = (events.flags & 0x04) != 0;
                        if (end)
                        {
                            events.flags = 1;
                        }
                        else 
                        {
                            events.flags = 0;
                        }


                        tmpBytes = reader.ReadBytes(8);
                        Array.Reverse(tmpBytes);
                        events.timestamp = BitConverter.ToInt64(tmpBytes, 0);

                        events.type = reader.ReadByte();

                        tmpBytes = reader.ReadBytes(4);
                        Array.Reverse(tmpBytes);
                        events.logger = BitConverter.ToInt32(tmpBytes, 0);

                        events.sensor = reader.ReadByte();

                        events.dataLength = reader.ReadByte();

                        tmpBytes = reader.ReadBytes(events.dataLength);
                        Array.Reverse(tmpBytes);
                        events.data = tmpBytes;

                        tmpBytes = reader.ReadBytes(8);
                        Array.Reverse(tmpBytes);
                        events.eventStartID = BitConverter.ToInt64(tmpBytes, 0);

                        LoggerEvents loggerEvents = new LoggerEvents();
                        loggerEvents.Id = System.Guid.NewGuid().ToString();
                        loggerEvents.ChannelNo = events.sensor + 1;
                        loggerEvents.CurrentTime = new DateTime(1970, 1, 1).AddMilliseconds(events.timestamp);
                        loggerEvents.Eventid = events.id;
                        loggerEvents.Flags = events.flags;
                        loggerEvents.Loggerid = modelLogger.Loggerid;
                        loggerEvents.EventStartid = events.eventStartID;
                        loggerEvents.EventType = events.type;                        

                        if (events.id > modelLogger.Eventid)
                        {
                            modelLogger.Eventid = events.id;
                            bllLogger.Update(modelLogger);
                        }

                        if (loggerEvents.CurrentTime.AddDays(-1) <= DateTime.Now && !reset)
                        {
                            LoggerEventsBLL bll = new LoggerEventsBLL();
                            bll.Add(loggerEvents);

                            if (!string.IsNullOrEmpty(modelLogger.CurrentPourid))
                            {
                                PourLoggerEvents pourLoggerEvents = new PourLoggerEvents();
                                pourLoggerEvents.Id = System.Guid.NewGuid().ToString();
                                pourLoggerEvents.Pourid = modelLogger.CurrentPourid;
                                pourLoggerEvents.ChannelNo = loggerEvents.ChannelNo;
                                pourLoggerEvents.CurrentTime = loggerEvents.CurrentTime;
                                pourLoggerEvents.Eventid = loggerEvents.Eventid;
                                pourLoggerEvents.Loggerid = loggerEvents.Loggerid;
                                pourLoggerEvents.EventStartid = loggerEvents.EventStartid;
                                pourLoggerEvents.EventType = loggerEvents.EventType;
                                pourLoggerEvents.Flags = loggerEvents.Flags;

                                B.PourLoggerEventsBLL bllEvents = new PourLoggerEventsBLL();
                                bllEvents.Add(pourLoggerEvents);
                            }
                        }
                    }
                }
                else
                {
                    logger.Info(string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
            }
        }

        /// <summary>
        /// 生成Age数据
        /// </summary>
        private void GenerateAge()
        {
            NHibernateProxy proxy = new NHibernateProxy();
            B.PourInfoBLL bllPour = new PourInfoBLL();
            
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Status", "0"));

            ArrayList al = new ArrayList();
            IList<M.PourLoggerStatus> list = proxy.GetEntities<M.PourLoggerStatus>(Conditions, null);
            foreach (M.PourLoggerStatus c in list)
            {
                Conditions = new List<ICriterion>();
                Conditions.Add(Expression.Eq("CurrentTime", ""));
                Conditions.Add(Expression.Eq("Pourid", c.Pourid));
                Conditions.Add(Expression.Eq("Loggerid", c.Loggerid));
                Conditions.Add(Expression.Eq("ChannelNo", c.ChannelNo));

                al = new ArrayList();
                IList<M.PourTargetEquivalentAge> listAge = proxy.GetEntities<M.PourTargetEquivalentAge>(Conditions, null);
                foreach (M.PourTargetEquivalentAge c1 in listAge)
                {
                    CalculateEquivalentAge(c1);
                }
            }

            #region 设置Pour Stop状态
            Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("Status", "1"));
            IList<M.PourInfo> listPour = proxy.GetEntities<M.PourInfo>(Conditions, null);
            IList<M.PourTargetEquivalentAge> listPourAge = new List<M.PourTargetEquivalentAge>();
            foreach (M.PourInfo c in listPour)
            {
                bool bFlag = false;
                switch (c.StopType)
                {
                    case "1"://Channel Achieves Final Target
                    case "3"://X Hours After Channel Achieves Final Target      
                    case "5"://Logger is Stopped
                        Conditions = new List<ICriterion>();
                        Conditions.Add(Expression.Eq("Status", "0"));
                        Conditions.Add(Expression.Eq("Pourid", c.Pourid));
                        IList<M.PourLoggerStatus> listPourStatus = proxy.GetEntities<M.PourLoggerStatus>(Conditions, null);
                        if (listPourStatus == null || listPourStatus.Count <= 0)
                        {
                            bFlag = true;                            
                        }
                        break;
                    case "2"://All Channels Have Achieved Final Targets
                        Conditions = new List<ICriterion>();
                        Conditions.Add(Expression.Eq("CurrentTime", ""));
                        Conditions.Add(Expression.Eq("Pourid", c.Pourid));
                        listPourAge = proxy.GetEntities<M.PourTargetEquivalentAge>(Conditions, null);
                        if (listPourAge == null || listPourAge.Count <= 0)
                        {
                            bFlag = true;                            
                        }
                        break;
                    case "4"://X Hours After All Channels Have Achieved Final Targets
                        Conditions = new List<ICriterion>();
                        Conditions.Add(Expression.Ge("CurrentTime", DateTime.Now.AddHours(-c.Xhours)));
                        Conditions.Add(Expression.Eq("Pourid", c.Pourid));
                        listPourAge = proxy.GetEntities<M.PourTargetEquivalentAge>(Conditions, null);
                        if (listPourAge == null || listPourAge.Count <= 0)
                        {
                            bFlag = true;
                        }
                        break;
                }
                if (bFlag)
                {
                    c.Status = "2";
                    bllPour.Update(c);

                    proxy.Execute(string.Format("Update LoggerInfo Set CurrentPourID='' Where CurrentPourID='{0}'"
                        , c.Pourid));

                    proxy.Execute(string.Format("Update PourLoggerStatus Set Status='1' Where PourID='{0}'"
                        , c.Pourid));
                }
            }
            #endregion 设置Pour Stop状态
        }

        /// <summary>
        /// 计算Equivalent Age
        /// </summary>
        /// <param name="pourid"></param>
        /// <returns></returns>
        private void CalculateEquivalentAge(M.PourTargetEquivalentAge m)
        {
            bool IsStop = false;
            decimal EquivalentAge = 0;           

            B.PourInfoBLL bll = new B.PourInfoBLL();
            B.PourTargetEquivalentAgeBLL bllAge = new PourTargetEquivalentAgeBLL();
            B.PourLoggerStatusBLL bllStatus = new PourLoggerStatusBLL();
            B.PourLoggerTrackBLL bllTrack = new PourLoggerTrackBLL();

            M.PourInfo model = bll.GetModelByID(m.Pourid);
            List<M.PourLoggerStatus> listStatus = bllStatus.GetListByPourID(m.Pourid);

            NHibernateProxy proxy = new NHibernateProxy();
            List<ICriterion> Conditions = new List<ICriterion>();
            List<Order> orders = new List<Order>();
            IList<M.PourLoggerEvents> listEvents = new List<M.PourLoggerEvents>();

            #region 获取开始时间和结束时间
            DateTime? startedTime = null;
            DateTime? finishedTime = null;

            foreach (M.PourLoggerStatus c in listStatus)
            {
                if (c.Pourid == m.Pourid
                    && c.Loggerid == m.Loggerid
                    && c.ChannelNo == m.ChannelNo)
                {
                    if (c.LoggingStarted == null)
                    {
                        Conditions = new List<ICriterion>();
                        Conditions.Add(Expression.Eq("Pourid", m.Pourid));
                        Conditions.Add(Expression.Eq("Loggerid", m.Loggerid));
                        Conditions.Add(Expression.Eq("ChannelNo", m.ChannelNo));
                        Conditions.Add(Expression.Eq("EventType", 22));
                        Conditions.Add(Expression.Eq("Flags", 1));
                        orders = new List<Order>();
                        orders.Add(new Order("CurrentTime", true));
                        listEvents = proxy.GetEntities<M.PourLoggerEvents>(Conditions, orders);
                        if (listEvents.Count > 0)
                        {
                            startedTime = listEvents[0].CurrentTime;
                            c.LoggingStarted = (DateTime)startedTime;
                            bllStatus.Update(c);
                        }
                    }
                    else
                    {
                        startedTime = c.LoggingStarted;
                    }
                    break;
                }
            }

            //获取结束时间
            if (model.StopType == "5")
            {
                Conditions = new List<ICriterion>();
                Conditions.Add(Expression.Eq("Pourid", m.Pourid));
                Conditions.Add(Expression.Eq("Loggerid", m.Loggerid));
                Conditions.Add(Expression.Eq("ChannelNo", m.ChannelNo));
                Conditions.Add(Expression.Eq("EventType", 22));
                Conditions.Add(Expression.Eq("Flags", 0));
                orders = new List<Order>();
                orders.Add(new Order("CurrentTime", false));
                listEvents = proxy.GetEntities<M.PourLoggerEvents>(Conditions, orders);
                if (listEvents.Count > 0)
                {
                    finishedTime = listEvents[0].CurrentTime;
                }
            }
            #endregion 获取开始时间和结束时间

            Conditions = new List<ICriterion>();
            if (startedTime != null)
            {
                Conditions.Add(Expression.Ge("CurrentTime", startedTime));
            }
            if (finishedTime != null)
            {
                Conditions.Add(Expression.Le("CurrentTime", finishedTime));
            }
            Conditions.Add(Expression.Eq("Pourid", m.Pourid));
            Conditions.Add(Expression.Eq("Loggerid", m.Loggerid));
            Conditions.Add(Expression.Eq("ChannelNo", m.ChannelNo));

            orders = new List<Order>();
            orders.Add(new Order("CurrentTime", true));
            IList<M.PourLoggerTrack> list = proxy.GetEntities<M.PourLoggerTrack>(Conditions, orders);
            for (int i = 0; i < list.Count; i++)
            {
                if (model.StopType == "5"  
                    && finishedTime != null 
                    && list[i].CurrentTime.AddMinutes(5)>= finishedTime)
                {
                    IsStop = true;
                    break;
                }
                if (i > 0)
                {
                    decimal ttf = 0;
                    //计算时间差
                    decimal increment = 0;
                    DateTime d = list[i - 1].CurrentTime;
                    DateTime f = list[i].CurrentTime;
                    TimeSpan r = f.Subtract(d);
                    increment = r.Minutes;
                    //平均温度
                    decimal avgDegC = (list[i].Temp + list[i - 1].Temp) / 2;
                    if (model.MaturityMethod == "Nurse Saul")
                    {
                        #region 算法Nurse Saul
                        ttf = (avgDegC - NurseSaulParam1) * increment;
                        #endregion
                    }
                    else
                    {
                        #region 算法Arenhius
                        avgDegC += 273;
                        ttf = Math.Round((decimal)(Math.Exp(-((double)1 / (double)avgDegC - (double)1 / (double)(ArenhiusParam1 + 273)) * (double)ArenhiusParam2)), 2);
                        #endregion
                    }
                    EquivalentAge += ttf;
                    list[i].EquivalentAge = System.Decimal.Round(EquivalentAge / 60, 2);
                    bllTrack.Update(list[i]);
                        
                    if (string.IsNullOrEmpty(m.CurrentTime) &&
                        list[i].EquivalentAge >= m.Target)
                    {
                        m.CurrentTime = list[i].CurrentTime.ToString("yyyy-MM-dd HH:mm:ss");
                        m.Temp = list[i].Temp.ToString();
                        bllAge.Update(m);
                        SendEmail(m);
                    }

                    if (m.IsFinal == "1" && list[i].EquivalentAge >= m.Target)
                    {
                        switch (model.StopType)
                        {
                            case "1"://Channel Achieves Final Target
                                IsStop = true;
                                break;
                            case "2"://All Channels Have Achieved Final Targets
                                break;
                            case "3"://X Hours After Channel Achieves Final Target                                
                                if(!string.IsNullOrEmpty(m.CurrentTime))
                                {
                                    if (Convert.ToDateTime(m.CurrentTime).AddHours(model.Xhours) 
                                        >= Convert.ToDateTime(list[i].CurrentTime))
                                    { 
                                        IsStop = true;
                                    }
                                }                                
                                break;
                            case "4"://X Hours After All Channels Have Achieved Final Targets         
                                break;
                        }
                    }

                    if (IsStop)
                        break;
                }
            }
            EquivalentAge = System.Decimal.Round(EquivalentAge / 60, 2);

            foreach (M.PourLoggerStatus c in listStatus)
            {
                if (c.Loggerid == m.Loggerid && c.ChannelNo == m.ChannelNo)
                {
                    if(list.Count>0)
                        c.Temp = list[list.Count - 1].Temp;
                    c.EquivalentAge = EquivalentAge;
                    if(IsStop)
                        c.Status ="1";
                    bllStatus.Update(c);
                    break;
                }
            }
        }

        /// <summary>
        /// 获取当前温度
        /// </summary>
        /// <returns></returns>
        private Single GetTemp(string loggercode, string channelno)
        {
            Single temp = 0;

            try
            {
                string url = ConfigurationManager.AppSettings["LoggerServiceUrl"];
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                // Add an Accept header for SSE format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

                // Blocking call! 
                HttpResponseMessage response = client.GetAsync("api/loggers/"
                + loggercode + "/status?interval=0").Result;
                if (response.IsSuccessStatusCode)
                {
                    byte[] tmpBytes;
                    // Parse the response body. Blocking!
                    var loggerStatus = response.Content.ReadAsStringAsync();
                    byte[] data = System.Convert.FromBase64String(loggerStatus.Result);
                    var reader = new BinaryReader(new MemoryStream(data), Encoding.ASCII);

                    LoggerStatus status = new LoggerStatus();
                    status.version = reader.ReadByte();

                    tmpBytes = reader.ReadBytes(4);
                    Array.Reverse(tmpBytes);
                    status.logger = BitConverter.ToInt32(tmpBytes, 0);

                    status.commState = (CommState)reader.ReadByte();

                    tmpBytes = reader.ReadBytes(8);
                    Array.Reverse(tmpBytes);
                    status.timestamp = BitConverter.ToInt64(tmpBytes, 0);

                    status.level = (BatteryLevel)reader.ReadByte();

                    status.batteryAlarm = (AlarmStatus)reader.ReadByte();

                    status.reserved = reader.ReadByte();

                    status.mainsAlarm = (AlarmStatus)reader.ReadByte();

                    status.numSensors = reader.ReadByte();
                    status.SensorsStatus = new List<SensorStatus>();
                    for (int i = 1; i <= status.numSensors; i++)
                    {
                        SensorStatus sensorStatus = new SensorStatus();
                        sensorStatus.flags = reader.ReadByte();

                        tmpBytes = reader.ReadBytes(4);
                        Array.Reverse(tmpBytes);
                        sensorStatus.value = BitConverter.ToInt32(tmpBytes, 0);

                        sensorStatus.level = (ThresholdState)reader.ReadByte();

                        sensorStatus.lowCriticalAlarm = (AlarmStatus)reader.ReadByte();

                        sensorStatus.lowAlarm = (AlarmStatus)reader.ReadByte();

                        sensorStatus.highAlarm = (AlarmStatus)reader.ReadByte();

                        sensorStatus.highCriticalAlarm = (AlarmStatus)reader.ReadByte();

                        sensorStatus.errorAlarm = (AlarmStatus)reader.ReadByte();

                        sensorStatus.disconnectAlarm = (AlarmStatus)reader.ReadByte();

                        status.SensorsStatus.Add(sensorStatus);

                        if (channelno == i.ToString())
                        {
                            temp = ((Single)sensorStatus.value) / 1000;
                        }
                    }
                    status.numInputs = reader.ReadByte();
                    status.InputsStatus = new List<InputStatus>();
                    for (int i = 1; i <= status.numInputs; i++)
                    {
                        InputStatus inputStatus = new InputStatus();
                        inputStatus.flags = reader.ReadByte();

                        inputStatus.inputAlarm = (AlarmStatus)reader.ReadByte();
                    }
                    status.numUnreadTexts = reader.ReadByte();
                }
            }
            catch (Exception ex)
            {

            }
            return temp;
        }

        /// <summary>
        /// 发送报警Email
        /// </summary>
        /// <param name="m"></param>
        private void SendEmail(M.PourTargetEquivalentAge m)
        {
            Email email = new Email();
            NHibernateProxy proxy = new NHibernateProxy();
            List<ICriterion> Conditions = new List<ICriterion>();
            Conditions.Add(Expression.Eq("_pourid",m.Pourid));
            Conditions.Add(Expression.Eq("_loggerid", m.Loggerid));
            Conditions.Add(Expression.Eq("_channelno", m.ChannelNo));

            IList<M.VwPourLocation2Target> list = proxy.GetEntities<M.VwPourLocation2Target>(Conditions, null);

            if (list != null && list.Count > 0)
            {
                string toEmail = list[0].Email;
                string emailTitle = "Target Finished";

                //邮件内容
                string emailContent = string.Format("Project:[{0}] Pour:[{1}] Location:[{2}][{3}] Target:[{4}]"
                    ,new object[]{list[0].ProjectName, list[0].PourName
                        , list[0].Locationid, list[0].LocationDescription, m.Target});
                //调用发邮件
                email.SendSMTPEMail(emailType, emailName, emailPass, toEmail, emailTitle, emailContent);
            }
        }
    }
}
