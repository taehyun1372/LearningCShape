using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _41_Multi_Thread_Access
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            int count = 0;
            bool running = true;
            object _lock = new object();
            Thread t1 = new Thread(() =>
            {
                while(running)
                {
                    lock(_lock)
                    {
                        count++;
                    }
                    Thread.Sleep(100);
                }
            });

            Thread t2 = new Thread(() =>
            {
                while(running)
                {
                    lock (_lock)
                    {
                        count++;
                    }
                    Thread.Sleep(100);
                }
            });


            Thread t3 = new Thread(() =>
            {
                while(running)
                {
                    Console.WriteLine(count);
                    Thread.Sleep(100);
                }
            });

            t1.Start();
            t2.Start();
            Thread.Sleep(10); //Delayed start
            t3.Start();

            var input = Console.ReadLine();
            if (input == "1")
            {
                running = false;
            }

        }
    }
}

