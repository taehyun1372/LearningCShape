using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _7_Property_Trigger
{
    public class CustomButton : Button
    {
        public static readonly DependencyProperty HoveryingColorProperty = DependencyProperty.Register(
            "HoveryingColor",
            typeof(Brush),
            typeof(CustomButton),
            new PropertyMetadata(null));

        public Brush HoveringColor
        {
            get => (Brush)GetValue(HoveryingColorProperty);
            set => SetValue(HoveryingColorProperty, value);
        }

        public static DependencyProperty IsHoveringProperty = DependencyProperty.Register(
            "IsHovering",
            typeof(bool),
            typeof(CustomButton),
            new PropertyMetadata(false));

        public bool IsHovering
        {
            get =>(bool)GetValue(IsHoveringProperty);
            set => SetValue(IsHoveringProperty, value);
        }

        public CustomButton() :base()
        {
            this.Click += (s, e) =>
            {
                Background = HoveringColor;
                if (IsHovering)
                {
                    IsHovering = false;
                }
                else
                {
                    IsHovering = true;
                }
            };
        }
           
    }
}
