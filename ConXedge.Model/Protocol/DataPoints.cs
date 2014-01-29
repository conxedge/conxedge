using System;
using System.Collections.Generic;
using System.Text;

namespace ConXedge.Model.Protocol
{
    public class DataPoints
    {
        public byte version { get; set; }
        public List<DataPoint> dataPoints { get; set; } 
    }
}
