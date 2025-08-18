using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace _58_Configuration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            string connectionString = ConfigurationManager.ConnectionStrings["firstDB"].ConnectionString;

            Console.WriteLine(connectionString);

            string projectName = ConfigurationManager.AppSettings["projectName"];
            Console.WriteLine(projectName);
            string version = ConfigurationManager.AppSettings["version"];
            Console.WriteLine(version);

            var connSetting = (System.Collections.Specialized.NameValueCollection)
                ConfigurationManager.GetSection("connectionSetting");

            int retryCount;
            int.TryParse(connSetting["retryCount"], out retryCount);
            Console.WriteLine(retryCount);

            int timeout;
            int.TryParse(connSetting["timeout"], out timeout);
            Console.WriteLine(timeout);

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
