using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _6_WCF_Client1
{
    [ServiceContract(CallbackContract = typeof(IMyCallback))]
    public interface IHelloService
    {
        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        void Subscribe();
    }
    public interface IMyCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnNotify(object sender, string message);
    }

    public class MyCallback : IMyCallback
    {
        public void OnNotify(object sender, string message)
        {
            Console.WriteLine("Server says: " + message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var address = new EndpointAddress("http://localhost:8000/HelloService");
            var binding = new WSDualHttpBinding();

            var callback = new MyCallback();
            var instanceContext = new InstanceContext(callback);

            var factory = new DuplexChannelFactory<IHelloService>(instanceContext, binding, address);
            var proxy = factory.CreateChannel();

            proxy.Subscribe();

            string result = proxy.SayHello("Alice");
            Console.WriteLine(result);

            Console.WriteLine("Client is running..Press Enter to exit");
            Console.ReadLine();
            ((IClientChannel)proxy).Close();
            factory.Close();
        }
    }
}
