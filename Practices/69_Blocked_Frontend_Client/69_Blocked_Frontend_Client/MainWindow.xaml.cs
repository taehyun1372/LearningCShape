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
using System.ServiceModel;
using _69_Blocked_Frontend_Client.Interface;

namespace _69_Blocked_Frontend_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChannelFactory<IParameterInterface> _factory;
        IParameterInterface _proxy;

        public MainWindow()
        {
            InitializeComponent();

            _factory = new ChannelFactory<IParameterInterface>("netTcpBinding_IParameterInterface");
            _proxy = _factory.CreateChannel();
            
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1000; i ++)
            {
                _proxy.ParameterLogRequest(1234);
            }
        }
    }
}
