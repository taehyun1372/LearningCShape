using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_Enumeration_Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            DisplayParameter()

            Console.ReadLine();
        }

        static public void DisplayParameter(ParamUnitType_SNVT snvt)
        {
            Console.WriteLine(snvt);
        }
    }

    public enum ParamUnitType_SNVT
    {
        None = 0,
        Current = 1,
        Flow = 16,
        Discrete = 22,
        Watts = 27,
        KiloWatts = 28,
        Pressure = 30,
        Temperature = 39,
        Volts = 44,
        PressureFloat = 59,
        VoltsFloat = 66,
        Frequency = 76,
        Percentage = 81,
        PressurePascal = 113,
        AbatementRunState = 59904,
    }

    public enum ParamUnitType_SNVT_Extended
    {
        None = ParamUnitType_SNVT.None,
        Current = ParamUnitType_SNVT.Current,
        Flow = ParamUnitType_SNVT.Flow,
        Discrete = ParamUnitType_SNVT.Discrete,
        Watts = ParamUnitType_SNVT.Watts,
        KiloWatts = ParamUnitType_SNVT.KiloWatts,
        Pressure = ParamUnitType_SNVT.Pressure,
        Temperature = ParamUnitType_SNVT.Temperature,
        Volts = ParamUnitType_SNVT.Volts,
        PressureFloat = ParamUnitType_SNVT.PressureFloat,
        VoltsFloat = ParamUnitType_SNVT.VoltsFloat,
        Frequency = ParamUnitType_SNVT.Frequency,
        Percentage = ParamUnitType_SNVT.Percentage,
        PressurePascal = ParamUnitType_SNVT.PressurePascal,
        AbatementRunState = ParamUnitType_SNVT.AbatementRunState,
        Count = 8
    }



}
