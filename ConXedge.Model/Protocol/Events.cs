using System;
using System.Collections.Generic;
using System.Text;

namespace ConXedge.Model.Protocol
{
    public class Events
    {
        public byte version { get; set; }
        public long id { get; set; }
        public byte flags { get; set; }
        public long timestamp { get; set; }
        public byte type { get; set; }
        public int logger { get; set; }
        public byte sensor { get; set; }
        public byte dataLength { get; set; }
        public byte[] data { get; set; }
        public long eventStartID { get; set; }
    }
}
