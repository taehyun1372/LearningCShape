using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using _9_ItemsControl.Modules;

namespace _9_ItemsControl
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainView View1Module { get; set; } = new MainView("View 1");
        public MainView View2Module { get; set; } = new MainView("View 2");
        public MainView View3Module { get; set; } = new MainView("View 3");
        public MainView View4Module { get; set; } = new MainView("View 4");
        public MainView View5Module { get; set; } = new MainView("View 5");
        public MainView View6Module { get; set; } = new MainView("View 6");
        public MainView View7Module { get; set; } = new MainView("View 7");
        public MainView View8Module { get; set; } = new MainView("View 8");
        public MainView View9Module { get; set; } = new MainView("View 9");

        public MainWindowViewModel()
        {

            var menuViewModel2 = new MenuViewModel2(this);
            var menuView2 = new MenuView2(menuViewModel2);

            MenuView = menuView2;

            CurrentView = View1Module;
        }

        private MenuView2 _menuView;
        public MenuView2 MenuView
        {
            get
            {
                return _menuView;
            }
            set
            {
                _menuView = value;
                OnPropertyChanged(nameof(MenuView));
            }
        }


        private MainView _currentView;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainView CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
