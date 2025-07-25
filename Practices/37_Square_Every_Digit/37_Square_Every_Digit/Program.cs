using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_Square_Every_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var result = Kata.SquareDigits(9119);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }

    public class Kata
    {
        public static int SquareDigits(int n)
        {
            string strResult = "";
            foreach (var c in n.ToString())
            {
                int i;
                int.TryParse(c.ToString(), out i);
                strResult += (i * i).ToString();
            }
            int intResult;
            int.TryParse(strResult, out intResult);
            return intResult;
        }
    }

    public class Kata2
    {
        public static int SquareDigits(int n)
        {
            return int.Parse(String.Concat(n.ToString().Select(a => (int)Math.Pow(char.GetNumericValue(a), 2))));
        }
    }
}
