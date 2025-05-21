using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace _4_MVVM_Demo_Application.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        RelayCommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if(_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(param => this.Save(), param => this.CanSave());
                }
                return _saveCommand;
            }
        }

        public bool CanSave()
        {
            throw new NotImplementedException();
            return true;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


    }
}
