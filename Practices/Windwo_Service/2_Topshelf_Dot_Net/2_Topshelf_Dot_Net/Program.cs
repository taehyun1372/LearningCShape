using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace _2_Topshelf_Dot_Net
{
    class Program
    {
        static void Main(string[] args)
        {

            System.IO.File.AppendAllText("C:\\install_log.txt",
            $"Arguments: {string.Join(" ", args)} - {DateTime.Now}\n");

            HostFactory.Run(x =>
            {
                x.Service<MyService>(s =>
                {
                    s.ConstructUsing(name => new MyService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("MyService");
                x.SetDisplayName("My Sample Service");
                x.SetDescription("This is a Topshelf-powered service");
            });

        }
    }

    public class MyService
    {
        public bool Start()
        {
            Console.WriteLine("Service started");
            return true;
        }

        public bool Stop()
        {
            Console.WriteLine("Service stopped");
            return true;
        }
    }
}
