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
using _14_Drag_And_Drop.ViewModels;

namespace _14_Drag_And_Drop.Views
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
            _model = model;
            this.DataContext = model;
        }

        private void btnFirst_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            _model.DragStarted(1);
        }

        private void btnSecond_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            _model.DragStarted(2);
        }

        private void btnThird_PreviewMouseDown(object sender, RoutedEventArgs e)
        { 
            _model.DragStarted(3);
        }

        private void btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var index = 0;

            // Get the current mouse position relative to the window
            Point position = e.GetPosition(this);

            // Perform a hit test at that position
            HitTestResult result = VisualTreeHelper.HitTest(this, position);

            if (result != null)
            {
                DependencyObject hitObject = result.VisualHit;

                // Traverse up the visual tree until you find a Button
                while (hitObject != null && !(hitObject is Button))
                {
                    hitObject = VisualTreeHelper.GetParent(hitObject);
                }

                if (hitObject is Button button)
                {
                    if (button.Name == "btnFirst")
                    {
                        index = 1;
                    }
                    else if (button.Name == "btnSecond")
                    {
                        index = 2;
                    }
                    else if (button.Name == "btnThird")
                    {
                        index = 3;
                    }

                    _model.UpdateSelectedButton(index);

                    _model.DropFinished();
                }
            }
        }
    }
}
