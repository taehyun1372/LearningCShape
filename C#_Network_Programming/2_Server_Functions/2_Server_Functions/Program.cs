using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace _2_Server_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("192.168.75.1"), 502);
            Socket newServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Start binding..");

            try
            {
                newServer.Bind(iep);
                Console.WriteLine("Socket has been bound successfully with the end point {0}", iep.ToString());

                newServer.Listen(5);
                Console.WriteLine("Start Listening..");

                Socket newClient = newServer.Accept();
                Console.WriteLine("a new client has been accepted");
            }
            catch
            {
                Console.WriteLine("Failed during nework connection");
            }

            Console.ReadLine();
        }
    }
}
