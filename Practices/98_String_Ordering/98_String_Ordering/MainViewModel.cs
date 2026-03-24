using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace _98_String_Ordering
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<string> _selections = new ObservableCollection<string>();
        public ObservableCollection<string> Selections
        {
            get { return _selections; }
            set { _selections = value; }
        }
        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set 
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private string _keyword;
        public string Keyword
        {
            get { return _keyword; }
            set
            {
                if (_keyword != value)
                {
                    _keyword = value;
                    OnPropertyChanged(nameof(Keyword));
                }
            }
        }

        public MainViewModel()
        {
            foreach(var item in SinglePermutations("abc"))
            {
                Selections.Add(item);
            }

            SelectedItem = Selections[1];

        }

        public void OnTextChanged()
        {
            foreach(var item in Selections)
            {
                if (Keyword == item)
                {
                   SelectedItem = item;
                }
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static List<string> SinglePermutations(string s)
        {
            var result = new List<string>();
            foreach(var c1 in s)
            {
                foreach(var c2 in s)
                {
                    c1.
                }

            return result.Distinct().ToList();
        }

    }
}
