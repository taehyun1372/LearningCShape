using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Reporter_Client.Core;

namespace Reporter_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            HostFactory.Run(x =>
            {
                x.Service<ParameterReportClient>(s =>
                {
                    s.ConstructUsing(name => new ParameterReportClient());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());


                    x.RunAsLocalSystem();
                    x.SetServiceName("Report_Service");
                    x.SetDisplayName("Report Service");
                    x.SetDescription("This is a service to report sensor values");
                });
                
            });

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
