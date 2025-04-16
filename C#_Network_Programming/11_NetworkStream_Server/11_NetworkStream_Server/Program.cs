using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

namespace _11_NetworkStream_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1500);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ep);
            server.Listen(5);

            Socket client = server.Accept();
            Console.WriteLine("A connection detected");
            NetworkStream ns = new NetworkStream(client);
            StreamReader reader = new StreamReader(ns);
            byte[] data = new byte[1024];
            while(true)
            {

                //var recv = ns.Read(data, 0, data.Length);
                //var message = Encoding.ASCII.GetString(data, 0, recv);

                var message = reader.ReadLine();
                Console.WriteLine($"The message is {message}");
                Thread.Sleep(500);
            }
        }
    }
}
