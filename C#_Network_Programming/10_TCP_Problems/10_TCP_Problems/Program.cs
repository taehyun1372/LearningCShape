using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace _10_TCP_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1501);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ep);
            server.Listen(5);
            Socket clientConnection = server.Accept();
            Console.WriteLine("A connection made");
            while (true)
            {
                byte[] data = new byte[10];
                var recv = clientConnection.Receive(data);
                var stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine($"The received data  is {stringData}");
                Console.WriteLine($"The length of the message  is {stringData.Length}");
            }

        }
    }
}
