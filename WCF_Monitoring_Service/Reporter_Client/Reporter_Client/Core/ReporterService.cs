using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ServiceModel;
using Reporter_Client.Interfaces;
using Reporter_Client.Sensors;

namespace Reporter_Client.Core
{
    public class ReporterService
    {
        public static int count;
        private Thread _mainThread;
        private ChannelFactory<IReporterServer> _factory;
        private IReporterServer _proxy;
        private SensorSimulator _simulator;

        public ReporterService()
        {
            _factory = new ChannelFactory<IReporterServer>("NetTcpBinding_IReporterServer");
            _proxy = _factory.CreateChannel();
            _simulator = new SensorSimulator(10);
            _simulator.SensorValueChanged += OnSensorValueChanged;
        }

        private void OnSensorValueChanged(object sender, ValueChangedArg e)
        {
            var paramData = new ParameterData() { 
                Id = e.Id,
                Value = e.Value
            };

            _proxy.NotifyParameter(paramData);
        }

        public bool Start()
        {
            _mainThread = new Thread(MainProcess);
            _mainThread.Start();
            Console.WriteLine("The service started");
            return true;
        }

        public bool Stop()
        {
            _mainThread.Join();
            Console.WriteLine("The service stopped");
            return true;
        }

        public void MainProcess()
        {
            while(true)
            {
                Console.WriteLine("Main process is running");
                Thread.Sleep(1000);
            }
        }
    }
}
