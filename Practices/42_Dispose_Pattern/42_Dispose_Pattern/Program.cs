using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace _42_Dispose_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            //using (var p1 = new Processor(3, "Critial Task 1"))
            //{
            //    Console.WriteLine("Main process started");
            //    p1.ReadLine();
            //    p1.ReadLine();
            //    p1.ReadLine();
            //    p1.ReadLine();
            //    Thread.Sleep(10000); //Some long~ operation
            //}

            ReadTest();

            Console.WriteLine("Main process ended");
            Console.ReadLine();
        }

        static void ReadTest() //Even funtion termination doesn't always mean removing from GC
        {
            var p1 = new Processor(3, "Critial Task 1");
            p1.ReadLine();
            p1.ReadLine();
            p1.ReadLine();
            p1.ReadLine();
        }


    }

    class Processor : IDisposable
    {
        private bool _disposed = false;
        private StreamReader _reader;
        private Timer _timer; 
        public int Id { get; set; }
        public string Name { get; set; }
        public Processor(int id, string name)
        {
            Id = id;
            Name = name;
            _timer = new Timer(TimerTick, null, 0, 1000);
            _reader = new StreamReader("test.txt");

        }

        public void TimerTick(object state)
        {
            Console.WriteLine("Timer tick");
        }

        public void ReadLine()
        {
            if (_reader != null)
            {
                var line = _reader.ReadLine();
                Console.WriteLine(line);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (_disposed) return;
            _timer.Dispose(); //Withoiut this code, the timer keeps running. 
            _timer = null;
            _reader.Dispose();
            _reader = null;
            _disposed = true;

        }
    }
}
