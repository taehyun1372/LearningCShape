using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _3_Lambda
{
    class Program
    {
        public delegate void OneParameterDelegate(int value);
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Console.WriteLine("Enter 1 or something else");
            OneParameterDelegate del1; //Method implementation can be stored/referenced using delegate
            Action<int> act1; //Method implementation can be stored/referenced using Action

            var userInput1 = Console.ReadLine();
            if (userInput1 == "1")
            {
                act1 = DisplaySomething;
            }
            else
            {
                act1 = LogSomething;
            }
            act1(10);

            Console.WriteLine("-------------------");
            Console.WriteLine("Enter A or something else");

            Action<int> act2;
            var userInput2 = Console.ReadLine();
            if (userInput2 == "A")
            {
                act2 = (i) => Console.WriteLine($"Display : {i}");
            }
            else
            {
                act2 = (i) => Console.WriteLine($"Logging : {i}");
            }
            act2(20);

            Console.WriteLine("-------------------");
            Console.WriteLine("Enter # or something else");

            Processor processor = new Processor();
            var userInput3 = Console.ReadLine();

            if (userInput3 == "#")
            {
                processor.Process = i => Console.WriteLine($"Display : {i}");
            }
            else
            {
                processor.Process = i => Console.WriteLine($"Logging : {i}");
            }
            processor.Start(30);
            Console.ReadLine();
        }


        static public void DisplaySomething(int parameter)
        {
            Console.WriteLine($"Display : {parameter}");
        }


        static public void LogSomething(int parameter)
        {
            Console.WriteLine($"Logging : {parameter}");
        }
    }

    public class Processor
    {
        private Action<int> _processor;
        public Action<int> Process
        {
            get
            {
                return _processor;
            }
            set
            {
                _processor = value;
            }
        }
        public Processor(Action<int> process = null)
        {
            Process = process;
        }

        public void Start(int parameter)
        {
            while(true)
            {
                if (_processor != null)
                {
                    _processor(parameter);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
