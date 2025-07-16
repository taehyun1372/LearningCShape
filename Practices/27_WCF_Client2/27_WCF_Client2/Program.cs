using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace _27_WCF_Client2
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
            var factory = new ChannelFactory<IHelloService>("netTcpBinding_IHelloService");
            var proxy = factory.CreateChannel();

            string result = proxy.SayHello("Alice");
            Console.WriteLine(result);

            ((IClientChannel)proxy).Close();
            factory.Close();

            Console.ReadLine();
        }
    }
}
