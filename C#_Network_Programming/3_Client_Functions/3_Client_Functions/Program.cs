using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _3_Client_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress host = IPAddress.Parse("192.168.75.1");
            IPEndPoint hostep = new IPEndPoint(host, 8000);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Connection started..to the host, {0}", hostep.ToString());
            sock.Connect(hostep);
            Console.WriteLine("Connection finished..to the host, {0}", hostep.ToString());
            var message = "This is first message";
            byte[] data = Encoding.ASCII.GetBytes(message);
            Console.WriteLine("Sending data..");
            foreach (var i in  data)
            {
                Console.WriteLine(i);
            }
            sock.Send(data);
            Console.WriteLine("Successfully sent data");
            Thread.Sleep(100000);

            Console.WriteLine("Shutting down the socket..");
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();
            Console.WriteLine("The socket has been safely closed..");

            Console.ReadLine();
        }
    }
}
