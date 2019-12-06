using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Lab_17_Northwind_Test
{
   
  
     
    class Program
    {

        static void Main(string[] args)
        {
            AllCustomerTest test = new AllCustomerTest();
            Console.WriteLine(test);

        }
    }

    public class AllCustomerTest 
    {
         List<Customers> customertest = new List<Customers>();
        Customer cm = new Customer();
        public static int CustomerCount(string city) 
        {
            using (var db = new NorthwindEntities()) 
            {


                if (city == null || city == " ")
                {
                    return db.Customers.Count();
                }
                else 
                {
                    var countCustomerWhereCityIsLondon = from cm in db.Customers
                                                         where cm.City == "London"
                                                         select cm;

                    return countCustomerWhereCityIsLondon.Count();
                }
                  
            }

               
        }
    }

    public class Customers
    {

        public int customerId{ get; set; }
        public string city{ get; set; }

    }
}
