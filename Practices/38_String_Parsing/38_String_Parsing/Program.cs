using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _38_String_Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            //var result = SquareDigits(911);
            string message = 911.ToString();
            foreach(char c in message)
            {
                Console.WriteLine(c);
                Console.WriteLine((int)c);
                int result;
                int.TryParse(c.ToString(), out result);
                Console.WriteLine(result);
                Console.WriteLine(int.Parse(c.ToString()));
            }
            Console.ReadLine();
        }

        public static int SquareDigits(int n)
        {
            var input = n.ToString();
            var result = "";
            foreach(char c in input)
            {
                result += Math.Pow((int)c, 2).ToString();
            }
            return int.Parse(result);
        }
    }


}
