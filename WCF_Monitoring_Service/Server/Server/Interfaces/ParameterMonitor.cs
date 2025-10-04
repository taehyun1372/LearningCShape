using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Server.Database;

namespace Server.Interfaces
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ParameterMonitor : IParameterMonitor
    {
        private DataReader _reader;
        public ParameterMonitor(DataReader reader)
        {
            _reader = reader;
        }

        public List<ParameterHistoryData> GetAllParameterHistory()
        {
            if (_reader == null)
            {
                return null;
            }

            var result = _reader.ReadParametersFromDatabase();
            return result;
        }
    }
}
