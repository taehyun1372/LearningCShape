using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace _9_Beign_Send
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1501);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.BeginConnect(ep, new AsyncCallback(Connected), socket);

            while(true)
            {
                Thread.Sleep(1000);
            }    
        }

        static void Connected(IAsyncResult iar)
        {
            try
            {
                Socket socket = (Socket)iar.AsyncState;
                socket.EndConnect(iar);
                Console.WriteLine("A Connection made");
                while(true)
                {
                    Console.WriteLine("Enter a message to send");
                    var message = Console.ReadLine();
                    if (message == "1")
                    {
                        var path = @"C:\Users\a00533064\OneDrive - ONEVIRTUALOFFICE\Pictures\Screenpresso\2.Start-up.mp4";
                        byte[] fileData = File.ReadAllBytes(path);

                        Stopwatch sw = Stopwatch.StartNew();
                        socket.Send(fileData);
                        sw.Stop();
                        Console.WriteLine($"Sent data..within {sw.ElapsedMilliseconds} mili seconds..");
                    }
                    else
                    {
                        var data = new byte[100];
                        data = Encoding.ASCII.GetBytes(message);

                        Stopwatch sw = Stopwatch.StartNew();
                        socket.Send(data);
                        sw.Stop();
                        Console.WriteLine($"Sent data..within {sw.ElapsedMilliseconds} mili seconds..");
                    }
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("A Connection failed");
            }
        }
    }
}
