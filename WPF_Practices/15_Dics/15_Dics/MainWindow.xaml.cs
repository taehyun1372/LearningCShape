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
using _15_Dics.Views;
using _15_Dics.ViewModels;

namespace _15_Dics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StackView _stack1;
        private StackView _stack2;
        private StackView _stack3;

        public MainWindow()
        {
            InitializeComponent();
            _stack1 = Stack1;

            StackViewModel viewModel2 = new StackViewModel();
            _stack2 = new StackView();
            ccMain2.Content = _stack2;

            StackViewModel viewModel3 = new StackViewModel();
            _stack3 = new StackView();
            ccMain3.Content = _stack3;
        }

        private void btnButton1_Click(object sender, RoutedEventArgs e)
        {
            _stack1.Count++;
        }
    }
}
