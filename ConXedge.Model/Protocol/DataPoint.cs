using System;
using System.Collections.Generic;
using System.Text;

namespace ConXedge.Model.Protocol
{
    public class DataPoint
    {
        public long id { get; set; }
        public long timestamp { get; set; }
        public int logger { get; set; }
        public byte sensor { get; set; }
        public byte flags { get; set; }
        public int value { get; set; }
    }
}
