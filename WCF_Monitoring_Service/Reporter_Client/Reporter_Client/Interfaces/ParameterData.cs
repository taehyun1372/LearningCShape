using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Reporter_Client.Interfaces
{
    [DataContract(Namespace = "net.tcp://localhost:8090/ReporterService")]
    public class ParameterData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double Value { get; set; }
    }
}
