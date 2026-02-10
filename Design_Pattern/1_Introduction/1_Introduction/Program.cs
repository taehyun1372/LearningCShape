using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Introduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var mallard1 = new MallardDuck();
            mallard1.perfromQuack();
            mallard1.swim();
            mallard1.display();
            mallard1.perfromFly();
            Console.WriteLine("Chaning how it flies..");
            mallard1.FlyBehavior = new FlyRocketPowered();
            mallard1.perfromFly();

            var redhead1 = new RedheadDuck();
            redhead1.perfromQuack();
            redhead1.swim();
            redhead1.display();
            mallard1.perfromFly();

            var rubber1 = new RubberDuck();
            rubber1.perfromQuack();
            rubber1.swim();
            rubber1.display();
            rubber1.perfromFly(); //Absurd for a rubber duck

            var decoy1 = new DecoyDuck();
            decoy1.perfromQuack(); //Absurd for a decoy duck
            decoy1.swim();
            decoy1.display();
            decoy1.perfromFly(); //Absurd for a decoy duck

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }

    public interface FlyBehavior
    {
        void fly();
    }

    public interface QuackBehavior
    {
        void quack();
    }

    public class FlyWithWings : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("Fly with wings");
        }
    }

    public class FlyNoWay : FlyBehavior
    {
        public void fly()
        {
            return;
        }
    }

    public class FlyRocketPowered : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("Fly by rocket power");
        }
    }

    public class Quack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Original Quack");
        }
    }

    public class Squeak : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Squeaking");
        }
    }

    public class MuteQuack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Mute Quack");
        }
    }

    public abstract class Duck
    {
        private FlyBehavior _flyBehavior;
        public FlyBehavior FlyBehavior
        {
            set { _flyBehavior = value; }
        }
        private QuackBehavior _quackBehavior;
        public QuackBehavior QuackBehavior
        {
            set { _quackBehavior = value; }
        }

        public Duck()
        {
            Console.WriteLine($"A {this.GetType().ToString().Split('.')[1]} instance created..");
        }
        public virtual void perfromQuack()
        {
            _quackBehavior?.quack();
        }
        public void swim()
        {
            Console.WriteLine("Original Swim");
        }
        public virtual void display()
        {
            Console.WriteLine("Original Display");
        }
        public virtual void perfromFly()
        {
            _flyBehavior?.fly();
        }
    }

    public class MallardDuck : Duck 
    {
        public MallardDuck()
        {
            this.FlyBehavior = new FlyWithWings();
            this.QuackBehavior = new Quack();
        }
        public override void display()
        {
            Console.WriteLine("Mallard Duck Display");
        }
    }

    public class RedheadDuck : Duck
    {
        public RedheadDuck()
        {
            this.FlyBehavior = new FlyWithWings();
            this.QuackBehavior = new Quack();
        }
        public override void display()
        {
            Console.WriteLine("Redhead Duck Display");
        }
    }

    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            this.QuackBehavior = new Squeak();
        }
    }

    public class DecoyDuck : Duck
    {
        public DecoyDuck()
        {
            this.QuackBehavior = new MuteQuack();
            this.FlyBehavior = new FlyNoWay();
        }

    }
}
