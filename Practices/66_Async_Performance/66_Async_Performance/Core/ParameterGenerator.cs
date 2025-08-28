using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace _66_Async_Performance.Core
{
    public class ParameterGenerator
    {
        private Dictionary<int, Parameter> _parameters;
        private Thread _th;
        public static Random _rand = new Random();
        public object _lock = new object();
        public event Action<object, Parameter> parameterChanged;
        public event Action<object, int> parameterBulkChanged;

        public BlockingCollection<Parameter> ParameterQueue { get; set; } = new BlockingCollection<Parameter>();

        private int _min = 0;
        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        private int _max = 10000;
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        private int _interval;
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        public ParameterGenerator(int num, int interval = 1000)
        {
            _parameters = new Dictionary<int, Parameter>();
            Interval = interval;
            for (int i = 0; i < num; i++)
            {
                _parameters.Add(i, new Parameter() {
                    Id = i, 
                    Description = $"Parameter {i}"
                });
            }
            Start();
        }

        public void Start()
        {
            _th = new Thread(Process);
            _th.Start();
        }

        public void Stop()
        {
            if (_th != null)
            {
                _th.Abort();
            }
        }

        public void Process()
        {
            while(true)
            {
                foreach(KeyValuePair<int, Parameter> kev in _parameters)
                {
                    var result = kev.Value;
                    {
                        result.Id = result.Id;
                        result.Description = result.Description;
                        result.Value = GetRandomVaue();
                    };

                    parameterChanged?.Invoke(this, result);
                    ParameterQueue.TryAdd(result);
                    //Console.WriteLine($"Parameter Id : {result.Id}, Parameter Value : {result.Value}");
                }
                parameterBulkChanged?.Invoke(this, ParameterQueue.Count);
                Thread.Sleep(Interval);
            }
        }

        public double GetRandomVaue()
        {
            lock(_lock)
            {
                return Min + _rand.NextDouble() * (Max - Min);
            }
        }
    }


}
