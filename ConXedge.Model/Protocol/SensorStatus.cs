using System;
using System.Collections.Generic;
using System.Text;

namespace ConXedge.Model.Protocol
{
    public class SensorStatus
    {
        public byte flags { get; set; }
        public int value { get; set; }
        public ThresholdState level { get; set; }
        public AlarmStatus lowCriticalAlarm { get; set; }
        public AlarmStatus lowAlarm { get; set; }
        public AlarmStatus highAlarm { get; set; }
        public AlarmStatus highCriticalAlarm { get; set; }
        public AlarmStatus errorAlarm { get; set; }
        public AlarmStatus disconnectAlarm { get; set; }
    }
}
