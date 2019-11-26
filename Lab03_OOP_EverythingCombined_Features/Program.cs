using System;

namespace Lab03_OOP_EverythingCombined_Features
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Members nameMembers = new Members();
            nameMembers.ZooText();

        }
    }


    public class Zoo 
    {
        private int numberOfStaffMembers;
        private int numberOfAnimals;
        private int howManyTypesOfAnimals;

        public Zoo() 
        {
            
        }

        public virtual void ZooText() 
        {
            Console.WriteLine("This is the owner speaking");
        }

        public Zoo( int numberOfStaffAvailable, int numberOfAnimalsNotSleeping) 
        {
            numberOfStaffAvailable = numberOfStaffMembers;
            numberOfAnimalsNotSleeping = numberOfAnimals;
        }

        int total;
        public int NumberOfAnimalsAndType
        {
            get
            {
                return total;
            }
            set
            {

                total = numberOfAnimals + howManyTypesOfAnimals;
            }
        }


    }

    public class Animals : Zoo
    {
        public override void ZooText()
        {
            Console.WriteLine("Roar guess who i am??");
        }

    }

    public class Members : Animals
    {
        public override void ZooText()
        {
            Console.WriteLine("I am a staff member of the Zoo Class");
        }
    }

   abstract public class AnimalType : Animals 
    {
        abstract public void CountingAnimals();
        abstract public void AnimalsNotSleeping();
    }



}
