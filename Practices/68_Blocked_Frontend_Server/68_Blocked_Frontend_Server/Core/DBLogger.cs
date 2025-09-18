using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _68_Blocked_Frontend_Server.Core
{
    public class DBLogger
    {
        public static int logCount = 0;
        public void ParameterLog(object sender, int param)
        {
            Console.WriteLine($"Client requested log {param} into d, {logCount} ");
            logCount++;
            Thread.Sleep(30);

        }
    }
}
