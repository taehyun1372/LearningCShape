using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace _2_FIle_Open
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var path = @"Logs\Log_File.txt";
            var reader = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            byte[] bytes = new byte[reader.Length];
            reader.Read(bytes, 0, bytes.Length);

            string text = Encoding.UTF8.GetString(bytes);
            
            Console.WriteLine(text);

            Console.WriteLine("Goodbye World");
            Console.ReadLine();

        }
    }
}
