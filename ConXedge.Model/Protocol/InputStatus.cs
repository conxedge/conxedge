using System;
using System.Collections.Generic;
using System.Text;

namespace ConXedge.Model.Protocol
{
    public class InputStatus
    {
        public byte flags { get; set; }
        public AlarmStatus inputAlarm { get; set; }
    }
}
