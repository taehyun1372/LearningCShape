using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace _70_Timer_Resource_Consumption
{
    class Program
    {
        private static System.Timers.Timer _timer;

        static void Main(string[] args)
        {
            _timer = new System.Timers.Timer(100);
            _timer.Elapsed += OnElapsed;
            _timer.AutoReset = true;
            _timer.Start();

            Console.ReadLine();

        }

        private static void OnElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] 작업 시작 - Thread {Environment.CurrentManagedThreadId}");
            var data = new byte[1024 * 1024];
            Thread.Sleep(5000);
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] 작업 완료 - Thread {Environment.CurrentManagedThreadId}");
        }
    }
}
