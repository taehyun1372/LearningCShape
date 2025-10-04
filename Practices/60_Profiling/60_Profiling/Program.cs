using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _60_Profiling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.Title = "Diagnostics";
            int pid = Process.GetCurrentProcess().Id;
            Console.WriteLine($"Process id : {pid}");
            Boolean _cancellationToken = true;
            List<Student> _mainStudents = new List<Student>();
            while (_cancellationToken)
            {
                var input = Console.ReadLine();
                int number;
                if (int.TryParse(input, out number))
                {
                    _mainStudents.AddRange(GetStudents(number));
                    Console.WriteLine($"{number} students addedd successfully");
                }
                else
                {
                    _cancellationToken = false;
                }
            }

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }

        static List<Student> GetStudents(int number)
        {
            var result = new List<Student>();

            for (int i = 0; i < number; i++)
            {
                result.Add(new Student());
            }

            Console.WriteLine($"{number} students created successfully");
            return result;
        }
    }

    public class Student
    {
        private byte[] _id = new byte[1000];
        private String[] _name = new String[1000];
        private String[] _description = new String[1000];
        private int[] _address = new int[1000];
    }
}
