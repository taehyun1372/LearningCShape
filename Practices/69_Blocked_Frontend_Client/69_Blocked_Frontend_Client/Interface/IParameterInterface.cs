using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _69_Blocked_Frontend_Client.Interface
{
    [ServiceContract]
    public interface IParameterInterface
    {
        [OperationContract(IsOneWay = true)]
        void ParameterLogRequest(int param);
    }
}
