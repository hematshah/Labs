using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lab_18_Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            // system.io writing FILES
            File.WriteAllText("data.txt", "hello this is some data");

            var myArray = new string[] { "hello", "this", "is", "some", "Data" };
            File.WriteAllLines("arrayData.txt", myArray);

            

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("data.text", $"\nAdding line {i} At {DateTime.Now}");
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    File.AppendAllText("data.text", Environment.NewLine + $"Adding line {i} At {DateTime.Now}");
            //}

            Console.WriteLine(File.ReadAllText("data.txt"));

            var output = File.ReadAllText("Arraydata.txt").ToList();
            output.ForEach(line => Console.WriteLine(line));

            Directory.CreateDirectory("Here Is a Folder");
            File.Create("Here Is A folder\\myfile.txt");
            File.Create(@"here is a folder\myfile2.txt");

            Directory.CreateDirectory(@"C:\RootFolder");
            Console.WriteLine(Directory.Exists(@"C:\RootFolder"));

            // stream some data to a file
            // system can cope with large files: breaks them down into blocks and send them
            var numberOfLines = 50_000;
            var s = new Stopwatch();
            s.Start();
            using (var stream01 = new StreamWriter("output.dat")) 
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    stream01.WriteLine($"Logging some data at {DateTime.Now}");
                }
                
            }
            var writeTime = s.ElapsedMilliseconds;
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to write {numberOfLines} lines");

            // read data
            string nextline;
            using (var reader = new StreamReader("output.dat"))
            {
                // READER FOES NOT KNOW HOW BIG THE FILE IS
                //READ UNTIL READER READLINE IS NULL
                while ((nextline = reader.ReadLine()) != null ) 
                {
                   // Console.WriteLine(nextline);
                }
                reader.Close();
            }


            Console.WriteLine($"It took {s.ElapsedMilliseconds-writeTime} to read {numberOfLines} lines");


            // building a string
            // regular string building with + generate a new INSTANCE EVERY TIME
            // Strings are Immutable (cannot change Them)
            // t ==> th ==> thi
            s.Restart();
            var longString = "";
            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextline = reader.ReadLine()) != null) 
                {
                    longString += nextline;
                }
                reader.Close();
            }

            Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} strings together");

            s.Restart();
            longString = "";
            var stringBuilder = new StringBuilder();
            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextline = reader.ReadLine()) != null)
                {
                    stringBuilder.Append(nextline);
                }
                reader.Close();
            }
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} strings together using string builder");

        }
    }
}
