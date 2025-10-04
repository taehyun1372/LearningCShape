using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _5_WCF_Server1
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

    public static class CallbackManager
    {
        public static List<IMyCallback> Clients = new List<IMyCallback>();
    }

    public class HelloService : IHelloService
    {

        public string SayHello(string name)
        {
            return $"Hello, {name} !";
        }
        public void Subscribe()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMyCallback>();
            if (!CallbackManager.Clients.Contains(callback))
            {
                CallbackManager.Clients.Add(callback);
                Console.WriteLine("A client subscribed");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var baseAddress = new Uri("http://localhost:8000/HelloService");
            using (var host = new ServiceHost(typeof(HelloService), baseAddress))
            {
                host.AddServiceEndpoint(typeof(IHelloService), new WSDualHttpBinding(), "");
                host.Open();
                Console.WriteLine("Service is running..Press Enter to exit");
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input?.ToLower() != "exit")
                    {
                        foreach (var client in CallbackManager.Clients)
                        {
                            try
                            {
                                client.OnNotify(null, $"{input}: {DateTime.Now}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error notifying client, removing..");
                                CallbackManager.Clients.Remove(client);
                            }
                        }
                    }
                }
            }
        }
    }
}
