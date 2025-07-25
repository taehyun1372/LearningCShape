using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;

namespace _34_Select_Conversion
{
    class Program
    {
        static public List<HMIParameter> _HMIparameters = new List<HMIParameter>();
        static public Unit _unit;
        static void Main(string[] args)
        {

            _unit = LoadUnitDefinition();
            _HMIparameters.Add(new HMIParameter() { ParameterId = 1, Description = "Temp 1", RawValue = 10, RegisterType = "Coils", ConversionId = 1 });
            _HMIparameters.Add(new HMIParameter() { ParameterId = 2, Description = "Temp 2", RawValue = 11, RegisterType = "DiscreteInputs", ConversionId = 2 });
            _HMIparameters.Add(new HMIParameter() { ParameterId = 3, Description = "Temp 3", RawValue = 12, RegisterType = "HolidngRegisters", ConversionId = 3 });
            _HMIparameters.Add(new HMIParameter() { ParameterId = 4, Description = "Temp 4", RawValue = 13, RegisterType = "InputRegisters", ConversionId = 4 });

            var _modbusParameters = _HMIparameters.Where(x => x.RegisterType != "").ToList().Select(x=> ParameterConversion(x)).ToList();
            foreach (var parameter in _modbusParameters)
            {
                Console.WriteLine($"{parameter.ProcessedValue}");
            }

            Console.ReadLine();
        }

        static public Unit LoadUnitDefinition()
        {
            var path = ConfigurationManager.AppSettings["UnitPath"];
            XmlSerializer serializer = new XmlSerializer(typeof(Unit));
            using (StreamReader reader = new StreamReader(path))
            {
                return (Unit)serializer.Deserialize(reader);
            }
        }

        static public int GetMultiplier(int conversionId)
        {
            if (_unit != null)
            {
                var unitDefiniton = _unit.UnitDefinitions.Find(x => x.Id == conversionId);
                return unitDefiniton.Multiplier;
            }
            else
            {
                return 0;
            }
        }

        static public ModbusParameter ParameterConversion(HMIParameter HMIParameter)
        {
            var modbusParameter = new ModbusParameter();
            modbusParameter.ParameterId = HMIParameter.ParameterId;
            modbusParameter.Description = HMIParameter.Description;
            modbusParameter.ProcessedValue = HMIParameter.RawValue * GetMultiplier(HMIParameter.ConversionId);

            RegisterType result;
            if (Enum.TryParse(HMIParameter.RegisterType, out result))
            {
                modbusParameter.RegisterType = result;
            }
            else
            {
                modbusParameter.RegisterType = RegisterType.HolidngRegisters;
            }

            return modbusParameter;
        }
    }

    class HMIParameter
    {
        public int ParameterId { get; set; }
        public string Description { get; set; }
        public int RawValue { get; set; }
        public string RegisterType { get; set; }

        public int ConversionId { get; set; }
    }

    class ModbusParameter
    {
        public int ParameterId { get; set; }
        public string Description { get; set; }
        public int ProcessedValue { get; set; }
        public RegisterType RegisterType { get; set; }

    }

    [Serializable,XmlRoot("Root")]
    public class Unit
    {
        [XmlArray]
        [XmlArrayItem]
        public List<UnitDefinition> UnitDefinitions { get; set; }
    }

    public class UnitDefinition
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Multiplier { get; set; }
    }

    enum RegisterType
    {
        Coils = 1,
        DiscreteInputs = 2,
        HolidngRegisters = 3,
        InputRegisters = 4
    }

    

}
