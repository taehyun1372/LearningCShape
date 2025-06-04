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
using System.Timers;
using System.Threading;

namespace _10_Thread_Affinity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public int _elapsedTime;
        public MainWindow()
        {
            InitializeComponent();
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            //timer.Elapsed += ManageButton;

            var customControl = new CustomControl();
            
            timer.Elapsed += (s, e) =>
            {
                //In background thraed 
                MessageBox.Show("In back ground thread [start]");

                //Application.Current.Dispatcher.Invoke(() =>
                //{//In UI Thread
                //    MessageBox.Show("In dispacher, Long running process has started");
                //    Thread.Sleep(5000);
                //
                //    _elapsedTime += 2;
                //    btnMain.Content = "Elapsed time : " + _elapsedTime.ToString();
                //});

                //Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                //{//In UI Thread
                //    MessageBox.Show("In UI thread, Long running process has started");
                //    Thread.Sleep(5000);
                //
                //    _elapsedTime += 2;
                //    btnMain.Content = "Elapsed time : " + _elapsedTime.ToString();
                //}));

                customControl.Id = 33; //An attempt to access a instance of DispatcherObject from a different thread fails 

                MessageBox.Show("In back ground thread [end]");

            };
            timer.AutoReset = false;
            timer.Enabled = true;


        }

        public void ManageButton(object sender, ElapsedEventArgs e)
        {
            _elapsedTime += 2;
            btnMain.Content = "Elapsed time : "+ _elapsedTime.ToString();
        }
    }
}
