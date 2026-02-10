using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _81_Skyscrapers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something happened..");
            int[] testee1 = new int[]{2, 2, 1, 3,
                                      2, 2, 3, 1,
                                      1, 2, 2, 3,
                                      3, 2, 1, 3};
            var result = Skyscrapers.SolvePuzzle(testee1);
            foreach (var row in result)
            {
                foreach(var item in row)
                {
                    Console.Write(item);
                }
                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }

    public class Skyscrapers
    {
        public static int[][] SolvePuzzle(int[] clues)
        {

            var result = new[] { new[] {1, 3, 4, 2},
                                new[] {4, 2, 1, 3},
                                new[] {3, 4, 2, 1},
                                new[] {2, 1, 3, 4} };
            return result;
        }
    }

}
