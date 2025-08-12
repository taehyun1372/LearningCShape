using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reporter_Client.Sensors
{
    public class SensorSimulator
    {
        private Dictionary<int, AnalogSensor> _analogSensors = new Dictionary<int, AnalogSensor>();
        public event Action<object, ValueChangedArg> SensorValueChanged;

        public SensorSimulator(int quantity)
        {
            for (int i=0; i < quantity; i++)
            {
                var anal = new AnalogSensor(i+1);
                anal.ValueChanged += OnValueChanged;
                _analogSensors.Add(i, anal);
            }
        }

        public void OnValueChanged(object sender, ValueChangedArg e)
        {
            SensorValueChanged?.Invoke(sender, e);
        }

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
