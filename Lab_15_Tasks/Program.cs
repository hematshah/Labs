using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_15_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // inside here can go a delegate OR Anonymous Method USing LAMBDA '=>'
            //SYNTAX
            var task01 = new Task(
                
                   () => { }  // lambda anonymous method
                
                );
            var task02 = new Task(

                   () => { Console.WriteLine("In task 2"); }  // lambda anonymous method

                );
            task02.Start();

            

            // slicker way

            var task03 = Task.Run(() => { Console.WriteLine("In task 03"); });
            var task04 = Task.Run(() => { Console.WriteLine("In task 04"); });
            var task05 = Task.Run(() => { Console.WriteLine("In task 05"); });

            // stopwatch
            // array of tasks
            //wait for on to 
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
