using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Timers;
using _66_Async_Performance.Core;

namespace _66_Async_Performance.ViewModels
{
    public class ChartViewModel
    {
        public ObservableCollection<ParameterQueueSize> ParameterQueueStatus { get; set; } = new ObservableCollection<ParameterQueueSize>();

        private ParameterGenerator _generator;
        private Timer _timer;
        public ChartViewModel(ParameterGenerator generator)
        {
            _generator = generator;
            _timer = new Timer(100);
            _timer.Elapsed += ParameterQueueMonitoring;
            _timer.Enabled = true;
        }

        public void ParameterQueueMonitoring(object sender, ElapsedEventArgs e)
        {
            if (_generator is null)
            {
                return;
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                ParameterQueueStatus.Add(new ParameterQueueSize
                {
                    TimeStamp = DateTime.Now,
                    Size = _generator.ParameterQueue.Count
                });
            });
        }
    }

    public class ParameterQueueSize
    {
        public DateTime TimeStamp { get; set; }
        public int Size { get; set; }
    }
}
