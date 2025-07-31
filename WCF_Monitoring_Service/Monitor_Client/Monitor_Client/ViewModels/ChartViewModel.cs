using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Monitor_Client.ViewModels
{
    public class ChartViewModel
    {
        public ObservableCollection<DataPoint> Series1 { get; set; }
        public ObservableCollection<DataPoint> Series2 { get; set; }
        public ObservableCollection<DataPoint> Series3 { get; set; }

        public ChartViewModel()
        {
            Series1 = new ObservableCollection<DataPoint>
            {
                new DataPoint{Date="Mon", Value=20},
                new DataPoint{Date="Tue", Value=35},
                new DataPoint{Date="Wed", Value=40},
                new DataPoint{Date="Thu", Value=35},
                new DataPoint{Date="Fri", Value=40},
                new DataPoint{Date="Sat", Value=45},
            };

            Series2 = new ObservableCollection<DataPoint>
            {
                new DataPoint{Date="Mon", Value=80},
                new DataPoint{Date="Tue", Value=75},
                new DataPoint{Date="Wed", Value=70},
                new DataPoint{Date="Thu", Value=75},
                new DataPoint{Date="Fri", Value=70},
                new DataPoint{Date="Sat", Value=65},
            };

            Series3 = new ObservableCollection<DataPoint>
            {
                new DataPoint{Date="Mon", Value=0},
                new DataPoint{Date="Tue", Value=0},
                new DataPoint{Date="Wed", Value=5},
                new DataPoint{Date="Thu", Value=10},
                new DataPoint{Date="Fri", Value=15},
                new DataPoint{Date="Sat", Value=5},
            };
        }
    }

    public class DataPoint
    {
        public string Date { get; set; }
        public double Value { get; set; }

    }
}
