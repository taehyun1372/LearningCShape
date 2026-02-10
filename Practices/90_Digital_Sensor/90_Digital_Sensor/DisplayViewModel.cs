using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace _90_Digital_Sensor
{
    public class DisplayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _tempValue;
        public int TempValue
        {
            get { return _tempValue; }
            set 
            { 
                if (_tempValue != value)
                {
                    _tempValue = value;
                    OnPropertyChanged(nameof(TempValue));
                }
            }
        }

        private int _humidityValue;
        public int HumidityValue
        {
            get { return _humidityValue; }
            set
            {
                if (_humidityValue != value)
                {
                    _humidityValue = value;
                    OnPropertyChanged(nameof(HumidityValue));
                }
            }
        }

        private int _flowValue;
        public int FlowValue
        {
            get { return _flowValue; }
            set
            {
                if (_flowValue != value)
                {
                    _flowValue = value;
                    OnPropertyChanged(nameof(FlowValue));
                }
            }
        }


        public void OnValueChanged(ValueChangedEventArgs e)
        {
            if (e.Type == Type.temp) TempValue = e.Value;
            else if (e.Type == Type.humidity) HumidityValue = e.Value;
            else if (e.Type == Type.flow) FlowValue = e.Value;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
