using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _14_Routed_Events
{
    public class CustomTextBox : TextBox
    {
        public static RoutedEvent TwentyDetectedEvent = EventManager.RegisterRoutedEvent("TwentyDetected",
                RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CustomTextBox));
        public CustomTextBox() : base()
        {
        }

        // 2️⃣ Provide CLR wrapper
        public event RoutedEventHandler TwentyDetected
        {
            add { AddHandler(TwentyDetectedEvent, value); }
            remove { RemoveHandler(TwentyDetectedEvent, value); }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            
            if ( Text == "20")
            {
                RaiseEvent(new RoutedEventArgs(TwentyDetectedEvent));
            }
        }

    }
}
