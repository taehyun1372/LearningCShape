using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _78_Josephus_Survior
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = JosephusSurvivor.JosSurvivor(1, 300);
            Console.WriteLine(result);
            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }

    public class JosephusSurvivor
    {
        public static int JosSurvivor(int n, int k)
        {
            var arr = Enumerable.Range(1, n).ToList();
            int index = 0;
            int step = k - 1;
            while(true)
            {
                if (arr.Count() == 1) break;

                index += step;
                while (index >= arr.Count())
                {
                    index -= arr.Count();
                }
                arr.RemoveAt(index);
            }

            return arr[0];
        }
    }
}
