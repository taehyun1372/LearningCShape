using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NModbus;
using System.Net.Sockets;

namespace _97_Connection_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var motor = new MotorController("192.168.2.10", 502);

            var valve = new ValveController("192.168.2.20", 502);

            while(true)
            {
                var input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine(motor.Temp2);
                }
                else if (input == "2")
                {
                    Console.WriteLine(valve.Pressure3);
                }
            }
            Console.ReadLine();
        }
    }

    public enum ConnectionStatus
    {
        idle, 
        connecting,
        connected,
        closing
    }

    public class ValveController : ConnectionManager
    {
        public ValveController(string ipAddress, int port) : base(ipAddress, port)
        {

        }

        public ushort Pressure1
        {
            get
            {
                lock (_lock)
                {
                    return _data[10];
                }
            }
        }

        public ushort Pressure2
        {
            get
            {
                lock (_lock)
                {
                    return _data[11];
                }
            }
        }

        public ushort Pressure3
        {
            get
            {
                lock (_lock)
                {
                    return _data[12];
                }
            }
        }
    }

    public class MotorController : ConnectionManager
    {
        public MotorController(string ipAddress, int port) : base(ipAddress, port)
        {

        }

        public ushort Temp1
        {
            get
            {
                lock(_lock)
                {
                    return _data[0];
                }
            }
        }

        public ushort Temp2
        {
            get
            {
                lock (_lock)
                {
                    return _data[1];
                }
            }
        }

        public ushort Temp3
        {
            get
            {
                lock (_lock)
                {
                    return _data[2];
                }
            }
        }
    }

    public abstract class ConnectionManager
    {
        private string _ipAddress;
        private int _port;
        protected ushort[] _data;
        private ConnectionStatus _status = ConnectionStatus.idle;
        private TcpClient _tcpClient;
        private IModbusMaster _master;
        protected object _lock = new object();
        private const int TICK_TIME = 1000;

        public ConnectionStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public ConnectionManager(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;

            ConnectionProcess();
        }

        public async void ConnectionProcess()
        {
            while (true)
            {
                switch (Status)
                {
                    case ConnectionStatus.idle:
                        Console.WriteLine("idle..");
                        await Task.Delay(5000);
                        Status = ConnectionStatus.connecting;
                        break;

                    case ConnectionStatus.connecting:
                        Console.WriteLine("connecting");
                        try
                        {
                            _tcpClient = new TcpClient(_ipAddress, _port);
                            var factory = new ModbusFactory();
                            _master = factory.CreateMaster(_tcpClient);
                            Console.WriteLine("connected!");
                            Status = ConnectionStatus.connected;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to connect..");
                            Console.WriteLine(ex.Message);
                            Status = ConnectionStatus.idle;
                        }
                        break;

                    case ConnectionStatus.connected:
                        try
                        {
                            lock(_lock)
                            {
                                _data = _master.ReadHoldingRegisters(slaveAddress: 1, startAddress: 0, numberOfPoints: 100);
                            }
                            foreach(var i in _data)
                            {
                                Console.Write(i);
                            }
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to communicate..");
                            Console.WriteLine(ex.Message);
                            Status = ConnectionStatus.closing;
                        }
                        break;

                    case ConnectionStatus.closing:
                        Console.WriteLine("closing..");
                        Status = ConnectionStatus.idle;
                        _master?.Dispose();
                        _tcpClient?.Close();
                        _tcpClient?.Dispose();
                        break;
                }
                await Task.Delay(TICK_TIME);
            }
        }
    }


    //Display

    //Logging

    //Re-connection

    //Validation

    //Dispose


}
