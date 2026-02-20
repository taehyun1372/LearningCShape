using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _6_Cancenllation_Token
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource commsCts = new CancellationTokenSource();
            CancellationTokenSource loggingCts = new CancellationTokenSource();
            var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(commsCts.Token, loggingCts.Token);

      
            Initalise(commsCts.Token, loggingCts.Token, linkedCts.Token);

            while (true)
            {
                Console.WriteLine("Enter your command>>");
                var command = Console.ReadLine();
                if (command == "1")
                {
                    commsCts.Cancel();
                }
                else if(command == "2")
                {
                    loggingCts.Cancel();
                }
                else if(command == "3")
                {
                    linkedCts.Cancel();
                }

            }
            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }

        public async static Task Initalise(CancellationToken commsToken, CancellationToken loggingToken, CancellationToken linkedToken)
        {
            var commsTask = CommunicationProcess(commsToken, linkedToken);
            var loggingTask = LoggingProcess(loggingToken, linkedToken);

            try
            {
                await commsTask;
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Communication process cancelled for some reason..");
            }

            try
            {
                await loggingTask;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Logging process cancelled for some reason..");
            }


        }

        public async static Task CommunicationProcess(CancellationToken commsToken, CancellationToken linkedToken)
        {

            for(int i = 0; i < 10; i++)
            {
                commsToken.ThrowIfCancellationRequested();
                linkedToken.ThrowIfCancellationRequested();

                Console.WriteLine($"Communication..{i}");
                await Task.Delay(5000);
            }

            Console.WriteLine("Communication Process finished norally");
        }

        public async static Task LoggingProcess(CancellationToken loggingToken, CancellationToken linkedToken)
        {
            for (int i = 0; i < 10; i++)
            {
                loggingToken.ThrowIfCancellationRequested();
                linkedToken.ThrowIfCancellationRequested();

                Console.WriteLine($"Logging..{i}");
                await Task.Delay(5000);
            }

            Console.WriteLine("Logging Process finished norally");
        }
    }
}
