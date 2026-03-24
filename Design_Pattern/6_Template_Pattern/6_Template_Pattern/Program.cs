using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Template_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something..");
            var displayer1 = new delicateDisplayer();
            var displayer2 = new highlightDisplayer();

            Displayer displayer3 = new highlightDisplayer();


            displayer1.display("Important log");
            displayer2.display("High temperature");
            displayer3.display("Water leak raised");
            Console.ReadLine();
        }
    }

    public abstract class Displayer
    {
        public void display(string message)
        {
            open();
            for (int i = 0; i < 5; i++) main(message);
            close();
        }

        abstract public void open();
        abstract public void close();
        abstract public void main(string message);
        abstract public void open2();
    }

    public class delicateDisplayer : Displayer
    {
        public override void open()
        {
            Console.Write("<<");
        }
        public override void close()
        {
            Console.Write(">>");
        }
        public override void main(string message)
        {
            Console.Write($"{message},");
        }

        public override void open2()
        {
            throw new NotImplementedException();
        }
    }

    public class highlightDisplayer : Displayer
    {
        public override void open()
        {
            Console.WriteLine("**");
        }
        public override void close()
        {
            Console.WriteLine("**");
        }
        public override void main(string message)
        {
            Console.WriteLine($"{message}");
        }

        public void additionalFunction()
        {
            Console.WriteLine("Additional lines");
        }

        public override void open2()
        {
            throw new NotImplementedException();
        }
    }
}
