using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _68_Blocked_Frontend_Server.Interface
{

    [ServiceContract]
    public interface IParameterInterface
    {
        [OperationContract(IsOneWay = true)]
        void ParameterLogRequest(int param);
    }
}
