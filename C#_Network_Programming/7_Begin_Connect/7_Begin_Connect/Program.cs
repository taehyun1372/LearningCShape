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
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1205);
            clientSocket.BeginConnect(ep, new AsyncCallback(Connected), clientSocket);
            while(true)
            {
                Thread.Sleep(2000);
                Console.WriteLine("In Main Process");
            }
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
                Console.WriteLine("Unable to connect to host");
            }
        }

    }
}
