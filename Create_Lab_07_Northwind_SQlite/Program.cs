using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;

namespace Create_Lab_07_Northwind_SQlite
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Customer 
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }

    class NorthwindDBContext : DbContext 
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"Data Source = C:\Engineering45\SQL\Northwind.db ";
            builder.UseSqlite(connectionString);
        }
    }
}
