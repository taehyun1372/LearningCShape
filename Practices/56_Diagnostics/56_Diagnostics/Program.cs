using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using log4net;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace _56_Diagnostics
{
    class Program
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Stopwatch stopwatch = Stopwatch.StartNew();

            LogError();

            stopwatch.Stop();

            Console.WriteLine($"Elapsed time : {stopwatch.ElapsedMilliseconds}");


            Console.WriteLine("Goodbye World");
            Console.ReadLine();

        }

        static void LongProcess()
        {
            Thread.Sleep(1000);
        }

        static void LogError()
        {
            var message = "Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message Some long message ";

            log.Info($"Information : {message}");
            log.Debug($"Debug : {message}");
            log.Warn($"Warning : {message}");
            log.Error($"Error : {message}");
            log.Fatal($"Fatal : {message}");

            log.Info($"Information : {message}");
            log.Debug($"Debug : {message}");
            log.Warn($"Warning : {message}");
            log.Error($"Error : {message}");
            log.Fatal($"Fatal : {message}");
        }
    }
}
