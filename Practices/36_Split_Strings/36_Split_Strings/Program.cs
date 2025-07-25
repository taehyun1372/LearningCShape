using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_Split_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var result = SplitString2.Solution("abc");
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

            var enumerable = Enumerable.Range(0, 10);
            foreach (var i in enumerable)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }


    }

    public class SplitString
    {
        public static string[] Solution(string str)
        {
            if (str.Length % 2 != 0) str += '_';
            string[] result = new string[str.Length/2];
            int count = 0;
            for (int i = 0; i < result.Length; i++)
            {
                var item = str[i*2].ToString() + str[i*2 + 1].ToString();
                result[count] = item;
                count++;
            }
            return result;
        }
    }

    public class SplitString2
    {
        public static string[] Solution(string str)
        {
            if (str.Length % 2 != 0)
                str += "_";
            return Enumerable.Range(0, str.Length)
              .Where(x => x % 2 == 0)
              .Select(x => str.Substring(x, 2))
              .ToArray();
        }
    }
}
