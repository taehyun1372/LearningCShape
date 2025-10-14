using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _15_Dics.ViewModels
{
    public class StackViewModel
    {
        public ObservableCollection<DiscModel> Discs { get; set; }
        public int Id { get; set; }
        public static event Action<object> RollbackRequired;
        public static event Action<object> StackCompleted;
        private static int _tempWidth = -1;
        private DiscModel _tempDiscModel;

        public StackViewModel(int id, int num = 0)
        {
            Id = id;
            Discs = new ObservableCollection<DiscModel>();
            for (int i = num - 1; i >= 0; i--)
            {
                StackDisc(10 + i * 10);
            }
            RollbackRequired += Rollback;
            StackCompleted += DisposeTempObjects;
        }

        private void DisposeTempObjects(object obj)
        {
            _tempWidth = -1;
            _tempDiscModel = null;
        }

        public void StackDisc(int width)
        {
            if (IsStackable()) 
            {
                Discs.Insert(0, new DiscModel() //Stacking is success
                {
                    Id = Discs.Count(),
                    Color = "LightGray",
                    Width = width,
                    Height = 15
                });
            }
            else
            {
                RollbackRequired?.Invoke(this); //Catch the failure and rollback
            }
        }

        public void DestackDisc()
        {
            if (Discs.Count > 0)
            {
                _tempDiscModel = Discs.First<DiscModel>(); //Saving the removed object for rollback
                _tempWidth = _tempDiscModel.Width; //Saving the removed object for rollback
                Discs.RemoveAt(0);
            }
        }

        public void Rollback(object sender)
        {
            if (_tempDiscModel != null && _tempWidth > 0)
            {
                StackDisc(_tempWidth);
                _tempDiscModel = null;
                _tempWidth = -1;
            }
        }

        public int GetTopWidth()
        {
            if (Discs.Count() > 0)
            {
                return Discs.First<DiscModel>().Width;
            }
            else
            {
                return 9999;
            }
        }

        public bool IsStackable()
        {
            var width = GetTopWidth();
            if (width > _tempWidth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_tempWidth > 0)
            {
                StackDisc(_tempWidth);
                _tempWidth = -1;
            }
        }
    }

    public class DiscModel
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Width { get; set; } = 50;   // default width
        public int Height { get; set; } = 50;  // default height
    }
}
