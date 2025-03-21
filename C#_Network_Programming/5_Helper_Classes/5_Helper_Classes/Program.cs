using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _5_Helper_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(StartMirrorServer);
            th.Start();

            TcpClient client = new TcpClient("127.0.0.1", 8001);
            NetworkStream ns = client.GetStream();

            int i = 0;
            while (true)
            {
                i++;
                Console.WriteLine("Main function..{0}", 0);
                Console.WriteLine("Enter a message to send..");
                var message = Console.ReadLine();

                Console.WriteLine("Sending a message..{0}", message);
                byte[] data = new byte[100];
                data = Encoding.ASCII.GetBytes(message);

                ns.Write(data, 0, data.Length);

                ns.Read(data, 0, data.Length);
                Console.WriteLine("Read a message..{0}", Encoding.ASCII.GetString(data));
            }
        }

        static void StartMirrorServer()
        {
            try
            {
                Console.WriteLine("Starting a mirror server");
                TcpListener mirror = new TcpListener(IPAddress.Parse("127.0.0.1"), 8001);
                mirror.Start();
                TcpClient client = mirror.AcceptTcpClient();
                NetworkStream ns = client.GetStream();

                int i = 0;
                while(true)
                {
                    i++;
                    byte[] data = new byte[100];
                    ns.Read(data, 0, data.Length);

                    var message = Encoding.ASCII.GetString(data);
                    Console.WriteLine("A data packet arrived..{0}", message);

                    data = Encoding.ASCII.GetBytes(message);
                    ns.Write(data, 0, data.Length);
                    Console.WriteLine("The data has been mirroed to the client..{0}", i);
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
        }


    }
}
