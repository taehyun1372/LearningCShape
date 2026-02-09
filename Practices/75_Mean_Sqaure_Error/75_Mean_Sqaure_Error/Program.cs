using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _75_Mean_Sqaure_Error
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            int[] testee1 = { 1, 2, 3 };
            int[] testee2 = { 4, 5, 6 };
            double result1 = 0;
            for (int i = 0; i < testee1.Length; i++)
            {
                result1 += Math.Pow(testee1[i] - testee2[i], 2);
            }
            result1 = result1 / testee1.Length;
            Console.WriteLine(result1);



            Console.ReadLine();
        }
    }
}
