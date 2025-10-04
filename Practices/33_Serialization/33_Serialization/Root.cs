using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _33_Serialization
{
    public class Root
    {
        [XmlArray]
        [XmlArrayItem("Device")]
        public List<Device> Devices { get; set; }
    }
    public class Device
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlArray]
        [XmlArrayItem]
        public List<Parameter> Parameters { get; set; }
    }

    public class Parameter
    {
        [XmlAttribute("Id")]
        public int ParameterId { get; set; }

        [XmlAttribute]
        public int UnitId { get; set; }
    }

}
