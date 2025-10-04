using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace _44_WCF_Instance_Management_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            MyStudentServiceClient proxy = new MyStudentServiceClient();
            while(true)
            {
                var input = Console.ReadLine();
                if (input == "1")
                {
                    proxy.DisplayName();
                }
                else if(input == "exit")
                {
                    break;
                }
            }

        }
    }

    class MyStudentServiceClient : ClientBase<IStudent>, IStudent
    {
        public void DisplayName()
        {
            base.Channel.DisplayName();
        }
    }

    [ServiceContract]
    public interface IStudent
    {
        [OperationContract]
        void DisplayName();
    }
}
