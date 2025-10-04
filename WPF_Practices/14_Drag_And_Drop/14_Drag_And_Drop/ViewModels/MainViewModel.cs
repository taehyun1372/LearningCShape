using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _14_Drag_And_Drop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _startIndex;
        private int _endIndex;
        private bool _dragging = false;

        private int _countFirst;
        public int CountFirst
        {
            get
            {
                return _countFirst;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _countFirst = value;
                OnPropertyChanged(nameof(CountFirst));

            }
        }
        private int _countSecond;
        public int CountSecond
        {
            get
            {
                return _countSecond;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _countSecond = value;
                OnPropertyChanged(nameof(CountSecond));

            }
        }
        private int _countThird;
        public int CountThird
        {
            get
            {
                return _countThird;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _countThird = value;
                OnPropertyChanged(nameof(CountThird));

            }
        }
        public MainViewModel()
        {
            CountFirst = 0;
            CountSecond = 0;
            CountThird = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void DragStarted(int index)
        {
            _startIndex = index;
            _dragging = true;
                
        }

        public void UpdateSelectedButton(int index)
        {
            if (_dragging == true)
            {
                _endIndex = index;
            }
        }

        public void DropFinished()
        {
            if (_dragging == true)
            {
                switch (_startIndex)
                {
                    case 1:
                        CountFirst--;
                        break;
                    case 2:
                        CountSecond--;
                        break;
                    case 3:
                        CountThird--;
                        break;
                }

                switch (_endIndex)
                {
                    case 1:
                        CountFirst++;
                        break;
                    case 2:
                        CountSecond++;
                        break;
                    case 3:
                        CountThird++;
                        break;
                }

                _dragging = false;
            }
        }
    }
}
