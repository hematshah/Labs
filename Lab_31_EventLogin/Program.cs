using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Lab_31_EventLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog.WriteEntry("Application", "hey we are taking over you PC",
                EventLogEntryType.Error, 5001,1239);
        }
    }
}
