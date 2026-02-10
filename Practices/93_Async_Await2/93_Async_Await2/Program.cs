using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace _93_Async_Await2
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialise();

            while (true)
            {
                Console.WriteLine("Main thread keeps doing its job");
                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }

        static async Task Initialise()
        {
            Console.WriteLine("Initialising heavy CPU work..");
            await HeavyCPUWork1();

            
            try
            {
                Console.WriteLine("Initialising File read work..");
                await FileReadWork1();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to open a log file");
            }
        }

        static async Task HeavyCPUWork1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    for (int j = 0; j < 100000; j++)
                    {
                        var value = i * j;
                    }
                }
                Console.WriteLine("heavy work finished asynchronously");
            });
        }

        static async Task FileReadWork1()
        {
            await Task.Run(() =>
            {
                using (var reader = new StreamReader(@"Res\Log.txt"))
                {
                    while(!reader.EndOfStream)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
                Console.WriteLine("File read work finished asynchronously");
            });
        }
    }


}
