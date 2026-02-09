using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace _89_Convert_RGB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var testee1 = "#FF9933";
            var testee2 = "#beaded";
            var testee3 = "#000000";
            var testee4 = "#111111";
            var testee5 = "#Fa3456";
            var wrongTestee1 = "Fa3456";
            var wrongTestee2 = "#12345";
            try
            {
                foreach (var kv in Kata.hexStringToRGB(testee1)) Console.WriteLine($"Key : {kv.Key}, Value : {kv.Value}");
                foreach (var kv in Kata.hexStringToRGB(testee2)) Console.WriteLine($"Key : {kv.Key}, Value : {kv.Value}");
                foreach (var kv in Kata.hexStringToRGB(testee3)) Console.WriteLine($"Key : {kv.Key}, Value : {kv.Value}");
                foreach (var kv in Kata.hexStringToRGB(testee4)) Console.WriteLine($"Key : {kv.Key}, Value : {kv.Value}");
                foreach (var kv in Kata.hexStringToRGB(testee5)) Console.WriteLine($"Key : {kv.Key}, Value : {kv.Value}");
                foreach (var kv in Kata.hexStringToRGB(wrongTestee1)) Console.WriteLine($"Key : {kv.Key}, Value : {kv.Value}");
                foreach (var kv in Kata.hexStringToRGB(wrongTestee2)) Console.WriteLine($"Key : {kv.Key}, Value : {kv.Value}");
            }
            catch
            {
                Console.WriteLine("Logging the error..");
            }


            Console.WriteLine("Goodbye World!");
            Console.ReadLine();
        }
    }

    class Kata
    {
        public static Dictionary<char, int> hexStringToRGB(string rgb)
        {
            var result = new Dictionary<char, int>();

            // Input validation 
            var index = rgb.IndexOf('#');
            if (index == -1 || rgb.Length != 7) throw new InvalidOperationException();

            rgb = rgb.Remove(index, 1);

            result.Add('r', int.Parse(rgb.Substring(0, 2), NumberStyles.HexNumber));
            result.Add('g', int.Parse(rgb.Substring(2, 2), NumberStyles.HexNumber));
            result.Add('b', int.Parse(rgb.Substring(4, 2), NumberStyles.HexNumber));

            return result;
        }
    }
}
