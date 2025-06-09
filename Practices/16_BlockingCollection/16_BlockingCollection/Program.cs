using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace _16_BlockingCollection
{
    class Program
    {
        public static List<Action<int>> _taskQueue = new List<Action<int>>();
        public static object _lock = new object();
        static void Main(string[] args)
        {
            Thread th1 = new Thread(() => ConsumerMain(1));
            Thread th2 = new Thread(() => ConsumerMain(2));
            Thread th3 = new Thread(() => ConsumerMain(3));

            th1.Start();
            th2.Start();
            th3.Start();

            while (true) //Producers
            {
                var input = Console.ReadLine();
                if (input == "1")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        _taskQueue.Add((s) => {
                            Process1(s);
                        });
                    }
                }
                else if (input == "2")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        _taskQueue.Add((s) => {
                            Process2(s);
                        });
                    }
                }
                else if (input == "3")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        _taskQueue.Add((s) => {
                            Process3(s);
                        });
                    }
                }
            }
        }

        public static void ConsumerMain(int id)
        {
            Console.WriteLine($"{id} consumer process started");
            while(true)
            {
                lock(_lock)
                {
                    if (_taskQueue.Count > 0)
                    {
                        var index = _taskQueue.Count - 1;
                        Action<int> task = _taskQueue[index]; //get the last element 
                        task(id); //execute the task
                        _taskQueue.RemoveAt(index); //remove the task 
                    }
                    Thread.Sleep(500); //Artifitial Pause time 
                }
            }
        }

        public static void Process1(int id)
        {
            Console.WriteLine($"In Process 1 : start by thread {id}");
            Thread.Sleep(1000);
            Console.WriteLine($"In Process 1 : finish by thread {id}, remaining tasks: {_taskQueue.Count()}");
        }

        public static void Process2(int id)
        {
            Console.WriteLine($"In Process 2 : start by thread {id}");
            Thread.Sleep(2000);
            Console.WriteLine($"In Process 2 : finish by thread {id}, remaining tasks: {_taskQueue.Count()}");
        }

        public static void Process3(int id)
        {
            Console.WriteLine($"In Process 3 : start by thread {id}");
            Thread.Sleep(3000);
            Console.WriteLine($"In Process 3 : finish by thread {id}, remaining tasks: {_taskQueue.Count()}");
        }

    }
}
