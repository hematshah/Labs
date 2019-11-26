using System;
using System.Collections.Generic;

namespace Lab_09_Rabbit_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public class Rabbit_Collection 
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();

        /* input totalYears to run  the system Output will
         be list of rabbits every year, double number of rabbits
         Every Year, increment age also of every rabbit Test Data
         Test data 
         
         Year 0   1 rabbit age 0
         YeaR 1   2            1, 0
              2   4            2, 1, 0, 0 
              3   8            3, 2, 1, 0, 0, 0, 0, 0  */

        public static (int cumulativeRabbitAge, int rabbitCount) MultiplyRabbits(int totalYears) 
        {
            int cumulativeRabbitAge = 0;
            rabbits = new List<Rabbit>();

            var rabbit0 = new Rabbit
            {

                RabbitId = 0,
                RabbitName = "Rabbit0",
                Age = 0
            };
            rabbits.Add(rabbit0);
            for (int year = 0; year < totalYears; year++)
            {

                foreach (var rabbit in rabbits.ToArray())
                {
                    var newRabbit = new Rabbit();
                    rabbits.Add(newRabbit);
                    rabbit.Age++;
                }
                
            }

            
            rabbits.ForEach(r => cumulativeRabbitAge += r.Age);
            return (cumulativeRabbitAge, rabbits.Count);

        }

        public static (int cumulativeRabbitAge, int rabbitCount) MultiplyRabbitsAfterAgeThreeReached(int totalYears) 
        {
            int cumulativeRabbitAge = 0;
            rabbits = new List<Rabbit>();

            var rabbit0 = new Rabbit
            {

                RabbitId = 0,
                RabbitName = "Rabbit0",
                Age = 0
            };
            rabbits.Add(rabbit0);


            for (int years = 0; years < totalYears; years++)
            {
                foreach (var rabbit in rabbits.ToArray())
                {
                    if (rabbit.Age >=3)
                    {
                        var newRabbit = new Rabbit();
                        rabbits.Add(newRabbit);
                        rabbit.Age++;
                    }
                    else
                    {
                        rabbit.Age++;
                    }
                    
                }
            }
            
            rabbits.ForEach(r => cumulativeRabbitAge += r.Age);
            return (cumulativeRabbitAge, rabbits.Count);
        }

   
    
    }

    public class Rabbit
    {

        public int RabbitId { get; set; }

        public string RabbitName { get; set; }

        public int Age { get; set; }

        public Rabbit() 
        {
            this.RabbitId = Rabbit_Collection.rabbits.Count + 1;
            RabbitName = "Rabbits" + this.RabbitId;
             int Age = 0; 
        }

    }




}
