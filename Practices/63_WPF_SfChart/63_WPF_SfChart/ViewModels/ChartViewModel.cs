using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace _63_WPF_SfChart.ViewModels
{
    public class ChartViewModel
    {
        public ObservableCollection<AnnualPriceData> AnnualPriceCollection { get; set; }
        public ChartViewModel()
        {
            AnnualPriceCollection = new ObservableCollection<AnnualPriceData>();
            AnnualPriceCollection.Add(new AnnualPriceData()
            {
                Year = "2012",
                PriceCollection = new ObservableCollection<PriceData>()
      {
        new PriceData() {Component = "Hard Disk", Price = 80 },
        new PriceData() {Component = "Scanner", Price = 140  },
        new PriceData() {Component = "Monitor", Price = 150  },
        new PriceData() {Component = "Printer", Price = 180  },
      }
            });

            AnnualPriceCollection.Add(new AnnualPriceData()
            {
                Year = "2013",
                PriceCollection = new ObservableCollection<PriceData>()
      {
        new PriceData() {Component = "Hard Disk", Price = 87 },
        new PriceData() {Component = "Scanner", Price = 157  },
        new PriceData() {Component = "Monitor", Price = 155  },
        new PriceData() {Component = "Printer", Price = 192  },
      }
            });

            AnnualPriceCollection.Add(new AnnualPriceData()
            {
                Year = "2014",
                PriceCollection = new ObservableCollection<PriceData>()
      {
        new PriceData() {Component = "Hard Disk", Price = 95 },
        new PriceData() {Component = "Scanner", Price = 150  },
        new PriceData() {Component = "Monitor", Price = 163  },
        new PriceData() {Component = "Printer", Price = 185  },
      }
            });

            AnnualPriceCollection.Add(new AnnualPriceData()
            {
                Year = "2015",
                PriceCollection = new ObservableCollection<PriceData>()
      {
        new PriceData() {Component = "Hard Disk", Price = 113 },
        new PriceData() {Component = "Scanner", Price = 165  },
        new PriceData() {Component = "Monitor", Price = 175  },
        new PriceData() {Component = "Printer", Price = 212  },
      }
            });

            AnnualPriceCollection.Add(new AnnualPriceData()
            {
                Year = "2016",
                PriceCollection = new ObservableCollection<PriceData>()
      {
        new PriceData() {Component = "Hard Disk", Price = 123 },
        new PriceData() {Component = "Scanner", Price = 169 },
        new PriceData() {Component = "Monitor", Price = 184 },
        new PriceData() {Component = "Printer", Price = 224 },
      }
            });
        }
    }

    public class Log
    {
        public int Time { get; set; }
        public int Value { get; set; }

    }

    public class PriceData
    {
        public string Component { get; set; }
        public double Price { get; set; }
    }
    public class AnnualPriceData
    {
        public string Year { get; set; }
        public ObservableCollection<PriceData> PriceCollection { get; set; }
    }


}
