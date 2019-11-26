using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab_06_Rabbits_Create_100
{
    class Program
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        static void Main(string[] args)
        {
            var rabbit = new Rabbit("Rabbit2", 6);
            //AddRabbits(rabbit);
            //ListRabbits();
            updateRabbits();
            ListRabbits();

        }

        #region list rabbits
        static void ListRabbits()
        {
       
            using (var db = new RabbitContext())
            {
                rabbits = db.Rabbits.ToList();
            }

            rabbits.ForEach(r => Console.WriteLine($"{r.RabbitID,-10}{r.RabbitName,-20}{r.RabbitAge}"));


        }
        #endregion


        #region addRabbit

        //add to database
        static void AddRabbits(Rabbit r)
        {
            using (var db = new RabbitContext())
            {
                db.Rabbits.Add(r);
                db.SaveChanges();
            }


        }
        #endregion

        #region  Update rabbits

        static void updateRabbits() 
        {
            using (var db = new RabbitContext()) 
            {
                var rabbitUpdate = db.Rabbits.Find(1);
                rabbitUpdate.RabbitName = "this is new Rabbit";
                db.SaveChanges();
            }
        }
        #endregion
    }


    #region Rabbit
    class Rabbit 
    {
        public Rabbit() 
        {
        }
        public Rabbit(string rabbitName, int Age)
        {
            this.RabbitName = rabbitName;
            this.RabbitAge = Age;
        }
        public int RabbitID { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }

        
    }

    class RabbitContext : DbContext 
    {
        public DbSet<Rabbit> Rabbits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RabbitDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            builder.UseSqlServer(connectionString);
        }

    }
    #endregion
}
