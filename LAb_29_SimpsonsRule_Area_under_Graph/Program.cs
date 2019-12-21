using System;

namespace LAb_29_SimpsonsRule_Area_under_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class SimsonsRule 
    {

        /* This is for homework  for tonight 09/12/09
           Graph of Y = X*X
         *Points 0,1,2,3,4,5,6 = N (Value of x)
         * Value of Y : 0 = zero item ,1,4,9,16,25,36 last item
         * Goal : approximate Are UNDER Graph
         * simsons rule : Area = ((MAX X - MIN X) / 3N)  *  
         * 
         *   [Y(zeroth item) + Y(last item)  
         *   + 4(odd-indexed items ie N =1,2,3 )
         *   + 2(even-indexed items ie N = 2,4,6)]
         *   
         *   Because its a double you cant test for exact value
         *   But can test <> upper/lower bound which you can to 2 decimal places
         * 

         */
        /* Homework! Graph of Y=X*X
            (can hard code this in) 
            Points 0,1,2,3,4,5,6=N 
            (value of X)
            Value of Y : 0,1,4,9,16,25,36 Goal
            : approximate AREA UNDER GRAPH Simpsons Rule

            : Area = ( (MAX X - MIN X)/ 3 N )
            * [ Y(zeroth item) + Y(last item) 
            + 4(odd-indexed items ie N=1,3,5)
            + 2(even-indexed items ie N=2,4) ] 
            https://www.intmath.com/integration/6-simpsons-rule.php 
            Because it's a double you can't test
            for exact value But can test 
            <> upper/lower bound which you 
            can fix to 2 decimal places * */

        public double GetAreaUnderGraphUsingSimpsonsRule(int n, int min, int max)
        {
            // n=6, min=0, max=6, difference =(max-min/n)

            double difference = (max - min) / n;

            double Area1 = ((max - min) / n);

            double Area2 = (min * min  * min) + (max * max * max);

            double Area3 = 2 * (difference * n);

            double Area4 = 4 * (difference * n);

            double answer = (Area1 * Area2) + (Area3 + Area4);

            return answer;


        }
    } 
}
