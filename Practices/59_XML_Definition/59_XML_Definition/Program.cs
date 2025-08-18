using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using _59_XML_Definition.Parameters;

namespace _59_XML_Definition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            XmlSerializer serializer = new XmlSerializer(typeof(Definitions));
            using (FileStream filestream = new FileStream(@"XMLRepo\Definitions.xml", FileMode.Open))
            {
                Definitions definitions = (Definitions)serializer.Deserialize(filestream);

                foreach (Parameter param in definitions.Parameters)
                {
                    Console.WriteLine($"Id : {param.Id}");
                    Console.WriteLine($"Name : {param.Name}");
                    Console.WriteLine($"Description : {param.Description}");
                    Console.WriteLine($"Max : {param.Max}");
                    Console.WriteLine($"Min : {param.Min}");
                    Console.WriteLine($"Unit : {param.Unit}");

                }
            }



            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }
}
