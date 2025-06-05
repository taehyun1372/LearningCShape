using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _11_DependencyProperty
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
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


    }
}
