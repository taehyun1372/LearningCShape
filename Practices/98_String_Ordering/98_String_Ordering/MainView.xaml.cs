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

namespace _98_String_Ordering
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private MainViewModel _model;
        public MainView(MainViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _model?.OnTextChanged();
        }
    }
}
