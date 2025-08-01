using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Monitor_Client.Core;
using System.Threading;
using System.Windows.Threading;
using System.Windows;

namespace Monitor_Client.ViewModels
{
    public class ChartViewModel
    {
        public ObservableCollection<DataPoint> Series1 { get; set; }
        public ObservableCollection<DataPoint> Series2 { get; set; }
        public ObservableCollection<DataPoint> Series3 { get; set; }

        private ValueProvider _valueProvider;
        private int _count;


        public ChartViewModel(ValueProvider valueProvider)
        {
            _valueProvider = valueProvider;

            Series1 = new ObservableCollection<DataPoint>();
            Series2 = new ObservableCollection<DataPoint>();
            Series3 = new ObservableCollection<DataPoint>();

            Task.Run(() => {
                while(true)
                {
                    Thread.Sleep(1000);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        UpdateSensorValue();
                    });
                }
            });

        }

        public void UpdateSensorValue()
        {
            _count++;
            
            Series1.Add(new DataPoint { Date = _count, Value = _valueProvider.GetValueBySensorIndex(1) });
            Series2.Add(new DataPoint { Date = _count, Value = _valueProvider.GetValueBySensorIndex(2) });
            Series3.Add(new DataPoint { Date = _count, Value = _valueProvider.GetValueBySensorIndex(3) });
        }
    }

    public class DataPoint
    {
        public int Date { get; set; }
        public double Value { get; set; }

    }
}
