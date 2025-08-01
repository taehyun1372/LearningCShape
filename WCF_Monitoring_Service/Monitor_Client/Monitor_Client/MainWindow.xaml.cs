using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Monitor_Client.Views;
using Monitor_Client.ViewModels;
using Monitor_Client.Core;

namespace Monitor_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChartView _chartView;
        private ChartViewModel _chartViewModel;
        private ValueProvider _valueProvider;
        public MainWindow()
        {
            InitializeComponent();

            _valueProvider = new ValueProvider();
            _chartViewModel = new ChartViewModel(_valueProvider);
            _chartView = new ChartView(_chartViewModel);
            ccChart.Content = _chartView;

        }
    }
}
