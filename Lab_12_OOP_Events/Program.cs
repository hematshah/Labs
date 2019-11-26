using System;

namespace Lab_12_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var james = new Child("James");
            james.Grow();
            james.Grow();
            james.Grow();
            james.Grow();




        }
    }

   public class Child 
    {

        // trivial Event Annual Birthday
        delegate void BirthdayDelegate();
        event BirthdayDelegate HaveABirthParty;
        public string Name { get; set; }
        public int Age { get; set; }

        public void HaveAParty() 
        {
            //'this' refers to an Instance
            this.Age++;
            Console.WriteLine("Hey celebrating another year!" + $" Age is now{this.Age}");
        }

        public Child(string Name) 
        {
            this.Name = Name;
            this.Age = 0;
            HaveABirthParty += HaveAParty;
        }

        public void Grow() 
        {
            HaveABirthParty();  // call the event
        }


    }
}
