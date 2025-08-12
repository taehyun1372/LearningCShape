using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace _54_WCF_Data_Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            ServiceHost _service = new ServiceHost(typeof(Processor));
            _service.Open();

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }

    public class Processor : IProcessor
    {
        public Student SayHello(string name, int id)
        {
            Console.WriteLine("A client called..");
            return new Student() { Name = name, Id = id };
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
