using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Server.Interfaces;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var service = new ServiceHost(typeof(ReporterServer));
            service.Open();
            Console.WriteLine("Server is now hosting..");


            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
