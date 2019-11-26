using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lab_04_Connect_To_Raw_Sql
{
    class Program
    {
        static void Main(string[] args)
        {
            // @ means take LITERALLY WHAT'S IN THE THE FOLLOWING STRING
            // IE NO 'escaping' of characters allowed
            // example @" C:\folder\file" IS GOOD
            //   C:\\folder\\file       ESCAPING BACKSLASH
            // var connectionString = @"";

            string connectionString = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                Console.WriteLine(connection.State);

                // read from database
                using (var sqlCommand = new SqlCommand("SELECT * FROM CUSTOMERS", connection)) 
                {
                    // CREATE LOOP TO READ AND ITERATE AND PARSE DATA
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read()) 
                    {
                        string CustomerID = reader["CustomerID"].ToString();
                        string ContactName = reader["ContactName"].ToString();
                        Console.WriteLine($"{CustomerID,-15}{ContactName}");

                    }
                    Console.ReadLine();

                }
            } 
        }
    }
}
