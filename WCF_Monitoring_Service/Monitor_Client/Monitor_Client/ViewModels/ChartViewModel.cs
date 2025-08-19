using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;
using System.Windows;
using Monitor_Client.Interfaces;
using System.Collections.ObjectModel;

namespace Monitor_Client.ViewModels
{
    public class ChartViewModel
    {
        public ObservableCollection<ChartSeriesModel> SeriesCollection { get; set; }
        public ChartViewModel()
        {
            SeriesCollection = new ObservableCollection<ChartSeriesModel>();
        }

        public void AddSeries(int id, ObservableCollection<ParameterLog> logs)
        {
            SeriesCollection.Add(new ChartSeriesModel
            {
                Id = id,
                ParameterLog = logs
            });
        }

        internal void UpdateChartData(List<ParameterHistoryData> data)
        {
            Dictionary<int, ObservableCollection<ParameterLog>> dataSet = new Dictionary<int, ObservableCollection<ParameterLog>>();

            foreach (ParameterHistoryData item in data)
            {
                if (!dataSet.ContainsKey(item.Id))
                {
                    dataSet.Add(item.Id,new ObservableCollection<ParameterLog>());
                }
                dataSet[item.Id].Add(new ParameterLog() { Value=item.Value, Timestamp=item.TimeStamp});
            }

            foreach (KeyValuePair<int, ObservableCollection<ParameterLog>> kvp in dataSet)
            {
                AddSeries(kvp.Key, kvp.Value);
            }
        }
    }

    public class ChartSeriesModel
    {
        public int Id { get; set; }
        public ObservableCollection<ParameterLog> ParameterLog { get; set; }
    }

    public class ParameterLog
    {
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
    }
}
