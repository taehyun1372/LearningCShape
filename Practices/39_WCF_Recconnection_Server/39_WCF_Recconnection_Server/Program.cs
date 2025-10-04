using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace _39_WCF_Recconnection_Server
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

    public static class CallbackManager
    {
        public static List<IMyCallback> Clients = new List<IMyCallback>();
    }

    public class MainHostService : IMainHostService
    {
        public string GetMessage(string name)
        {
            return $"This is a message from the server {name}";
        }

        public void Subscribe()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IMyCallback>();
            if(!CallbackManager.Clients.Contains(callback))
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
            Console.WriteLine("Hello World");
            using (ServiceHost host = new ServiceHost(typeof(MainHostService)))
            {
                try
                {
                    host.Open();
                    Console.WriteLine("Service is running, type something to close..");

                    while(true)
                    {
                        var input = Console.ReadLine();
                        if (input?.ToLower() == "exit")
                        {
                            break;
                        }
                        else if (input.Length > 0)
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
                        else
                        {
                            break;
                        }
                    }
                    host.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error : {ex.Message}");
                }
            }
        }
    }
}
