using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _51_WCF_Duplex_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var callbackHandler = new CallbackHandler();
            var context = new InstanceContext(callbackHandler);
            var proxy = new Callback(context);

            while(true)
            {
                var input = Console.ReadLine();
                if (input == "1")
                {
                    proxy.SayHello();
                }
                else if (input == "2")
                {
                    var message = proxy.HaveGreet();
                    Console.WriteLine(message);
                }
                else if (input == "3")
                {
                    proxy.Subscribe();
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


    [ServiceContract(CallbackContract =typeof(ICallback))]
    interface IServer
    {
        [OperationContract(IsOneWay = true)]
        void SayHello();

        [OperationContract(IsOneWay = false)]
        string HaveGreet();

        [OperationContract(IsOneWay = true)]
        void Subscribe();
    }

    interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void Notify();
    }

    class Callback : DuplexClientBase<IServer>, IServer
    {
        public Callback(InstanceContext context)
            : base(context)
        {
        }

        public string HaveGreet()
        {
            return this.Channel.HaveGreet();
        }

        public void SayHello()
        {
            this.Channel.SayHello();
        }

        public void Subscribe()
        {
            this.Channel.Subscribe();
        }
    }

    class CallbackHandler : ICallback
    {
        public void Notify()
        {
            Console.WriteLine("Server called this callback");
        }
    }

}
