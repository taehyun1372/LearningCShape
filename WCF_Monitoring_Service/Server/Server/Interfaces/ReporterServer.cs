using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interfaces
{
    public class ReporterServer : IReporterServer
    {
        public void Parameterchanged(string message)
        {
            Console.WriteLine(message);
        }
    }
}
