using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;

namespace _46_WCF_Call_Stack_Client
{
    class Program
    {
        static private bool _cancellationToken = false;
        static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
            Console.WriteLine("Hello World");
            var _counter = 0;
            var _proxy = new StudentServiceClient();
            string _longMessage = new string('X', 1024 * 1); // 1 MB of 'X'

            while (true)
            {
                if (!_cancellationToken)
                {
                    _counter++;
                    _proxy.SayHello(_longMessage);
                    Console.WriteLine($"Requested {_counter}");
                }
            }
        }

        static void OnExit(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("\nCtrl+C detected!");
            _cancellationToken = true;
            // Optional: cancel termination
            e.Cancel = true;
        }
    }

    public class StudentServiceClient : ClientBase<IStudent>, IStudent
    {
        public void SayHello(string message)
        {
            base.Channel.SayHello(message);
        }
    }
    [ServiceContract]
    public interface IStudent
    {
        [OperationContract(IsOneWay = true)]
        void SayHello(string message);
    }
}
