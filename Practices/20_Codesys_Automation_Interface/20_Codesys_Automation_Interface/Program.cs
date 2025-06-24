using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoDeSys;

namespace _20_Codesys_Automation_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            var codesys = new CCoDeSys();
            codesys.OpenProject(@"D:\git\Tumalo\Modbus_Test_Project.project");
        }
    }
}
