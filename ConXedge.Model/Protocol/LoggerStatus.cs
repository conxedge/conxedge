using System;
using System.Collections.Generic;
using System.Text;

namespace ConXedge.Model.Protocol
{
    public class LoggerStatus
    {
        public byte version { get; set; }
        public int logger { get; set; }
        public CommState commState { get; set; }
        public long timestamp { get; set; }
        public BatteryLevel level { get; set; }
        public AlarmStatus batteryAlarm { get; set; }
        public byte reserved { get; set; }
        public AlarmStatus mainsAlarm { get; set; }
        public byte numSensors { get; set; }
        public List<SensorStatus> SensorsStatus { get; set; }
        public byte numInputs { get; set; }
        public List<InputStatus> InputsStatus { get; set; }
        public int numUnreadTexts { get; set; }
    }
}
