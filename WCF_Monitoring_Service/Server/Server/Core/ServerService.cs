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
    public class ServerService
    {
        public static int count;
        private Thread _mainThread;
        private ServiceHost _service;
        private ReporterServer _reporter;
        private DataLogger _logger;

        public ServerService()
        {
            _reporter = new ReporterServer();
            _logger = new DataLogger();

            _reporter.ParameterChanged += _logger.LogParameterIntoDatabase;


            _service = new ServiceHost(_reporter);
            _service.Open();
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
