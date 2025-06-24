using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Maskify
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(maskify2("12"));
            
            string message = "Hello World!";
            Console.WriteLine(message.Substring(message.Length - 4));
            Console.WriteLine(message.Substring(message.Length - 4).PadLeft(message.Length, '#'));

            Console.ReadLine();
        }

        static string maskify(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                char c;
                if (i < input.Length - 4)
                {
                    c = '#';
                }
                else
                {
                    c = input[i];
                }
                result += c;
            }
            return result;
        }

        static string maskify2(string cc)
        {
            return cc.Length > 4 ? cc.Substring(cc.Length - 4).PadLeft(cc.Length, '#') : cc;
        }


    }
}
