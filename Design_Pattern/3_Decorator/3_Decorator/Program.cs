using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _3_Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ordering..");

            var order1 = new Whip(new Whip(new Espresso()));
            Console.WriteLine(order1.Cost());
            Console.WriteLine("Finished ordering..");
            Console.ReadLine();
        }
    }
    
    public interface IBeveage
    {
        decimal Cost();
    }

    public class  Espresso : IBeveage
    {
        public decimal Cost()
        {
            return 20;
        }
    }

    public abstract class BeverageDecorator :IBeveage
    {
        protected readonly IBeveage _beverage;
        protected BeverageDecorator(IBeveage beverage)
        {
            _beverage = beverage;
        }

        public abstract decimal Cost();
    }

    public class Whip : BeverageDecorator
    {
        public Whip(IBeveage beverage) : base(beverage) { }
        public override decimal Cost()
        {
            {
                return _beverage.Cost() + 2;
            }
        }
    }
}
