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
using _5_Modbus_Mirror.ViewModels;
using _5_Modbus_Mirror.Views;

namespace _5_Modbus_Mirror
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainGridViewModel = new MainGridViewModel();
            var mainGridView = new MainGrid(mainGridViewModel);
            ccMain.Content = mainGridView;

        }
    }
}
