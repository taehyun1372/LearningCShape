using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace _1_IP_Addresses
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPAddress samples..
            IPAddress test1 = IPAddress.Parse("192.168.1.1");
            IPAddress test2 = IPAddress.Loopback;
            IPAddress test3 = IPAddress.Broadcast;
            IPAddress test4 = IPAddress.Any;
            IPAddress test5 = IPAddress.None;
            var hostName = Dns.GetHostName();
            IPHostEntry ihe = Dns.GetHostEntry(hostName);

            IPAddress myself = ihe.AddressList[0];


            if (IPAddress.IsLoopback(test2))
                Console.WriteLine("The Loopback address is: {0}",
                test2.ToString());
            else
                Console.WriteLine("Error obtaining the loopback address");

            Console.WriteLine("The Local IP address is: {0}\n",
            myself.ToString());
            if (myself == test2)
                Console.WriteLine("The loopback address is the same as local address.\n");
            else
                Console.WriteLine("The loopback address is not the local address.\n");

            Console.WriteLine("The test address is: {0}", test1.ToString());
            Console.WriteLine("Broadcast address: {0}", test3.ToString());
            Console.WriteLine("The ANY address is: {0}", test4.ToString());
            Console.WriteLine("The NONE address is: {0}", test5.ToString());

            //IPEndPorint samples..
            IPEndPoint ie = new IPEndPoint(test1, 8000);
            Console.WriteLine("The IPEndPoint is : {0}", ie.ToString());
            Console.WriteLine("The AddressFamily is {0}", ie.AddressFamily);
            Console.WriteLine("The address is {0}", ie.Address);
            Console.WriteLine("The port is {0}", ie.Port);
            Console.WriteLine("The maximum port is {0}", IPEndPoint.MaxPort);
            Console.WriteLine("The minimum port is {0}", IPEndPoint.MinPort);
            ie.Port = 80;
            Console.WriteLine("The changed IPEndPoint value is {0}", ie.ToString());
            SocketAddress sa = ie.Serialize();
            Console.WriteLine("The SocketAddress is {0}", sa.ToString());

            //Socket samples..
            IPAddress ia = IPAddress.Parse("127.0.0.1");
            IPEndPoint ie2 = new IPEndPoint(ia, 8000);
            Socket testSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("AddressFamily {0}", testSocket.AddressFamily);
            Console.WriteLine("Socket Type {0}", testSocket.SocketType);
            Console.WriteLine("Protocol Type {0}", testSocket.ProtocolType);
            Console.WriteLine("Blocking {0}", testSocket.Blocking);
            testSocket.Blocking = false;
            Console.WriteLine("New Blocking {0}", testSocket.Blocking);
            Console.WriteLine("Connected {0}", testSocket.Connected);
            Console.WriteLine("Local End Point Before Binding {0}", testSocket.LocalEndPoint);
            testSocket.Bind(ie2);
            Console.WriteLine("Local End Point After Binding {0}", testSocket.LocalEndPoint);
            testSocket.Close();




            Console.ReadLine();
        }
    }
}
