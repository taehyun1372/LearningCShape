using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using NModbus;

namespace _7_Modbus_Cache
{
    
    class Program
    {
        public static ConcurrentQueue<Action> queryQueue = new ConcurrentQueue<Action>();
        public static TcpClient client;
        public static ModbusFactory factory;
        public static IModbusMaster master;

        public static ushort[] registers;
        private static object _lock = new object();

        private static CancellationTokenSource _pollingCTS = new CancellationTokenSource();
        private static CancellationTokenSource _eventCTS = new CancellationTokenSource();
        private static CancellationTokenSource _commsCTS = new CancellationTokenSource();
        private static CancellationTokenSource _displayCTS = new CancellationTokenSource();

        private static bool _isConnected = false;


        private static Task communicationProcess = null;
        private static Task pollingProcess = null;
        private static Task eventHandlingProcess = null;
        private static Task displayingProcess = null;


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Process();
            Console.ReadLine();
        }

        static async Task Process()
        {
            while (true)
            {
                if((pollingProcess == null || pollingProcess.IsCompleted == true) && (communicationProcess == null || communicationProcess.IsCompleted == false))
                {
                    pollingProcess = Task.Run(async() =>
                    {
                        try
                        {
                            Console.WriteLine("Polling process starting..");
                            _pollingCTS = new CancellationTokenSource();
                            await PollingProcess(_pollingCTS.Token);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Polling process failed..");
                            Console.WriteLine(e.Message);
                        }
                    });
                }


                if((eventHandlingProcess == null || eventHandlingProcess.IsCompleted == true) && (communicationProcess == null || communicationProcess.IsCompleted == false))
                {
                    eventHandlingProcess = Task.Run(async () =>
                    {
                        try
                        {
                            Console.WriteLine("Event process starting..");
                            _eventCTS = new CancellationTokenSource();
                            await EventHandlingProcess(_eventCTS.Token);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Event handling process failed..");
                            Console.WriteLine(e.Message);
                        }
                    });
                }

                if ((communicationProcess == null || communicationProcess.IsCompleted) && _isConnected)
                {
                    communicationProcess = Task.Run(async () =>
                    {
                        try
                        {
                            Console.WriteLine("Communication process starting..");
                            _commsCTS = new CancellationTokenSource();
                            await CommunicationProcess(_commsCTS.Token);
                        }
                        catch (Exception e)
                        {
                            _pollingCTS.Cancel();
                            _eventCTS.Cancel();
                            Console.WriteLine("Communicaiton process failed..");
                            Console.WriteLine(e.Message);
                        }
                    });
                }

                if(displayingProcess == null || displayingProcess.IsCompleted == true)
                {
                    
                    displayingProcess = Task.Run(async () =>
                    {
                        try
                        {
                            Console.WriteLine("Display process starting..");
                            _displayCTS = new CancellationTokenSource();
                            await DisplayingProcess(_displayCTS.Token);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Display process failed..");
                            Console.WriteLine(e.Message);
                        }
                    });
                }

                if(!_isConnected)
                {
                    await InitialiseCommunication();
                }
                await Task.Delay(2000); //Interval for initiate a new process..
            }
        }

        static async Task InitialiseCommunication() //Independant process
        {
            try
            {
                await Task.Run(() =>
                {
                    client = new TcpClient("192.168.2.20", 502);
                    factory = new ModbusFactory();
                    master = factory.CreateMaster(client);
                    _isConnected = true;
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to connect..");
                Console.WriteLine();
                _isConnected = false;
            }

        }

        static async Task DisplayingProcess(CancellationToken token) //Independant process
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();

                await Task.Delay(1000);

                if (registers != null)
                {
                    lock(_lock)
                    {
                        Console.WriteLine($"Displaying holding registers..");
                        foreach (var res in registers) Console.Write($"{res},");
                        Console.WriteLine();
                    }
                }
            }
        }

        static async Task PollingProcess(CancellationToken token) //Depends on communicating status
        {
            int count = 0;
            while(true)
            {
                token.ThrowIfCancellationRequested();

                await Task.Delay(1000);
                queryQueue.Enqueue(() => 
                {
                    lock(_lock)
                    {
                        registers = master.ReadHoldingRegisters(1, 0, 10);
                    }
                    Console.WriteLine($"Readling holding registers..{count}");
                });
                count++;
            }
        }

        static async Task EventHandlingProcess(CancellationToken token) //Depends on communicating status
        {
            int count = 0;
            while (true)
            {
                token.ThrowIfCancellationRequested();

                await Task.Delay(3000);
                queryQueue.Enqueue(() =>
                {
                    master.WriteMultipleRegisters(1, 0, new ushort[] { 1, 2, 3});
                    Console.WriteLine($"Writing holding registers..{count}");
                });
                count++;
            }
        }

        static async Task CommunicationProcess(CancellationToken token) //Independant connected status
        {
            int count = 0;
            while(true)
            {
                token.ThrowIfCancellationRequested();

                await Task.Delay(300);

                if (queryQueue.TryDequeue(out var result))
                {
                    result();
                }

            }
        }
    }
}
