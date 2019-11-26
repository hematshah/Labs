using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Lab_05_CRUD_RAW_SQL
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static Customer customerJustAdded;
        static void Main(string[] args)
        {

            // connection string 
            var connectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                customerJustAdded = addCustomers(connection);

              //  generateRandomCustomerID();

                //addCustomers(connection);

              //  updateCustomer(connection, customerJustAdded);

                deleteCustomers(connection, customerJustAdded);


                listCustomers(connection);

            }
        }
    

       #region list customers
    public static void listCustomers(SqlConnection sqlConnection)
    {
        // get customers
        using (var sqlCommand = new SqlCommand("SELECT * FROM Customers", sqlConnection))
        {
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                var customer = new Customer()
                {
                    CustomerID = sqlReader["CustomerID"].ToString(),
                    ContactName = sqlReader["ContactName"].ToString(),
                    CompanyName = sqlReader["CompanyName"].ToString(),
                    City = sqlReader["City"].ToString(),
                    Country = sqlReader["Country"].ToString()

                };
                //get into list
                customers.Add(customer);
            }
        }

        //print list
        //foreach (var c in customers)
        //{
        //    Console.WriteLine($"{c.CustomerID}{c.ContactName}{c.CompanyName}" + $"{c.City}{c.Country}");
        //}
        Console.WriteLine($"{"CustomerID",-15}{"ContactName",-30}{"CompanyName",-40}" + $"{"City",-15}{"Country",-15}");
        Console.WriteLine(" ");

        // Lambda For Each
        customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-15}{c.ContactName,-30}{c.CompanyName,-40}" + $"{c.City,-15}{c.Country,-15}"));
        Console.ReadLine();
    }
    #endregion

       #region add customers
    static Customer addCustomers(SqlConnection sqlConnection)
    {
        var randomCustomerID = generateRandomCustomerID();
        var newCustomer = new Customer()
        {
            CustomerID = randomCustomerID,
            CompanyName = "SParta",
            ContactName = "Mark",
            City = "London",
            Country = "UK"
        };

        //var sqlString = "INSERT INTO Customers( CustomerID, CompanyName, ContactName, City,Country)" +
        //    "VALUES('Mark2','SParta', 'Mark', 'London', 'UK')";
        //using (var sqlCommand = new SqlCommand(sqlString, sqlConnection)) 
        //{
        //    // ExecuteNonQuery ie NO
        //    int affected = sqlCommand.ExecuteNonQuery();
        //    Console.WriteLine($"{affected} new records added to database");
        //}

        //lets generate our sql command in a more proffecional say using parameters rather than list the values
        var sqlString2 = "INSERT INTO Customers( CustomerID, CompanyName, ContactName, City,Country)" +
           "VALUES(@CustomerID, @CompanyName, @ContactName, @City,@Country)";

            using (var sqlCommand2 = new SqlCommand(sqlString2, sqlConnection))
            {

                sqlCommand2.Parameters.AddWithValue("@CustomerID", newCustomer.CustomerID);
                sqlCommand2.Parameters.AddWithValue("@CompanyName", newCustomer.CompanyName);
                sqlCommand2.Parameters.AddWithValue("@ContactName", newCustomer.ContactName);
                sqlCommand2.Parameters.AddWithValue("@City", newCustomer.City);
                sqlCommand2.Parameters.AddWithValue("@Country", newCustomer.Country);

                int affected = sqlCommand2.ExecuteNonQuery();
                Console.WriteLine($"{affected} records added to database");

                if (affected == 1)
                {
                   return newCustomer;
                }

            }

        return null;

    }


    #endregion

       #region generateRandomCustomerID

    static string generateRandomCustomerID()
    {

        Random generateRandomId = new Random();
        // STRING IS ARRAY OF CHARACTERS
        char[] customerId = new char[5];
        for (int i = 0; i < customerId.Length; i++)
        {
            customerId[i] = Convert.ToChar(generateRandomId.Next(65, 90));
            //customerId[i] = (char)generateRandomId.Next('A', 'Z');
        }
        string s = new String(customerId);
        return s;



    }

    #endregion

       #region Update Customers

            static void updateCustomer(SqlConnection sqlConnection, Customer c)
            {
                c.ContactName = "New Name";
               var updateSqlString = $"UPDATE CUSTOMERS SET ContactName = '{c.ContactName}'" +
                 $"WHERE CustomerId= '{c.CustomerID}'";

                using (var sqlCommand2 = new SqlCommand(updateSqlString, sqlConnection))
                {
                  int updated = sqlCommand2.ExecuteNonQuery();
                  Console.WriteLine($"{updated} your record has been updated");
                }

            }
        #endregion

        #region delete Customers

        static void deleteCustomers(SqlConnection sqlConnection, Customer c) 
        {

            var sqlString3 = $"DELETE FROM CUSTOMERS " + $"WHERE CustomerId = '{c.CustomerID}'";
            using (var sqlCommand3 = new SqlCommand(sqlString3, sqlConnection))
            {
                int deleted = sqlCommand3.ExecuteNonQuery();
                Console.WriteLine($"{deleted} your record has been deleted");
            }
        }

       #endregion

    }




    class Customer
    {
            public string CustomerID { get; set; }
            public string ContactName { get; set; }

            public string CompanyName { get; set; }

            public string City { get; set; }

            public string Country { get; set; }

        }
}

