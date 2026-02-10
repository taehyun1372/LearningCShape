using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2_Race_Condition
{
    internal class Program
    {

        private static int _count = 0;
        private static object _lock = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Thread th1 = new Thread(() => Increase(800000));
            th1.Start();
            

            Thread th2 = new Thread(() => Decrease(800000));
            th2.Start();
            

            th1.Join();
            th2.Join();
            Console.WriteLine($"Result : {_count}");
            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }

        static void Increase(int count)
        {
            Console.WriteLine("Task 1 is in progress");
            
            for (int i = 0; i < count; i++)
            {
                lock(_lock)
                {
                    _count++;
                }
            }
            Console.WriteLine("Task 1 is finished");

        }

        static void Decrease(int count)
        {
            Console.WriteLine("Task 2 is finished");
            for (int i = 0; i < count; i++)
            {
                lock (_lock)
                {
                    _count--;
                }
            }
        }
    }
}
