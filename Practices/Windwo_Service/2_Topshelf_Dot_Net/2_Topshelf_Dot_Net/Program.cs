using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using System.Threading;
using Modbus.Device;
using System.Net;
using System.Net.Sockets;

namespace _2_Topshelf_Dot_Net
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<MyService>(s =>
                {
                    s.ConstructUsing(name => new MyService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("MyService");
                x.SetDisplayName("My Sample Service");
                x.SetDescription("This is a Topshelf-powered service");
            });
        }
    }

    public class MyService
    {
        public static int count;
        private ModbusSlave Slave { get; set; }
        private Thread _workThread;

        public bool Start()
        {
            _workThread = new Thread(ProcessLogic);
            _workThread.Start();
            Console.WriteLine("Service started");
            return true;
        }

        public void ProcessLogic()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.3.78"), 503);
            TcpListener listener = new TcpListener(ep);
            listener.Start();

            ModbusSlave slave = ModbusTcpSlave.CreateTcp(1, listener);
            slave.DataStore = Modbus.Data.DataStoreFactory.CreateDefaultDataStore();
            Slave = slave;
            slave.Listen();

            while(true)
            {
                count += 1;
                var result = LogModbusSlaveDataStore();
                Console.Write($"In process : {result}");
                Thread.Sleep(1000);
            }
        }

        private string LogModbusSlaveDataStore()
        {
            string log = "";
            log = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

            log = string.Join(" ", log, Slave.DataStore.HoldingRegisters[0].ToString());
            for (int i = 1; i < 10; i++)
            {
                log = string.Join("-", log, Slave.DataStore.HoldingRegisters[i]);
            }
            log += "\n";
            System.IO.File.AppendAllText("C:\\Temp\\Logs.txt", log);
            return log;
        }

        public bool Stop()
        {
            _workThread.Join();
            Console.WriteLine("Service stopped");
            return true;
        }
    }
}
