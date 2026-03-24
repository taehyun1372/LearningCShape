using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;

namespace _13_Remote_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var proxy = new LoggingProxy("log.txt");
            var controlRoom1 = new Host("Control Room 1");
            var controlRoom2 = new Host("Control Room 2");
            controlRoom1.Proxy = proxy;
            controlRoom2.Proxy = proxy;

            controlRoom1.Log("Hight Temperature Alarm Raised");
            controlRoom2.Log("Low Pressure Alarm Raised..");


            Console.ReadLine();
        }
    }

    public interface ILoggingService
    {
        void LogData(int index, string message);
    }

    public class Host : ILoggingService
    {
        private LoggingProxy _proxy;
        private int _index = 0;
        public string HostName { get; set; }
        public LoggingProxy Proxy
        {
            get { return _proxy; }
            set
            {
                _proxy = value;
                _index = _proxy.RegisterHost(HostName);
            }
        }
        public Host(string hostname)
        {
            HostName = hostname;
        }

        public void Log(string message)
        {
            this.LogData(_index, message);
        }

        public void LogData(int index, string message)
        {
            Proxy?.LogData(index, message);
        }
    }

    public class LoggingParameter
    {
        public string Message { get; set; }
        public int Index { get; set; }

    }

    public class LoggingProxy : ILoggingService
    {
        private string _path = "";
        private int _index = 0;
        private Dictionary<int, string> _hosts = new Dictionary<int, string>();
        private BlockingCollection<LoggingParameter> _queue = new BlockingCollection<LoggingParameter>();
        
        public LoggingProxy(string path)
        {
            _path = path;
            StartLogging();
        }
        public void LogData(int index, string message)
        {
            _queue.Add(new LoggingParameter()
            {
                Index = index,
                Message = message
            });
        }

        public async void StartLogging()
        {
            Task.Run(() => WriteData());
        }

        public async void WriteData()
        {
            foreach (var parameter in _queue.GetConsumingEnumerable())
            {
                string hostname;
                if (IsRegistered(parameter.Index, out hostname))
                {
                    if (_path != "")
                    {
                        using (var writer = new StreamWriter(_path, append: true))
                        {
                            writer.WriteLine($"[{hostname}], [{DateTime.Now}] : {parameter.Message}]");
                        }
                    }
                }
            }
        }

        public bool IsRegistered(int index, out string name)
        {
            var result = _hosts.TryGetValue(index, out name);
            return result;
        }

        public int RegisterHost(string hostname)
        {
            _index++;
            _hosts.Add(_index, hostname);
            return _index;
        }

    }
}
