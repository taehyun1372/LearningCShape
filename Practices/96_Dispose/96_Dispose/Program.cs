using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace _96_Dispose
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 9000;
            int count = 0;
            while(true)
            {
                try
                {
                    var input = Console.ReadLine();
                    Console.WriteLine("Please enter your command..");
                    if (input == "1")
                    {
                        CreateServer();
                    }
                    if (input == "2")
                    {
                        GC.Collect();
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine($"Fialed at count {count}");
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }

        public static void CreateServer()
        {
            var server = new CustomServer();
            server.Start();
        }
    }

    public class CustomServer : IDisposable
    {
        public TcpListener Listener { get; set; }
        public CustomServer()
        {
            Listener = new TcpListener(IPAddress.Any, 502);
            Console.WriteLine("A server is being instanciated..");
        }

        public void Start()
        {
            if (Listener != null)
            {
                Listener.Start();
            }
        }

        public void Dispose()
        {
            if (Listener != null)
            {
                Listener.Stop();
            }
        }
    }
}
