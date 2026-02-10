using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _5_Pizza_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var pizzaStore = new NYStylePizzaStore();
            var order1 = pizzaStore.orderPizza("cheese");
            Console.WriteLine(order1.getName());

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }

    public abstract class PizzaStore
    {
        public Pizza orderPizza(string type)
        {
            Pizza pizza = createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }

        public abstract Pizza createPizza(string type);
    }

    public class NYStylePizzaStore : PizzaStore
    {
        public override Pizza createPizza(string type)
        {
            if (type == "cheese") return new NYStyleCheesePizza("cheese");
            else if(type == "pepperoni") return new NYStyleCheesePizza("pepperoni");
            else if (type == "clam") return new NYStyleCheesePizza("clam");
            else if (type == "veggie") return new NYStyleCheesePizza("veggie");
            else return null;
        }
    }

    public class ChicagoStylePizzaStore : PizzaStore
    {
        public override Pizza createPizza(string type)
        {
            if (type == "cheese") return new ChicagoStyleCheesePizza("cheese");
            else if (type == "pepperoni") return new ChicagoStyleCheesePizza("pepperoni");
            else if (type == "clam") return new ChicagoStyleCheesePizza("clam");
            else if (type == "veggie") return new ChicagoStyleCheesePizza("veggie");
            else return null;
        }
    }


    public abstract class Pizza
    {
        protected string name;
        protected string dough;
        protected string sauce;
        protected List<string> toppings = new List<string>();

        public void prepare()
        {
            Console.WriteLine("Preparing.." + name);
            Console.WriteLine("Making dough..");
            Console.WriteLine("Putting some sauce..");
            Console.WriteLine("Putting toppings..");
            foreach(var topping in toppings) Console.WriteLine(" " +  topping);

        }

        public void bake() { Console.WriteLine("baking 20 minutes in 170 degreen oven"); }
        public virtual void cut() { Console.WriteLine("Cutting the pizza.."); }
        public void box() { Console.WriteLine("Putting the pizza into a box.."); }

        public string getName()
        {
            return name;
        }
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza(string topping = "")
        {
            name = "Newyork style sauce cheese pizza";
            dough = "Thin crust dough";
            sauce = "Spicy sauce";

            toppings.Add(topping);
        }
    }

    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza(string topping = "")
        {
            name = "Chicago style deep dish cheese pizza";
            dough = "Very thick crust dough";
            sauce = "Totato sauce";

            toppings.Add(topping);
        }

        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into a rectangluar shape");
        }
    }
}
