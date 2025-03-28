using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _7_Begin_Connect
{
    class Program
    {
        static int manRetries = 10;
        static int retryCount = 0;
        static int retryDelay = 5000;
        static IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1205);

        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            TryConnect(ep, clientSocket);
            while (true)
            {
                Thread.Sleep(2000);
            }
        }

        static void TryConnect(IPEndPoint ep, Socket clientSocket)
        {
            if (manRetries != -1 && retryCount >= manRetries)
            {
                Console.WriteLine("Reached retry limit");
                return;
            }
            
            Console.WriteLine("Retrying.. retry count is {0}", retryCount);
            clientSocket.BeginConnect(ep, new AsyncCallback(Connected), clientSocket);
        }

        static void Connected(IAsyncResult iar)
        {
            Socket sock = (Socket)iar.AsyncState;
            try
            {
                sock.EndConnect(iar);
                Console.WriteLine("Connection has been made");
                while (true)
                {
                    Console.WriteLine("Enter a message");
                    var message = Console.ReadLine();
                    byte[] data = new byte[100];
                    data = Encoding.ASCII.GetBytes(message);
                    sock.Send(data);
                    Console.WriteLine("A data sent");
                }
            }
            catch (SocketException)
            {
                retryCount++;
                Console.WriteLine("Unable to connect to host");
                Timer retryTimer = new Timer(_ => TryConnect(ep, sock), null, retryDelay, Timeout.Infinite);
            }
        }

    }
}
