using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _88_Snake_Case
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something");
            var testee1 = "TestController";
            var testee2 = "MoviesAndBooks";
            var testee3 = "App7Test";
            var testee4 = 1;
            var result1 = Kata.ToUnderscore(testee1);
            var result2 = Kata.ToUnderscore(testee2);
            var result3 = Kata.ToUnderscore(testee3);
            var result4 = Kata.ToUnderscore(testee4);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);

            Console.WriteLine("Happened");
            Console.ReadLine();

        }
    }

    public static class Kata
    {
        public static string ToUnderscore(int str)
        {
            return str.ToString();
        }

        public static string ToUnderscore(string str)
        {
            var cnt = 0;
            var result = "";
            foreach(var c in str)
            {

                if (char.IsUpper(c))
                {
                    if (cnt == 0) result += char.ToLower(c);
                    else result += string.Concat("_", char.ToLower(c));
                }
                else result += c;
                cnt++;
            }
            return result;
        }
    }
}
