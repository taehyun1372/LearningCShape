using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _80_Not_Very_Secure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something happened");

            var testee1 = "Mazinkaiser";
            Console.WriteLine(Kata.Alphanumeric(testee1));
            Console.WriteLine(Kata.Alphanumeric2(testee1));

            var testee2 = "hello world_";
            Console.WriteLine(Kata.Alphanumeric(testee2));
            Console.WriteLine(Kata.Alphanumeric2(testee2));

            var testee3 = "PassW0rd";
            Console.WriteLine(Kata.Alphanumeric(testee3));
            Console.WriteLine(Kata.Alphanumeric2(testee3));

            var testee4 = "     ";
            Console.WriteLine(Kata.Alphanumeric(testee4));
            Console.WriteLine(Kata.Alphanumeric2(testee4));

            Console.ReadLine();
        }
    }

    public class Kata
    {
        public static bool False { get; private set; }

        public static bool Alphanumeric(string str)
        {
            if (str.Length == 0) return false; //"" case

            foreach (char c in str)
            {
                if ( !((int)c >= 65 && (int)c <= 90) && !((int)c >= 97 && (int)c <= 122)) //Not Alphabet
                {
                    if ((int)c < 48 || (int)c > 57) //Not Numeric
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool Alphanumeric2(string str)
        {
            return str.All(c => Char.IsLetterOrDigit(c) && !string.IsNullOrEmpty(str));
        }
    }
}
