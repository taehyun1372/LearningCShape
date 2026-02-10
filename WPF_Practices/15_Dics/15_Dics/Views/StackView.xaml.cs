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
using _15_Dics.ViewModels;

namespace _15_Dics.Views
{
    /// <summary>
    /// Interaction logic for StackView.xaml
    /// </summary>
    public partial class StackView : UserControl
    {
        private StackViewModel _model;
        public StackView(StackViewModel model)
        {
            InitializeComponent();
            _model = model;
            this.DataContext = model;
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _model.DestackDisc();
        }

        private void StackPanel_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _model.OnPreviewMouseUp(sender, e);
        }
    }
}
