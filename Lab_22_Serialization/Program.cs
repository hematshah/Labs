using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections.Generic;

namespace Lab_22_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Billy", "NR457567A");
            var customer2 = new Customer(2, "Katy", "SJ346578B");
            var customer3 = new List<Customer>() { customer, customer2 };

            // serialise customer to XML format
            var formatter = new SoapFormatter();

            // stream customer to file WRITE
            using (var stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write, FileShare.None)) 
            {
                // serialise data to XML  as a stream of data to the file stream 
                formatter.Serialize(stream, customer3);

            }
            //print out file
            Console.WriteLine(File.ReadAllText("data.xml"));

            // reverse

            //stream

            var customerFromXMLFile = new List<Customer>();
            //stream READ
            using (var reader = File.OpenRead("data.xml")) 
            {
                // deserialise XML => Customer 
                customerFromXMLFile = formatter.Deserialize(reader) as List<Customer>;
            }


            // and print
            customerFromXMLFile.ForEach(c => Console.WriteLine($"{c.CustomerID} ,{c.CustomerName}"));

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
