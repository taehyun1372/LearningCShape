using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1_StreamReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var currentPath = Directory.GetCurrentDirectory();
            Console.WriteLine(currentPath);
            var filePath = @"Res\log.txt";
            filePath = Path.Combine(currentPath, filePath);
            if (File.Exists(filePath))
            {
                var reader = new StreamReader(filePath);
                
                while(!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
                
            }
            Console.WriteLine("----------");
            var Alllines = File.ReadAllLines(filePath);
            foreach(var line in Alllines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("----------");
            var lines = File.ReadLines(filePath);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            //How to use take generally
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6 };
            var subBytes = bytes.Take(3);
            subBytes.ToList<byte>().ForEach(b => Console.Write(b));
            Console.WriteLine();

            Console.WriteLine("-----How to get first n lines-----");
            var lines2 = File.ReadLines(filePath);
            var result2 = lines2.ToArray<String>().Take(3);
            foreach(var line in result2) { Console.WriteLine(line); }

            //How to count lines with certain condition
            var lines3 = File.ReadLines(filePath);
            var count = lines3.ToArray<String>().Count(s => s.Contains("Line"));
            Console.WriteLine(count);

            //How to use All
            string testee1 = "12 34";
            var resutl1 = testee1.All(c => Char.IsDigit(c));
            Console.WriteLine(resutl1);

            Console.WriteLine("---How to exclude empty lines-------");
            var lines4 = File.ReadLines(filePath);
            var result4 = lines4.ToArray().Where(s => !String.IsNullOrEmpty(s));
            foreach(var line in result4) { Console.WriteLine(line); }

            Console.WriteLine("---Whether there is a line that meets a condition-------");
            var line5 = File.ReadLines(filePath);
            var result5 = line5.ToArray().Where(s => !String.IsNullOrEmpty(s))
                .Any(s => s.All(c => Char.IsDigit(c)));
            Console.WriteLine(result5);

            Console.WriteLine("---We want to order lines-------");
            var lines6 = File.ReadLines(filePath);
            var result6 = lines6.Where(s => !String.IsNullOrEmpty(s)).
                Distinct().OrderBy(s => s.Length).ToArray();
            foreach(var line in result6){ Console.WriteLine(line); }

            Console.WriteLine("---Transformation-------");
            var lines7 = File.ReadLines(filePath);
            var result7 = lines6.Where(s => !String.IsNullOrEmpty(s)).
                Select((s, i) => String.Format("{0,4}: {1}", i + 1, s));
            foreach(var line in result7) { Console.WriteLine(line); }

            Console.WriteLine("---FileWriting-------");
            var writeFilePath = @"Res\test.txt";
            using (var writer = new StreamWriter(writeFilePath, append:true))
            {
                writer.WriteLine("This");
                writer.WriteLine("is");
                writer.WriteLine("written");
                writer.WriteLine("by");
                writer.WriteLine("someone else");
            }
            var lines8 = File.ReadLines(writeFilePath);
            foreach(var line in lines8) { Console.WriteLine(line); }
            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
