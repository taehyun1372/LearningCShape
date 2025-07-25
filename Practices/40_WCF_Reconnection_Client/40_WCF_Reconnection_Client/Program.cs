using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _40_WCF_Reconnection_Client
{
    [ServiceContract(CallbackContract = typeof(IMyCallback))]
    public interface IMainHostService
    {
        [OperationContract]
        string GetMessage(string name);

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
            Console.WriteLine($"Server said : {message}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var callback = new MyCallback();
            var context = new InstanceContext(callback);
            using(MainHostServiceClient client = new MainHostServiceClient(context))
            {
                try
                {
                    while(true)
                    {
                        var input = Console.ReadLine();
                        if (input == "1")
                        {
                            try
                            {
                                string response = client.GetMessage("John");
                                Console.WriteLine($"Response received : {response}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error : {ex.Message}");
                            }
                        }
                        if(input == "2")
                        {
                            try
                            {
                                Console.WriteLine($"Trying to subscribe");
                                client.Subscribe();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error : {ex.Message}");
                            }
                        }
                        else if (input == "3")
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");
                }
                Console.WriteLine("Goodbye World");
                Console.ReadLine();
            }
        }
    }




    public class MainHostServiceClient : DuplexClientBase<IMainHostService>, IMainHostService
    {
        public MainHostServiceClient(InstanceContext callbackInstance)
        : base(callbackInstance)
        {
        }

        public string GetMessage(string name)
        {
            return base.Channel.GetMessage(name);
        }

        public void Subscribe()
        {
            base.Channel.Subscribe();
        }
    }

}
