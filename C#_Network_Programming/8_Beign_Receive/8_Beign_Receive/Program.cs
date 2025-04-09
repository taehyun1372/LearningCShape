using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _8_Beign_Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1501);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ep);
            socket.Listen(5);
            socket.BeginAccept(new AsyncCallback(Connected), socket);
            while (true)
            {
                Thread.Sleep(5000);
                Console.WriteLine("Main Thread is in process");
            }
        }

        static void Connected(IAsyncResult iar)
        {
            Socket socket = (Socket)iar.AsyncState;
            Console.WriteLine("A connection has been detected");
            try
            {
                Socket clientSocket = socket.EndAccept(iar);
                Console.WriteLine("A connection has been made successfully");

                //while(true)
                //{
                //    ReceiveData(clientSocket);
                //}
                StateObject state = new StateObject();
                state.ClientSocket = clientSocket;
                BeginReceiveData(state);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Connection has been failed");
            }
        }

        static void ReceiveData(Socket cilent)
        {
            var data = new byte[100];
            Console.WriteLine("Waiting for a data while blocking this thread");
            cilent.Receive(data);
            Console.WriteLine($"Message : {Encoding.ASCII.GetString(data)}");
            Thread.Sleep(1000);
        }

        static void BeginReceiveData(StateObject state)
        {
            Console.WriteLine("Waiting for a data");
            Socket client = state.ClientSocket;
            client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, new AsyncCallback(DisplayMessage), state);
        }

        static void DisplayMessage(IAsyncResult iar)
        {
            StateObject state = (StateObject)iar.AsyncState;
            Socket clientSocket = state.ClientSocket;
            int bytesCount = clientSocket.EndReceive(iar);

            state.totalCounter += bytesCount;
            byte[] buffer = state.Buffer;
            Console.WriteLine($"A message received (total count - {state.totalCounter}) : {Encoding.ASCII.GetString(buffer)}");

            BeginReceiveData(state);
        }
    }

    public class StateObject
    {
        public Socket ClientSocket;
        public byte[] Buffer = new byte[100];
        public int totalCounter = 0;
    }
}
