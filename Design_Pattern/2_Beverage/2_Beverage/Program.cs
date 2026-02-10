
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2_Beverage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ordering..");
            var order1 = new HouseBlend();
            order1.Soy = true;
            order1.Milk = true;

            var order2 = new DarkRoast();
            order2.Whip = true;

            Console.WriteLine("Order finished..");
            foreach (var item in order1.getBeverages())
            {
                Console.WriteLine(item.getDescription());
                Console.WriteLine(item.cost());
            }

            Console.ReadLine();
        }
    }

    public interface IBeverage
    {
        string getDescription();
        void addBeverage(IBeverage beverage);
        List<IBeverage> getBeverages();
        int cost();
    }

    public abstract class Beverage : IBeverage
    {
        protected string _description;
        protected static List<IBeverage> _beverages = new List<IBeverage>();
        private bool _milk = false;
        private bool _soy = false;
        private bool _mocha = false;
        private bool _whip = false;

        public bool Milk { get; set; }
        public bool Soy { get; set; }
        public bool Mocha { get; set; }
        public bool Whip { get; set; }

        public string getDescription()
        {
            return _description;
        }

        protected void addBeverage(IBeverage beverage)
        {
            _beverages.Add(beverage);
        }

        public virtual int cost()
        {
            var cost = 0;
            if (Milk) cost += 10;
            if (Soy) cost += 2;
            if (Mocha) cost += 7;
            if (Whip) cost += 5;
            return cost;
        }

        void IBeverage.addBeverage(IBeverage beverage)
        {
            addBeverage(beverage);
        }

        public List<IBeverage> getBeverages()
        {
            return _beverages;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            base._description = "House Blend";
            base.addBeverage(this);
        }
        public override int cost()
        {
            var cost = base.cost();
            cost += 110;
            return cost;
        }
    }

    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            base._description = "Dark Roast";
            base.addBeverage(this);
        }
        public override int cost()
        {
            var cost = base.cost();
            cost += 220;
            return cost;
        }
    }


}
