using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    [DataContract(Namespace = "net.tcp://localhost:8090/MonitorService")]
    public class ParameterHistoryData
    { 
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}
