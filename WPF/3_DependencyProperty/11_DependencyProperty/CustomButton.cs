using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _11_DependencyProperty
{
    public class CustomButton : Button
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(
                "Message",
                typeof(string),
                typeof(CustomButton),
                new PropertyMetadata("Default Value"));

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public CustomButton() :base()
        {
            this.Click += (s, e) =>
            {
                MessageBox.Show(Message);
            };
        }

        public string StaticMessage { get; set; }
    }
}
