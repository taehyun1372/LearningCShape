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

namespace _9_ItemsControl
{
    /// <summary>
    /// Interaction logic for MainView2.xaml
    /// </summary>
    public partial class MenuView2 : UserControl
    {
        public MenuView2(MenuViewModel2 model)
        {
            InitializeComponent();
            this.DataContext = model;
        }
    }
}
