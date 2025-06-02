using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using _9_ItemsControl.Modules;


namespace _9_ItemsControl
{
    public class MenuViewModel
    {
        private ObservableCollection<Button> _buttons;
        public ObservableCollection<Button> Buttons
        {
            get 
            {
                return _buttons;
            }
            set
            {
                _buttons = value;
            }
        }

        public MenuViewModel()
        {
            _buttons = new ObservableCollection<Button>();
            for (int i = 0; i < 10; i++)
            {
                var button = new Button() { Content = $"Button{i}" };
                Buttons.Add(button);
            }
        }


    }
}
