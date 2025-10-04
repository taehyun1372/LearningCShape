using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;

namespace _45_WCF_Call_Stack_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            ServiceHost _host = new ServiceHost(typeof(Student));
            _host.Open();
            Console.ReadLine();
        }
    }
    [ServiceContract]
    public interface IStudent
    {
        [OperationContract(IsOneWay = true)]
        void SayHello(string message);
    }
    public class Student : IStudent
    {
        private static int _counter = 0;
        public Student()
        {
            Console.WriteLine("Service instance created..");
        }
        public void SayHello(string message)
        {
            Console.WriteLine($"Received! size : {message.Length}, index : {_counter}, time : {DateTime.Now.ToString("hh:mm:ss fff")}");
            Thread.Sleep(1);
            _counter++;
        }
    }
}
