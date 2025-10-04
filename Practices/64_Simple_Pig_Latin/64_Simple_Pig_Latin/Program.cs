using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64_Simple_Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Console.WriteLine(Kata.PigIt("Pig latin is cool"));
            Console.WriteLine(Kata.PigIt("Hello world !"));

            Console.WriteLine(Kata2.Likes(new string[0]));
            Console.WriteLine(Kata2.Likes(new string[1] {"Peter"}));
            Console.WriteLine(Kata2.Likes(new string[2] { "Jacob", "Alex" }));
            Console.WriteLine(Kata2.Likes(new string[3] { "Max", "John", "Mark" }));


            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }

    public class Kata
    {
        public static string PigIt(string str)
        {
            var items = str.Split(' ');
            List<string> results = new List<String>();
            foreach (string item in items)
            {
                var result = "";
                var first = item[0];
                if ((int)first >= 'A' && (int)first <= 'z')
                {
                    result = item.Remove(0, 1);
                    result += first;
                    result += "ay";
                    results.Add(result);
                }
                else
                {
                    results.Add(first.ToString());
                }
            }

            return string.Join(" ", results);
        }
    }

    public static class Kata2
    {
        public static string Likes(string[] name)
        {
            var result = "";
            if (name.Length == 0)
            {
                result = "no one";
                result += " likes this";
            }
            else if (name.Length == 1)
            {
                result = name[0];
                result += " likes this";
            }
            else if (name.Length == 2 || name.Length == 3)
            {
                result = string.Join(", ", name);
                var index = result.LastIndexOf(", ");
                result = result.Remove(index, 2);
                result = result.Insert(index, " and ");
                result += " like this";
            }
            else
            {
                result = string.Join(", ", name.Take(2));
                result += $" and {name.Length - 2} others like this";
            }

            return result;
        }
    }
}




