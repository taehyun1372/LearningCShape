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

namespace _14_Routed_Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MyPanel.AddHandler( //We can catch any routed event that is not listed in XMAL 
                UIElement.MouseDownEvent,
                new MouseButtonEventHandler(StackPanel_Click),
                handledEventsToo: true
                );
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("An button click event from a child element has been catched");
            if (e.OriginalSource is Button btn)
            {
                MessageBox.Show(btn.Content.ToString()); //sendr : who is handlling the event, e.OriginalSource : who triggered the event 
            }
        }

        private void MyPanel_TwentyDetected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("An value 20 event from a child element has been catched");
            if (e.OriginalSource is CustomTextBox tb)
            {
                MessageBox.Show(tb.Text); //sendr : who is handlling the event, e.OriginalSource : who triggered the event 
            }
        }
    }
}
