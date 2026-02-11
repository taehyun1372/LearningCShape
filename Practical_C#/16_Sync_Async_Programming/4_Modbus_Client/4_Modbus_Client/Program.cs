using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NModbus;
using System.Threading;

namespace _4_Modbus_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ModbusFactory();

            var tcpClient = new TcpClient("192.168.2.20", 502);
            var master = factory.CreateMaster(tcpClient);

            // Modbus TCP: UnitId is usually 1 (often ignored)
            byte unitId = 1;

            // Read 10 holding registers starting at address 0
            ushort startAddress = 0;
            ushort numRegisters = 10;

            SendRequests(master, unitId, startAddress, numRegisters);
            
            while(true)
            {
                Console.WriteLine("Main thread is running continuousl..");
                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }

        static async Task SendRequests(IModbusMaster master, byte unitId, ushort startAddress, ushort numRegisters)
        {
            ushort[] registers = null;
            for (int i =0; i < 100; i++)
            {
                registers = await master.ReadHoldingRegistersAsync(
                    unitId,
                    startAddress,
                    numRegisters
                );
            }

            for (int i = 0; i < registers.Length; i++)
            {
                Console.WriteLine($"HR[{startAddress + i}] = {registers[i]}");
            }
        }
    }
}
