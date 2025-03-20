using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Net;
using System.Net.Sockets;

namespace _4_Blocking_Non_Blocking
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("A socket is being created..");
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("192.168.75.1");
            IPEndPoint ep = new IPEndPoint(ip, 8000);

            try
            {
                socket.Bind(ep);
                socket.Listen(5);

                Socket client = socket.Accept();
                Console.WriteLine("Connection has been successful");

                Thread th = new Thread(() => NonBlockingReceive(client));
                th.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main function call..{0}", i);
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }

        static void BlockingReceive(Socket cilent)
        {
            Console.WriteLine("In BlockingReceive..");

            cilent.Blocking = true;

            int i = 0;
            while(true)
            {
                i++;
                byte[] data = new byte[100];
                cilent.Receive(data);
                var message = Encoding.ASCII.GetString(data);
                Console.WriteLine("Data {0} has been received..{1}", message, i);
                Thread.Sleep(1000);
            }
        }

        static void NonBlockingReceive(Socket cilent)
        {
            Console.WriteLine("In Non-BlockingReceive..");

            cilent.Blocking = false;

            int i = 0;
            while (true)
            {
                i++;
                byte[] data = new byte[100];
                try
                {
                    cilent.Receive(data);
                    var message = Encoding.ASCII.GetString(data);
                    Console.WriteLine("Data {0} has been received..{1}", message, i);
                }
                catch
                {
                    Console.WriteLine("Data is not available..{0}", i);
                }
                

                Thread.Sleep(1000);
            }
        }
    }
}
