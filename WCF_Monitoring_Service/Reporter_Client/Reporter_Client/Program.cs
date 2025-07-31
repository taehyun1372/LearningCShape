using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Reporter_Client.Interfaces;

namespace Reporter_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var factory = new ChannelFactory<IReporterServer>("NetTcpBinding_IReporterServer");
            var proxy = factory.CreateChannel();

            while(true)
            {
                var input = Console.ReadLine();
                if (input == "1")
                {
                    proxy.Parameterchanged("Dummy Data");
                }
                else if (input == "2")
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
