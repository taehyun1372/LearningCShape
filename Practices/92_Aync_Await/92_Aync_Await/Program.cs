using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _92_Aync_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialiseTasks();

            while (true)
            {
                Console.WriteLine("Main thread keeps doing its job");
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }

        static async Task InitialiseTasks()
        {
            await DoCPUBoundWorkAsync1();
            Console.WriteLine("Contines after DoCPUBoundWorkAsync1.");

            DoCPUBoundWorkAsync2();
            Console.WriteLine("Contines after DoCPUBoundWorkAsync2.");
        }

        static void DoCPUBoundWorkAsync2()
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    for (int j = 0; j < 100000; j++)
                    {
                        var value = i * j;
                    }
                }
                Console.WriteLine("DoCPUBoundWorkAsync2 returns.");
            });
        }

        static async Task DoCPUBoundWorkAsync1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    for (int j = 0; j < 100000; j++)
                    {
                        var value = i * j;
                    }
                }
            });

            Console.WriteLine("DoCPUBoundWorkAsync1 returns.");
        }
    }
}
