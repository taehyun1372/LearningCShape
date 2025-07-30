using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _51_WCF_Duplex_Server
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ServiceHost _service = new ServiceHost(typeof(Server));
            _service.Open();

            while(true)
            {
                var input = Console.ReadLine();
                if (input == "1")
                {
                    Client._proxy.Notify();
                }
                else
                {
                    break;
                }

            }

            Console.WriteLine("Goodbye World!");
            Console.ReadLine();
        }
    }

    public static class Client
    {
        public static ICallback _proxy;
    }


    class Server : IServer
    {
        private static int _counter;
        public Server()
        {
            _counter++;
            Console.WriteLine($"Server instance is created {_counter}");
        }
        public void SayHello()
        {
            Console.WriteLine("Say Hello Called");
        }

        public string HaveGreet()
        {
            Console.WriteLine("Have Greet Called");
            return "Have greet message from sever";
        }
        public void Subscribe()
        {
            Client._proxy = OperationContext.Current.GetCallbackChannel<ICallback>();
            Console.WriteLine("A client subscribed");
        }
    }

    [ServiceContract(CallbackContract = typeof(ICallback))]
    interface IServer
    {
        [OperationContract(IsOneWay = true)]
        void SayHello();

        [OperationContract(IsOneWay  = false)]
        string HaveGreet();

        [OperationContract(IsOneWay = true)]
        void Subscribe();
    }

    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void Notify();
    }


}
