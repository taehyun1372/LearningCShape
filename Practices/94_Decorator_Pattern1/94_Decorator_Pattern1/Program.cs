using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NModbus;
using System.Net.Sockets;

namespace _94_Decorator_Pattern1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var master = new Logger(new Logger(new PacketSender("192.168.2.10", 502, 1, 5, 10)));

            try
            {
                master.Write(); //Main Process 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //We are okay with this function failure, we can keep going with other functions. 
            }

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }

    public interface IModbusClient
    {
        ushort[] Write();
        void Enable();
        void Disable();
        string GetDiscription();
        int GetPriority();
    }

    public abstract class ModbusClient : IModbusClient
    {
        public bool Enabled { get; set; }
        public string Description { get; set; }
        public void Disable()
        {
            Enabled = false;
        }

        public void Enable()
        {
            Enabled = true;
        }

        public string GetDiscription()
        {
            return Description;
        }

        public int GetPriority()
        {
            return -1;
        }

        public abstract ushort[] Write();
    }

    public abstract class ModbusDecorator : IModbusClient
    {
        public bool Enabled { get; set; }
        public string Description { get; set; }
        private IModbusClient _client;

        public ModbusDecorator(IModbusClient client)
        {
            _client = client;
        }

        public void Disable()
        {
            Enabled = false;
        }

        public void Enable()
        {
            Enabled = true;
        }

        public string GetDiscription()
        {
            return Description;
        }

        public int GetPriority()
        {
            return -1;
        }

        public virtual ushort[] Write()
        {
            if (_client != null)
            {
                var result = _client.Write();
                return result;
            }
            throw new ArgumentNullException();
        }
    }

    public class Logger : ModbusDecorator
    {
        public Logger(IModbusClient client) : base(client)
        {
        }

        public override ushort[] Write()
        {
            var result = base.Write();
            Console.WriteLine($"Data is being logged..");
            foreach (var i in result) Console.Write($"{i} ");
            Console.WriteLine("");
            return result;
        }
    }

    public class PacketSender : ModbusClient
    {
        private IModbusMaster _master;
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public byte SlaveId { get; set; }
        public byte StartAddress { get; set; }
        public byte NumRegisters { get; set; }

        public PacketSender(string ipAddress, int port, byte slaveId, byte startAddress, byte numRegisters)
        {
            IPAddress = ipAddress;
            Port = port;
            SlaveId = slaveId;
            StartAddress = startAddress;
            NumRegisters = numRegisters;
        }

        public override ushort[] Write()
        {
            if (_master == null)
            {
                if (IPAddress != "" && Port != 0)
                {
                    var tcpClient = new TcpClient(IPAddress, Port);
                    var factory = new ModbusFactory();
                    _master = factory.CreateMaster(tcpClient);
                }
                else
                {
                    throw new ArgumentException();
                }

            }
            try
            {
                ushort[] registers = _master.ReadHoldingRegisters(SlaveId, StartAddress, NumRegisters);
                return registers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error happened during sending packets..")
            }
            
        }
    }
}
