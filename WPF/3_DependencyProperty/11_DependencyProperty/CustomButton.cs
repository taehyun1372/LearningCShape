using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        public static readonly DependencyProperty HoveringColorProperty =
            DependencyProperty.Register(
                "HoveringColor",
                typeof(int),
                typeof(CustomButton),
                new PropertyMetadata(0));  

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public int HoveringColor
        {
            get => (int)GetValue(HoveringColorProperty);
            set => SetValue(HoveringColorProperty, value);
        }

        public CustomButton() :base()
        {
            this.Click += (s, e) =>
            {
                MessageBox.Show(Message);
            };

            this.MouseEnter += (s, e) =>
            {
                _originalBackground = Content.ToString();
                Content = HoveringColor;
            };

            this.MouseLeave += (s, e) =>
            {
                Content = _originalBackground;
            };
        }

        public string StaticMessage { get; set; }

        private string _originalBackground;
    }
}
