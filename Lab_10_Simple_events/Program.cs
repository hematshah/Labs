using System;

namespace Lab_10_Simple_events
{
    class Program
    {
        // create delegate type
        delegate void myDelegate();
        delegate int myDelegate02(int x);

        //create event (empty at the moment)
       static  event myDelegate MyEvent;
        static event myDelegate02 MyEvent02;

        static void Main(string[] args)
        {
            //add method to event
            MyEvent += method01; 
            MyEvent += method02;
            MyEvent -= method01; // remove the event with the specified method in this case Method01

            // fire event
            MyEvent();
            Console.WriteLine("This is returning " + MyEvent02(10));
        }

        static void method01()
        {
            Console.WriteLine("runnig mothod01");
        }

        static void method02() 
        {
            Console.WriteLine("running method02");
        }

        static int method03(int x) 
        {
            return x * x;
        }
    }
}
