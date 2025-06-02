using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using _9_ItemsControl.Modules;

namespace _9_ItemsControl
{
    public class MenuViewModel2
    {

        public ObservableCollection<ButtonModel> Buttons { get; set; } = new ObservableCollection<ButtonModel>();

        public MainWindowViewModel MainModel { get; set; }

        public MenuViewModel2(MainWindowViewModel model)
        {
            MainModel = model;
            for (int i = 1; i < 10; i++)
            {
                var button = new ButtonModel()
                {
                    Label = $"Button {i}",
                    Id = i,
                    Command = new RelayCommand(
                        (p) =>
                        {
                            if (MainModel==null)
                            {
                                return;
                            }
                            if (p is int id)
                            {
                                var moduleName = $"View{id}Module";
                                var propertyInfo = typeof(MainWindowViewModel).GetProperty(moduleName);

                                if (propertyInfo != null)
                                {
                                    var value = propertyInfo.GetValue(MainModel);
                                    if (value is MainView mainView)
                                    {
                                        MainModel.CurrentView = mainView;
                                    }
                                    
                                }
                            }
                        })
                };
                Buttons.Add(button);
            }
        }

    }

    public class ButtonModel
    {
        public string Label { get; set; }
        public ICommand Command { get; set; }
        public int Id { get; set; }
    }
}
