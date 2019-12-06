using System;

using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Lab_23_serialize_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Nick", "NY567437D");
            var customer2 = new Customer(2, "Mick", "NY56456A");
            var customer3 = new Customer(3, "Dick", "NY78456C");
            var customers = new List<Customer>() { customer, customer2, customer3};


            // serialiser
            var JSONCustomerList = JsonConvert.SerializeObject(customers);

            // peek at the object
            Console.WriteLine(JSONCustomerList);

            // save to file

            File.WriteAllText("data.jason", JSONCustomerList);

            // read text
            var JSONstring = File.ReadAllText("data.json");

            // decerialize
            var customerFromJSON = JsonConvert.DeserializeObject<List<Customer>>(JSONstring);

            // print
            customerFromJSON.ForEach(c => Console.WriteLine($"{c.CustomerID}, {c.CustomerName}"));
        }
    }

    [Serializable]
    class Customer
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
