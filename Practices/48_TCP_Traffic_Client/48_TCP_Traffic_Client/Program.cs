using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _48_TCP_Traffic_Client
{
    class Program
    {
        private static bool _cancellationToken = true;
        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
            Console.WriteLine("Hello World");
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1500);
            TcpClient client = new TcpClient();

            Console.WriteLine("Trying to connect..");

            client.Connect(ep);
            NetworkStream ns = client.GetStream();
            string message = new string('X', 1024 * 1024); // 1MB 
            client.SendBufferSize = 1024 * 1024 * 10;  //10MB
            client.Client.Blocking = false;
            var counter = 0;
            while (_cancellationToken)
            {
                counter++;
                var send = Encoding.ASCII.GetBytes(message);
                ns.Write(send, 0, send.Length);
                Console.WriteLine($"Send message {counter} : {message[0]}");
                Thread.Sleep(100);
            }

            var lastMessage = Console.ReadLine();
            var lastSend = Encoding.ASCII.GetBytes(lastMessage);
            ns.Write(lastSend, 0, lastSend.Length);
            Console.WriteLine($"Disconnecting..");

            ns.Close();
            client.Close();
        }

        static void OnExit(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("\nCtrl+C detected!");
            _cancellationToken = false;
            e.Cancel = true;
        }
    }
}
