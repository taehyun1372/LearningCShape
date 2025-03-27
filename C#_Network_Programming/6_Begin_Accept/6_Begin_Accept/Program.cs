using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _6_Begin_Accept
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1205);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(ep);
            serverSocket.Listen(5);
            serverSocket.BeginAccept(new AsyncCallback(Connected), serverSocket);

            Console.WriteLine("Hello World");

            while(true)
            {
                Console.WriteLine("Main Process is In Process");
                Thread.Sleep(2000);
            }
            Console.ReadLine();

        }
        public static void Connected(IAsyncResult iar)
        {
            Socket sock = (Socket)iar.AsyncState;
            try
            {
                Socket clientSocket = sock.EndAccept(iar);
                Console.WriteLine("Connection Successful");

                while(true)
                {
                    Console.WriteLine("Client Handling is in Process");

                    byte[] data = new byte[100];
                    clientSocket.Receive(data);
                    var message = Encoding.ASCII.GetString(data);
                    if (message != "")
                    {
                        Console.WriteLine(message);
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (SocketException)
            {
                Console.WriteLine("Unable to connect to host");
            }
        }

    }


}
