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

namespace _1_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Code behind to set a bindnings
            //Binding binding = new Binding();
            //binding.Source = treeView;
            //binding.Path = new PropertyPath("SelectedItem.Header");
            //currentFolder.SetBinding(TextBlock.TextProperty, binding);
            //BindingOperations.SetBinding(currentFolder, TextBlock.TextProperty, binding);
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //If there isn't a binding, you have to manually update the UI property
            //currentFolder.Text = (treeView.SelectedItem as TreeViewItem).Header.ToString(); 

        }

        private void currentFolder_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //This is a way to cut the bindnig dynamically
            BindingOperations.ClearBinding(currentFolder, TextBlock.TextProperty);
        }
    }

    public class Collection
    {
        public Collection()
        {

        }
        
        public int Count { get; set; }
    }
}
