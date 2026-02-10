using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace _90_Digital_Sensor
{
    public class DataProvider
    {
        public event Action<ValueChangedEventArgs> ValueChanged;
        private SensorSimulator _tempSensor;
        private SensorSimulator _humiditySensor;
        private SensorSimulator _flowSensor;

        private Timer _timer;

        private int _tempValue;
        public int TempValue
        {
            get { return _tempValue; }
            set 
            { 
                if (value != _tempValue)
                {
                    _tempValue = value;
                    ValueChanged?.Invoke(new ValueChangedEventArgs() { Type = Type.temp, Value = value});
                }
            }
        }
        private int _humidityValue;
        public int HumidityValue
        {
            get { return _humidityValue; }
            set
            {
                if (value != _humidityValue)
                {
                    _humidityValue = value;
                    ValueChanged?.Invoke(new ValueChangedEventArgs() { Type = Type.humidity, Value = value });
                }
            }
        }
        private int _flowValue;
        public int FlowValue
        {
            get { return _flowValue; }
            set
            {
                if (value != _flowValue)
                {
                    _flowValue = value;
                    ValueChanged?.Invoke(new ValueChangedEventArgs() { Type = Type.flow, Value = value });
                }
            }
        }

        public DataProvider()
        {

            _timer = new Timer();
            _timer.Elapsed += ReadSensors;
            _timer.Interval = 1000;
            _timer.Enabled = true;


            _tempSensor = new SensorSimulator();
            _humiditySensor = new SensorSimulator();
            _flowSensor = new SensorSimulator();
            
        }

        public void ReadSensors(object sender, ElapsedEventArgs e)
        {
            ReadTempSensor();
            ReadHumaditySensor();
            ReadFlowSensor();
        }

        public void ReadTempSensor()
        {
            if (_tempSensor != null)
            {
                TempValue = _tempSensor.GetValue();
            }
        }

        public void ReadHumaditySensor()
        {
            if (_humiditySensor != null)
            {
                HumidityValue = _humiditySensor.GetValue();
            }
        }

        public void ReadFlowSensor()
        {
            if (_flowSensor != null)
            {
                FlowValue = _flowSensor.GetValue();
            }
        }

    }

    public class SensorSimulator
    {
        private Random _rand = new Random();
        public int GetValue()
        {
            var value =  _rand.Next();
            Console.WriteLine($"Reading Value..{value}");
            return value;
        }
    }


    public class ValueChangedEventArgs
    {
        public Type Type;
        public int Value;
    }

    public enum Type
    {
        temp,
        humidity,
        flow
    }

    
}
