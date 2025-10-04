using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ServiceModel;
using Server.Interfaces;
using Server.Database;

namespace Server.Core
{
    public class MainServer
    {
        public static int count;
        private Thread _mainThread;
        private ServiceHost _reportService;
        private ParameterReport _report;

        private ServiceHost _monitorService;
        private ParameterMonitor _monitor;

        private DataLogger _logger;
        private DataReader _reader;

        public MainServer()
        {
            _report = new ParameterReport();
            _logger = new DataLogger();
            _report.ParameterChanged += _logger.LogParameterIntoDatabase;

            _reportService = new ServiceHost(_report);
            _reportService.Open();

            _reader = new DataReader();
            _monitor = new ParameterMonitor(_reader);

            _monitorService = new ServiceHost(_monitor);
            _monitorService.Open();
        }

        private void OnReporterServerParameterChanged(object arg1, ParameterData arg2)
        {
            throw new NotImplementedException();
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
            while (true)
            {
                Console.WriteLine("Main process is running");
                Thread.Sleep(1000);
            }
        }
    }
}
