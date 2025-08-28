using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _65_Task_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var cts = new System.Threading.CancellationTokenSource();

            Task<int> t1 = RunAsync(cts, "t1", 30);
            Task<int> t2 = RunAsync(cts, "t2", 50);


            t1.ContinueWith(t =>
            {
                TaskFinishedHandler(t);
            });

            t2.ContinueWith(t =>
            {
                TaskFinishedHandler(t);
            });
            

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main is running..");
                var input = Console.ReadLine();
                if (input == "exit")
                {
                    cts.Cancel();
                }
                Thread.Sleep(1000);
            }

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }

        static async Task<int> RunAsync(CancellationTokenSource cts, string name, int count)
        {
            Console.WriteLine($"{name} work start");
            var cnt = 0;
            for (int i = 0; i < count; i++)
            {
                cnt++;
                if (cts.Token.IsCancellationRequested)
                {
                    break;
                }
                Console.WriteLine($"{name} work process");
                await Task.Delay(1000); // does NOT block main thread
            }
            Console.WriteLine($"{name} work finished");

            return cnt;
        }

        static void TaskFinishedHandler(Task<int> t)
        {
            Console.WriteLine($"Task {t.Id} finished, result = {t.Result}");
        }

    }
}
