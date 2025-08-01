using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Monitor_Client.Core
{
    public class ValueProvider
    {
        public ValueProvider()
        {

            _analogSensors.Add(1, new AnalogSensor());
            Thread.Sleep(100);
            _analogSensors.Add(2, new AnalogSensor());
            Thread.Sleep(100);
            _analogSensors.Add(3, new AnalogSensor());
            Thread.Sleep(100);
            _analogSensors.Add(4, new AnalogSensor());
            _analogSensors.Add(5, new AnalogSensor());
            _analogSensors.Add(6, new AnalogSensor());
            _analogSensors.Add(7, new AnalogSensor());
            _analogSensors.Add(8, new AnalogSensor());
            _analogSensors.Add(9, new AnalogSensor());
            _analogSensors.Add(10, new AnalogSensor());
        }

        private Dictionary<int, AnalogSensor> _analogSensors = new Dictionary<int, AnalogSensor>();

        public double GetValueBySensorIndex(int index)
        {
            if (_analogSensors.ContainsKey(index))
            {
                return _analogSensors[index].CurrentValue;
            }
            else
            {
                return 0;
            }
        }

    }
}
