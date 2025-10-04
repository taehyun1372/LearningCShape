using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace _11_DependencyProperty
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public MainWindowViewModel()
        {
            HoveringColor = 3;
        }

        private string _dynamicMessage;
        public string DynamicMessage
        {
            get
            {
                return _dynamicMessage;
            }
            set
            {
                _dynamicMessage = value;
                OnPropertyChanged(nameof(DynamicMessage));
            }
        }

        private int _hoveringColor;
        public int HoveringColor
        {
            get { return _hoveringColor; }
            set 
            { 
                _hoveringColor = value;
                OnPropertyChanged(nameof(HoveringColor));
            }
        }


    }
}
