using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _65_Async_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var t1 = GetDataAsync();
            
            Console.WriteLine(t1.Result);


            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }

        static public async Task<int> GetDataAsync()
        {
            int result = await Task.Run(() => BigData());
            return result;
        }

        static public int BigData()
        {
            Thread.Sleep(1000);
            return 30;
        }
    }


}
