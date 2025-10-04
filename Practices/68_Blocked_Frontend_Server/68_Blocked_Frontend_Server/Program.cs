using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _68_Blocked_Frontend_Server.Core;
using _68_Blocked_Frontend_Server.Interface;
using System.ServiceModel;

namespace _68_Blocked_Frontend_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            DBLogger logger = new DBLogger();

            ParameterInterface inter = new ParameterInterface();
            inter.ParameterLogRequested += logger.ParameterLog;

            ServiceHost host = new ServiceHost(inter);
            host.Open();

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
