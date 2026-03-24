using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Bulder_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new PDFBuilder("report.txt");
            Director director = new Director(builder);
            director.Build("High Alarm Raised..");
            Console.ReadLine();
        }
    }
}
