using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _5_WCF_Server1
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
            return $"Hello, {name} !";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8000/HelloService");
            using (var host = new ServiceHost(typeof(HelloService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(IHelloService), new BasicHttpBinding(), "");
                host.Open();
                Console.WriteLine("Service is running..Press Enter to exit");
                Console.ReadLine();
                host.Close();
            }

        }
    }
}
