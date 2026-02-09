using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _82_Observed_PIN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something");
            var testee1 = "8";
            var testee2 = "11";
            var testee3 = "369";
            //Kata.GetPINs(testee1).ForEach(s => Console.Write(s));
            //Console.WriteLine();
            //Kata.GetPINs(testee2).ForEach(s => Console.Write(s));
            //Console.WriteLine();
            Kata.GetPINs(testee3).ForEach(s => Console.WriteLine(s));
            var result = Kata.MultiflyElement(new List<String>() { "123", "456" });
            Console.WriteLine("----------Multiply Elements-----------");
            result.ForEach(s => Console.WriteLine(s));

            Console.WriteLine();

            Console.ReadLine();
        }
    }

    public class Kata
    {
        public static List<string> options = new List<string>() {"0258", "124", "12305", "236", "4517", "45628", "5639", "478", "7895", "896"};

        public static List<string> GetPINs(string observed)
        {
            var posibilities = new List<string>();
            var result = new List<string>();
            foreach (char c in observed)
            {
                if(int.TryParse(c.ToString(), out int value))
                {
                    posibilities.Add(options[value]);
                }
            }


            foreach(char c1 in posibilities[0])
            {
                foreach (char c2 in posibilities[1])
                {
                    foreach (char c3 in posibilities[2])
                    {
                        result.Add(string.Concat(c1, c2, c3));
                    }
                }
            }
            return result;
        }

        public static List<string> MultiflyElement(List<String> elements)
        {
            var total = 0;

            foreach(var s in elements)
            {
                total += s.Count();
            }

            var result = Enumerable.Repeat<String>("", total).ToList<String>();
            
            for (int i = 0; i < elements.Count(); i++)
            {
                for(int j = 0; j < total; j++)
                {
                    result[j] = String.Concat(result[j], elements[i][i]);
                }
            }

            return result;
        }
    }
}
