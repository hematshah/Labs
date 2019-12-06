using System;
using System.Net;
using System.Diagnostics;

namespace Lab_19_HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("https://bbc.co.uk/weather");

            Console.WriteLine($"the host is {uri.Host}, port is {uri.Port}, path is {uri.AbsolutePath}");

            // get page
            var webclient = new WebClient { Proxy = null };
            webclient.DownloadFile(uri, "localpage.html");

            // run the webpage locally

            //Process.Start("notepad.exe");
            // Process.Start("WinWord.exe");
            System.Threading.Thread.Sleep(10000);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localpage.html");

        }
    }
}
