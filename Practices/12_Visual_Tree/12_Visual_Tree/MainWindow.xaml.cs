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

namespace _12_Visual_Tree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var button = FindVisualChild<RadioButton>(mainGrid);
            if (button != null)
            {
                MessageBox.Show(button.Content.ToString());
            }
        }

        //static T FindVisualChild<T>(object sender)
        //{
        //    T result;
        //    if (sender is DependencyObject dependency)
        //    {
        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependency); i++)
        //        {
        //            var child = VisualTreeHelper.GetChild(dependency, i);
        //            if (child is T target )
        //            {
        //                result = target;
        //            }
        //        }
        //    }
        //
        //    return result;
        //}

        static T FindVisualChild<T>(object sender)
        {
            if (sender is DependencyObject dependency)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependency); i++)
                {
                    var child = VisualTreeHelper.GetChild(dependency, i);

                    if (child is T target)
                        return target;

                    var result = FindVisualChild<T>(child);
                    if (!Equals(result, default(T)))
                        return result;
                }
            }

            return default(T);
        }


    }
}
