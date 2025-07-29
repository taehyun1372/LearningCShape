using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _47_TCP_Traffic_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1500);
            TcpListener server = new TcpListener(ep);
            server.Start();
            Console.WriteLine("A TCP Server Opened");
            TcpClient client = server.AcceptTcpClient();
            client.ReceiveBufferSize = 1024 * 1024 * 10; //10 MB
            NetworkStream ns = client.GetStream();
            var counter = 0;
            var data = new byte[1024 * 512];

            while (true)
            {
                Console.WriteLine("A Client Connection Made");
                counter++;
                var recv = ns.Read(data, 0, data.Length);
                var message = Encoding.ASCII.GetString(data, 0, recv);
                if (message.Contains("exit"))
                {
                    break;
                }
                Console.WriteLine($"Sent message {counter} : {message[0]}");
                Thread.Sleep(10000);
            }

            Console.WriteLine("Closing Network..");
            ns.Close();
            client.Close();
            server.Stop();
            Console.WriteLine("Goodbye World..");
            Console.ReadLine();
        }
    }
}
