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
        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value != _count)
                {
                    _count = value;
                    UpdateUI(_count);
                }
            }
        }
        public StackView()
        {
            InitializeComponent();
        }

        private void UpdateUI(int count)
        {
            spMain.Children.Clear();
            for (int i = 0; i < count; i++)
            {
                var rect = new Rectangle(){ Width=i*20, Height=20, Fill=Brushes.LightBlue};
                spMain.Children.Add(rect);
            }
        }
    }
}
