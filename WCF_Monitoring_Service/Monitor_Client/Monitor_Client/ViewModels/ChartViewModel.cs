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
        public ObservableCollection<DataPoint> Series4 { get; set; }
        public ObservableCollection<DataPoint> Series5 { get; set; }
        public ObservableCollection<DataPoint> Series6 { get; set; }
        public ObservableCollection<DataPoint> Series7 { get; set; }
        public ObservableCollection<DataPoint> Series8 { get; set; }
        public ObservableCollection<DataPoint> Series9 { get; set; }

        private ValueProvider _valueProvider;
        private int _count;


        public ChartViewModel(ValueProvider valueProvider)
        {
            _valueProvider = valueProvider;

            Series1 = new ObservableCollection<DataPoint>();
            Series2 = new ObservableCollection<DataPoint>();
            Series3 = new ObservableCollection<DataPoint>();
            Series4 = new ObservableCollection<DataPoint>();
            Series5 = new ObservableCollection<DataPoint>();
            Series6 = new ObservableCollection<DataPoint>();
            Series7 = new ObservableCollection<DataPoint>();
            Series8 = new ObservableCollection<DataPoint>();
            Series9 = new ObservableCollection<DataPoint>();

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
            Series4.Add(new DataPoint { Date = _count, Value = _valueProvider.GetValueBySensorIndex(4) });
            Series5.Add(new DataPoint { Date = _count, Value = _valueProvider.GetValueBySensorIndex(5) });
            Series6.Add(new DataPoint { Date = _count, Value = _valueProvider.GetValueBySensorIndex(6) });
            Series7.Add(new DataPoint { Date = _count, Value = _valueProvider.GetValueBySensorIndex(7) });
            Series8.Add(new DataPoint { Date = _count, Value = _valueProvider.GetValueBySensorIndex(8) });
            Series9.Add(new DataPoint { Date = _count, Value = _valueProvider.GetValueBySensorIndex(9) });
        }
    }

    public class DataPoint
    {
        public int Date { get; set; }
        public double Value { get; set; }

    }
}
