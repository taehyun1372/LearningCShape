using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _43_WCF_Instance_Management_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Student)))
            {
                Console.WriteLine("Hello World");
                host.Open();

                Console.ReadLine();
            }
        }

    }
    [ServiceContract]
    public interface IStudent
    {
        [OperationContract]
        void DisplayName();
    }

    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class Student :IStudent
    {
        public string Name { get; set; }
        private static int _counter = 0;

        public Student()
        {
            _counter++;
            Console.WriteLine(_counter);
        }
        public void DisplayName()
        {
            Console.WriteLine($"Name is {Name}");
        }
    }
}
