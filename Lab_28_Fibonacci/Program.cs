using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_28_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class FibonacciTesting 
    {
        // create a test with 3 test values to ensure this works

        public int ReturnFibbonacciNthItemInSequence(int number) 
        {
            //int n1 = 0;
            //int n2 = 1;
           

            //for (int i = 2; i < number; ++i)
            //{
            //    number = n1 + n2;
            //    n1 = n2;
            //    n2 = number;

            //}


            if (number == 0 || number == 1)
            {
                return number;
            }
            else 
            {
                // return value of nth term
                return ReturnFibbonacciNthItemInSequence(number -1) + ReturnFibbonacciNthItemInSequence(number -2);
                
            }


        }
    }
}
