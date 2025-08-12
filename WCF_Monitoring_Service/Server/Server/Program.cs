using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Server.Interfaces;
using Topshelf;
using Server.Core;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            HostFactory.Run(x =>
            {
                x.Service<ServerService>(s =>
                {
                    s.ConstructUsing(name => new ServerService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());


                    x.RunAsLocalSystem();
                    x.SetServiceName("Server_Service");
                    x.SetDisplayName("Server Service");
                    x.SetDescription("This is a service to log and provide sensor values");
                });

            });


            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
