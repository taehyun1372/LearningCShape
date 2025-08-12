using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server.Interfaces
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class ReporterServer : IReporterServer
    {
        public event Action<object, ParameterData> ParameterChanged;

        public void NotifyParameter(ParameterData data)
        {
            Console.WriteLine($"{data.Id} value changed : {data.Value}");
            ParameterChanged?.Invoke(this, data);
        }
    }
}
