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
using _5_Modbus_Mirror.ViewModels;

namespace _5_Modbus_Mirror.Views
{
    /// <summary>
    /// Interaction logic for MainGrid.xaml
    /// </summary>
    public partial class MainGrid : UserControl
    {
        private MainGridViewModel _model;
        public event Action<DataChangedEventArgs> DataChanged;
        public MainGrid(MainGridViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
            DataChanged += _model.OnDataChanged;
        }

        private void myDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int rowIndex = e.Row.GetIndex();
            int columnIndex = e.Column.DisplayIndex;

            var editingElement = e.EditingElement as TextBox;
            string newValue = editingElement?.Text;

            if (int.TryParse(newValue, out int value))
            {
                DataChanged?.Invoke(new DataChangedEventArgs()
                {
                    Row = (ushort)rowIndex,
                    Column = (ushort)columnIndex,
                    Value = (ushort)value
                });
            }
        }
    }

    public class DataChangedEventArgs
    {
        public ushort Row { get; set; }
        public ushort Column { get; set; }
        public ushort Value { get; set; }
    }
}
