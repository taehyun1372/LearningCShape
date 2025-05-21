using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _6_WCF_Client1
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string SayHello(string name);
    }
    class Program
    {
        static void Main(string[] args)
        {
            var address = new EndpointAddress("http://localhost:8000/HelloService");
            var binding = new BasicHttpBinding();

            var factory = new ChannelFactory<IHelloService>(binding, address);
            var proxy = factory.CreateChannel();

            string result = proxy.SayHello("Alice");
            Console.WriteLine(result);

            Console.WriteLine("Client is running..Press Enter to exit");
            Console.ReadLine();
            ((IClientChannel)proxy).Close();
            factory.Close();
        }
    }
}
