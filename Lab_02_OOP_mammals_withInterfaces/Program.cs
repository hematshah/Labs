using System;

namespace Lab_02_OOP_mammals_withInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Tiger tiger = new Tiger();
            tiger.Roar();
            tiger.SeeMyPrey();
            tiger.SmellMyPrey();
            

            Lion lion = new Lion();
            lion.Roar();
            lion.SeeMyPrey();
            lion.SmellMyPrey();
            

        }
    }

    public class Mammal
    {
        bool isWarmLooded = true;
        private double Weight;
        private double Height;
        private double Length;

        public double Weight1 { get => Weight; set => Weight = value; }
        public double Height1 { get => Height; set => Height = value; }
        public double Length1 { get => Length; set => Length = value; }

        public int MyProperty { get; set; }

        
    }

    public class Cat : Mammal, IUseSmell
    {
        
        public virtual void Roar()
        {

            Console.WriteLine("The mammals are roaring");
        }

        public void SeeMyPrey()
        {
            Console.WriteLine("I use my vision to se from afar");
        }

        public void SmellMyPrey()
        {
            Console.WriteLine("I use my sense of smell to sniff my prey");
        }
    }

    public class Tiger : Cat 
    {
        public override void Roar() 
        {
            Console.WriteLine("This is Lion and i am roaring");
        }

     
    }

    public class Lion : Cat 
    {
        public override void Roar()
        {
            Console.WriteLine("This is tiger and i am roaring roaring");
        }

       
    }

    interface IUseVision
     {
        void SeeMyPrey();
     }

    interface IUseSmell : IUseVision 
    {
        void SmellMyPrey();
    }
}
