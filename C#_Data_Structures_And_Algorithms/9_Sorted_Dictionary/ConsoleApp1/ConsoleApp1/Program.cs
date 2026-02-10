using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SortedDictionary<string, string> definitions = new SortedDictionary<string, string>();
            do
            {
                Console.Write("Choose an option ([a] - add, [l] - list): ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();
                if (keyInfo.Key == ConsoleKey.A)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter the name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter the explnation : ");
                    string explanation = Console.ReadLine();
                    definitions[name] = explanation;
                    Console.ForegroundColor = ConsoleColor.Gray;

                }
                else if (keyInfo.Key == ConsoleKey.L)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (KeyValuePair<string, string> definition in definitions)
                    {
                        Console.WriteLine($"{definition.Key}:{definition.Value}");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Do you want to exit the program? Press[y](yes) or[n](no).");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        break;
                    }
                }
            } while (true);
        }
    }
}
