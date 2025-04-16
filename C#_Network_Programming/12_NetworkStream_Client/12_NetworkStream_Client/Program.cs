using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace _12_NetworkStream_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1500);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ep);

            Console.WriteLine("A connection detected");
            NetworkStream ns = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(ns);
            writer.AutoFlush = true;
            byte[] data = new byte[1024];
            while(true)
            {
                if(ns.CanWrite)
                {
                    Console.WriteLine("Enter a message to send..");
                    var message = Console.ReadLine();
                    data = Encoding.ASCII.GetBytes(message);
                    writer.WriteLine(message);
                    //writer.Flush();
                    //ns.Write(data);
                }
            }
        }
    }
}
