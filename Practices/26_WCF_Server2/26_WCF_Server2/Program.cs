using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _26_WCF_Server2
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string SayHello(string name);
    }

    public class HelloService : IHelloService
    {

        public string SayHello(string name)
        {
            Console.WriteLine("A Client called");
            Thread.Sleep(2000);
            Console.WriteLine("Process done, now returning");
            return $"Hello, {name} !";
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World");
                using (var host = new ServiceHost(typeof(HelloService)))
                {
                    host.Open();
                    Console.WriteLine("Service is ruuning..Press Enter to exit");
                    while (true)
                    {
                        var input = Console.ReadLine();
                        if (input?.ToLower() != "exit")
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
        }
    }
}
