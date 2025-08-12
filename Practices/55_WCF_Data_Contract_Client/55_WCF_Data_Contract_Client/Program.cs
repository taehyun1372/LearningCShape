using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace _55_WCF_Data_Contract_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var factory = new ChannelFactory<IProcessor>("_55_WCF_Data_Contract_Client_IProcessor");
            var proxy = factory.CreateChannel();
            Student result = proxy.SayHello("Alice", 32);
            Console.WriteLine($"return value is name : {result.Name}, Id : {result.Id}");

            Console.WriteLine("Goobye World");
            Console.ReadLine();
        }
    }


    [ServiceContract]
    interface IProcessor
    {
        [OperationContract]
        Student SayHello(string name, int id);
    }

    [DataContract(Namespace = "net.tcp://localhost:8000/Processor")]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}
