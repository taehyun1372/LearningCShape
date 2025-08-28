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
using _66_Async_Performance.Core;
using _66_Async_Performance.ViewModels;
using _66_Async_Performance.Views;


namespace _66_Async_Performance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ParameterGenerator _generator;
        private ChartView _view;
        private ChartViewModel _model;
        private DBThreadLogger _logger;

        public MainWindow()
        {
            InitializeComponent();
            _generator = new ParameterGenerator(1000, 500);

            _logger = new DBThreadLogger(_generator);

            _model = new ChartViewModel(_generator);
            _view = new ChartView(_model);

            ccMain.Content = _view;


        }
    }
}
