using System;
using Lab_22_Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab_24_Serialization_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Billy", "NR457567A");
            var customer2 = new Customer(2, "Katy", "SJ346578B");
            var customer3 = new List<Customer>() { customer, customer2 };

            // serialise customer to XML format
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None)) 
            {
                // write file
                formatter.Serialize(stream, customer3);
            }

            // read file

            //  var Binarystring = File.ReadAllText("data.bin");
            var customersFromBinary = new List<Customer>();
            using (var reading = File.OpenRead("data.bin"))
            {
                // deserialise binary => Customer 
                 customersFromBinary = formatter.Deserialize(reading) as List<Customer>;
            }

            // print

            customersFromBinary.ForEach(c => Console.WriteLine($"{c.CustomerID} ,{c.CustomerName}"));
           


        }
    }

    [Serializable]
   public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        [NonSerialized]
        private String NINO; //opt out

        public Customer(int ID, String Name, string Nino)
        {
            this.CustomerID = ID;
            this.CustomerName = Name;
            this.NINO = Nino;
        }
    }


}
