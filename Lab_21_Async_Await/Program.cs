using System;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Lab_21_Async_Await
{
    class Program
    {
        static Uri uri = new Uri("https://google.com");
        static Stopwatch s = new Stopwatch();

        static void Main(string[] args)
        {
            // main metgod here
            // Setup : Create our data file
            // CSV = Comma Separated values

            File.WriteAllText("data.csv", "id,name,age");
            File.AppendAllText("data.csv", "\n1,BOb,21");
            File.AppendAllText("data.csv", "\n2,Paul,23");
            File.AppendAllText("data.csv", "\n3,Nick,27");

            // SyncMethod : WAIT FOR IT
            //  ReadDataSync();
            //AsyncMethod : DON'T WAIT FOR IT
            // ReadDataAsync();
            //GetWebpages
            // Sync
            s.Start();
            GetWebPageSync();
            s.Restart();
            //Async
            
            GetWebPageAsync();

            Console.WriteLine($"code is finished at{s.ElapsedMilliseconds}");
            
            Console.ReadLine();
        }

        static void ReadDataSync() 
        {
            var s = new Stopwatch();

            s.Start();
            var output = File.ReadAllText("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine(output);
            Console.WriteLine($"time it took {s.ElapsedMilliseconds} for Sync to output data");
            s.Stop();
        }

        
        async static void ReadDataAsync() 
        {
            var v = new Stopwatch();
            v.Start();
            var output = await File.ReadAllTextAsync("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nAsync\n");
            Console.WriteLine(output);
            Console.WriteLine($"Time it took {v.ElapsedMilliseconds} for Async to output data"  );
            v.Stop();

        }

        static void GetWebPageSync() 
        {
            // get webpage
            var webclient = new WebClient { Proxy = null };
            webclient.DownloadFile(uri, @"C:\webpage\page02.html");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "page02.html");
            Console.WriteLine($" Sync webpage time it took {s.ElapsedMilliseconds}  ");

        }
       async  static void GetWebPageAsync() 
        {

            Console.WriteLine("the Async has started");
            var webclient =  new WebClient();
            webclient.DownloadFile(uri, "page02.html");
            var webpage = await webclient.DownloadStringTaskAsync(uri);
            //start chrome run locally
             Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "page02.html");
            Console.WriteLine($"Async webpage time it took: {s.ElapsedMilliseconds}");
           // Console.WriteLine(webpage);
        }

    }


}
