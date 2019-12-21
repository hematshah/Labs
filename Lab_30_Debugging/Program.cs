#define HEMATTESTCODE
using System;
using System.IO;
using System.Diagnostics;

namespace Lab_30_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                var j = $"your number doubled is {i*2}";
                DoThis();
                Console.Write($"{i} ");
            }

#if DEBUG
        Console.WriteLine(  "your code is in debug mode" );
#endif

#if HEMATTESTCODE // capital letterswhen naming
            Console.WriteLine("CODE is running smoothly");
#endif

            Debug.WriteLine("We are in debug mode");
            int z = 100;
            Debug.WriteLineIf(z == 100, "z is 100");

            Trace.WriteLine("Tracing some output");
            Trace.WriteLineIf(z==100, "z is 100 on trace writeline");

            File.AppendAllText("events.log", $"z has value {z} at {DateTime.Now}");

            // Real hackers begin here


        }

            



        static void DoThis() 
        {
            Console.WriteLine("Do this for me");
        }
    }
}
