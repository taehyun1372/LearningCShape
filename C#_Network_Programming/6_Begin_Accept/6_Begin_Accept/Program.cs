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
        static int clientIndex = 0;
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
                Thread.Sleep(2000);
            }
        }



        public static void Connected(IAsyncResult iar)
        {
            clientIndex++;
            Socket sock = (Socket)iar.AsyncState;
            Console.WriteLine("Connection detected, clinet index : {0}", clientIndex);

            Console.WriteLine("Server is waiting for a another connection");
            sock.BeginAccept(new AsyncCallback(Connected), sock);
            try
            {
                Socket clientSocket = sock.EndAccept(iar);
                Console.WriteLine("Connection Successful, clinet index : {0}", clientIndex);
                BusinessLogic(clientSocket, clientIndex);

            }
            catch (SocketException)
            {
                Console.WriteLine("Unable to connect to host, clinet index : {0}", clientIndex);
            }
        }

        public static void BusinessLogic(Socket clientSocket, int clientIndex)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Client Handling is in Process, clinet index : {0}", clientIndex);

                    byte[] data = new byte[100];
                    clientSocket.Receive(data);
                    var message = Encoding.ASCII.GetString(data);
                    if (message != "")
                    {
                        message += string.Format("client index : {0}", clientIndex);
                        clientSocket.Send(data);
                        Console.WriteLine(message);
                    }

                    Thread.Sleep(1000);
                }
            }
            catch (SocketException)
            {
                Console.WriteLine("The connection has been terminated, client index : {0}", clientIndex);
            }

        }

    }


}
