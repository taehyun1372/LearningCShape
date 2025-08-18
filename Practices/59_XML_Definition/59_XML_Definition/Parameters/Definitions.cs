using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _59_XML_Definition.Parameters
{
    [Serializable, XmlRoot("Definitions")]
    public class Definitions
    {
        [XmlArray("Parameters")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> Parameters { get; set; }
    }

    [Serializable]
    public class Parameter
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }

        [XmlAttribute("Min")]
        public double Min { get; set; }

        [XmlAttribute]
        public double Max { get; set; }

        [XmlAttribute("Unit")]
        public string Unit { get; set; }
    }
}
