using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using _68_Blocked_Frontend_Server.Core;

namespace _68_Blocked_Frontend_Server.Interface
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ParameterInterface : IParameterInterface
    {
        public event Action<object, int> ParameterLogRequested;

        public void ParameterLogRequest(int param)
        {
            ParameterLogRequested?.Invoke(this, param);
        }
    }
}
