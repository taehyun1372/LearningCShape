using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace _67_Unity_Container
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            UnityContainer container = new UnityContainer();
            container.RegisterSingleton<Reporter>();
            container.RegisterSingleton<Server>();
            container.RegisterSingleton<Logger>();

            Reporter reporter = container.Resolve<Reporter>();
            reporter.Min = 0;
            reporter.Max = 100;
            reporter.Interval = 1;

            Server server = container.Resolve<Server>();
            Logger logger = container.Resolve<Logger>();
            logger.Interval = 1000;


            Console.WriteLine("Goodbye World!");
            Console.ReadLine();
        }
    }

    public class Reporter
    {
        private static Random _rand = new Random();
        private object _lock = new object();
        public int Max { get; set; }
        public int Min { get; set; }
        private int _interval;
        public int Interval 
        { 
            get
            {
                return _interval;
            }
            set
            {
                _interval = value;
                _timer.Interval = _interval;
            }
        }

        private System.Timers.Timer _timer = new System.Timers.Timer();
        public event Action<object, double> ParameterChanged;

        public  Reporter()
        {
            _timer.Elapsed += (s,e) => process();
            _timer.Start();
        }

        public void process()
        {
            lock (_lock)
            {
                ParameterChanged?.Invoke(this, Min + _rand.NextDouble() * (Max - Min));
            }
        }
    }

    public class Server
    {
        private Reporter _reporter;
        private System.Timers.Timer _timer = new System.Timers.Timer();
        public BlockingCollection<double> LogQueue { get; set; } = new BlockingCollection<double>();
        public Server(Reporter reporter)
        {
            _reporter = reporter;
            _timer.Interval = 1000;
            _timer.Elapsed += (s, e) =>Monitor();
            _timer.Start();
            _reporter.ParameterChanged += (s, e) => LogQueue.TryAdd(e);
        }

        public void Monitor()
        {
            Console.WriteLine("Server is monitoring..");
            Console.WriteLine($"Warning log counter exceeded limit {LogQueue.Count}");

        }
    }

    public class Logger
    {
        public System.Timers.Timer _timer = new System.Timers.Timer();
        private Server _server;
        private int _interval;
        public int Interval
        {
            get
            {
                return _interval;
            }
            set
            {
                _interval = value;
                _timer.Interval = _interval;
            }
        }

        public Logger(Server server)
        {
            _server = server;
            _timer.Elapsed += (s, e) => Process();
            _timer.Start();
        }

        public void Process()
        {
            double item;
            while(_server.LogQueue.TryTake(out item))
            {
                Console.WriteLine($"{item} logged");
            }
        }
    }
}

