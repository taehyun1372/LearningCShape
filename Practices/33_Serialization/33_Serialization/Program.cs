using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Serialization;
using System.IO;

namespace _33_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            string filePath = ConfigurationManager.AppSettings["MappingPath"];
            var Mapping = LaoderFromXml(filePath);
            foreach (Device device in Mapping.Devices)
            {
                Console.WriteLine($"Device name is {device.Name}");
                foreach (Parameter param in device.Parameters)
                {
                    Console.WriteLine($"Unit Id is {param.UnitId}, Parameter Id is {param.ParameterId}");
                }
            }

            Console.ReadLine();
        }

        static Root LaoderFromXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Root));
            using (StreamReader reader = new StreamReader(path))
            {
                return (Root)serializer.Deserialize(reader);
            }
        }



    }
}
