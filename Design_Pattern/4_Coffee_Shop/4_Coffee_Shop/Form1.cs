using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_Coffee_Shop
{
    public partial class Form1 : Form
    {
        private IBeverage _currentItem;
        public Form1()
        {
            InitializeComponent();
            cbBeverage.Items.Add("None");
            cbBeverage.Items.Add("Coffee");
            cbBeverage.Items.Add("Latte");
            cbBeverage.Items.Add("DeCaffein");
            cbBeverage.SelectedItem = "None";
        }

        private void cbBeverage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cbBeverage.SelectedItem;
            if (item.ToString() == "Coffee") _currentItem = new Coffee();
            else if (item.ToString() == "Latte") _currentItem = new Latte();
            else if (item.ToString() == "DeCaffein") _currentItem = new DeCaffein();
            if (_currentItem != null)
            {
                tbTotalPrice.Text = _currentItem.getPrice().ToString();
                tbOrder.Text = _currentItem.getDescription();
            }
            

        }

        private void btnMilk_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbMilk.Text, out int result))
            {
                if (_currentItem != null && result >= 1)
                {
                    for (int i = 0; i < result; i++)
                    {
                        _currentItem = new Milk(_currentItem);
                    }
                    tbTotalPrice.Text = _currentItem.getPrice().ToString();
                    tbOrder.Text = _currentItem.getDescription();
                }
            }
        }

        private void btnMocha_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbMocha.Text, out int result))
            {
                if (_currentItem != null && result >= 1)
                {
                    for (int i = 0; i < result; i++)
                    {
                        _currentItem = new Mocha(_currentItem);
                    }
                    tbTotalPrice.Text = _currentItem.getPrice().ToString();
                    tbOrder.Text = _currentItem.getDescription();
                }
            }
        }

        private void btnSoy_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbSoy.Text, out int result))
            {
                if (_currentItem != null && result >= 1)
                {
                    for (int i = 0; i < result; i++)
                    {
                        _currentItem = new Soy(_currentItem);
                    }
                    tbTotalPrice.Text = _currentItem.getPrice().ToString();
                    tbOrder.Text = _currentItem.getDescription();
                }
            }
        }
    }

    public interface IBeverage
    {
        string Description { get; set; }
        int getPrice();
        string getDescription();
    }

    public class Coffee : IBeverage
    {
        public string Description { get; set; }
        public Coffee()
        {
            Description = "Coffee";
        }
        public int getPrice()
        {
            return 100;
        }

        public string getDescription()
        {
            return Description;
        }
    }

    public class Latte : IBeverage
    {
        public string Description { get; set; }
        public Latte()
        {
            Description = "Latte";
        }
        public int getPrice()
        {
            return 120;
        }
        public string getDescription()
        {
            return Description;
        }
    }

    public class DeCaffein : IBeverage
    {
        public string Description { get; set; }
        public DeCaffein()
        {
            Description = "DeCaffein";
        }

        public int getPrice()
        {
            return 150;
        }
        public string getDescription()
        {
            return Description;
        }
    }

    public abstract class Decorator : IBeverage
    {
        private IBeverage _beverage;
        public string Description { get; set; }

        public Decorator(IBeverage beverage)
        {
            _beverage = beverage;
        }


        public virtual int getPrice()
        {
            return _beverage.getPrice();
        }

        public virtual string getDescription()
        {
            return _beverage.getDescription();
        }
    }

    public class Milk : Decorator
    {
        public Milk(IBeverage beverage) : base(beverage)
        {
            Description = "Milk";
        }

        public override int getPrice()
        {
            return base.getPrice() + 20;
        }

        public override string getDescription()
        {
            return base.getDescription() + " " + Description;
        }
    }

    public class Mocha : Decorator
    {
        public Mocha(IBeverage beverage) : base(beverage)
        {
            Description = "Mocha";
        }

        public override int getPrice()
        {
            return base.getPrice() + 12;
        }
        public override string getDescription()
        {
            return base.getDescription() + " " + Description;
        }
    }

    public class Soy : Decorator
    {
        public Soy(IBeverage beverage) : base(beverage)
        {
            Description = "Soy";
        }

        public override int getPrice()
        {
            return base.getPrice() + 3;
        }
        public override string getDescription()
        {
            return base.getDescription() + " " + Description;
        }
    }

}
