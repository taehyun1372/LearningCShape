using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _83_Molecule_To_Atoms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something");

            var result = Kata.ParseMolecule("H20");
            foreach (var kvp in result)
            {
                Console.WriteLine($"Key : {kvp.Key} and Value : {kvp.Value}");
            }
            Console.WriteLine("Happened");
            Console.ReadLine();
        }
    }
    public class Kata
    {
        public static Dictionary<string, int> ParseMolecule(string formula)
        {
            var result = new Dictionary<string, int>();
            int index = 0;
            int selectIndex = 0;
            foreach(var c in formula)
            {
                if (!Char.IsDigit(c))
                {
                    selectIndex = index - 1;
                    while (Char.IsUpper(formula[selectIndex]))
                    {
                        selectIndex--;
                    }

                }
                else if(Char.IsUpper(c))
                {

                }
                else if(Char.IsLower(c))
                {

                }
                else
                {

                }
                index++;
            }

            return result;
        }
    }
}
