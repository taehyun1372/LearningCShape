using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.Collections.Concurrent;

namespace _7_Call_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            CallCenter center = new CallCenter();
            Parallel.Invoke(
                () => CallCenter.CallersAction(center),
                () => CallCenter.ConsultantAction(center, "Marcin", ConsoleColor.Red),
                () => CallCenter.ConsultantAction(center, "James", ConsoleColor.Yellow),
                () => CallCenter.ConsultantAction(center, "Olivia", ConsoleColor.Green));


            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }


    }

    public class CallCenter
    {

        private int _count = 0;
        private readonly object _lock = new object();
        public Queue<IncomingCall> Calls { get; set; }
        public CallCenter()
        {
            Calls = new Queue<IncomingCall>();
        }

        public IncomingCall Answer(string consultant)
        {
            lock (_lock)
            {
                if (Calls.Count > 0)
                {
                    IncomingCall call = Calls.Dequeue();
                    call.Consultant = consultant;
                    call.StartTime = DateTime.Now;
                    return call;
                }
                return null;
            }
        }

        public int Call(int clientId)
        {
            lock(_lock)
            {
                IncomingCall call = new IncomingCall()
                {
                    Id = ++_count,
                    ClientId = clientId,
                    CallTime = DateTime.Now
                };
                Calls.Enqueue(call);
                return Calls.Count;
            }
        }

        public void End(IncomingCall call)
        {
            if (call != null)
            {
                call.EndTime = DateTime.Now;
            }
        }

        public bool AreWaitingCalls()
        {
            return Calls.Count > 0;
        }

        public static void CallersAction(CallCenter center)
        {
            Random random = new Random();
            while (true)
            {
                int clientId = random.Next(1, 10000);
                int waitingcount = center.Call(clientId);
                Log($"Incoming call from {clientId}, waiting in the queue: { waitingcount}");
                Thread.Sleep(random.Next(1, 2));
            }
        }

        public static void ConsultantAction(CallCenter center, string name, ConsoleColor color)
        {
            Random random = new Random();
            while (true)
            {
                IncomingCall call = center.Answer(name);
                if (call != null)
                {
                    Console.ForegroundColor = color;
                    Log($"Call #{call.Id} from {call.ClientId} is answered by { call.Consultant}.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(random.Next(3, 5));
                    center.End(call);
                    Console.ForegroundColor = color;
                    Log($"Call #{call.Id} from {call.ClientId} is ended by { call.Consultant}.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(random.Next(3, 5));
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        public static void Log(string text)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] { text}");
        }
    }

    public class IncomingCall
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CallTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Consultant { get; set; }
    }
}
