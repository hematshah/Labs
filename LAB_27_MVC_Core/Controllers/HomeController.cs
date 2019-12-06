using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LAB_27_MVC_Core.Models;

namespace LAB_27_MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        public static List <string> MyList = new List<string>();
        public List<int> MyList2 = new List<int>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MyAction() 
        {
            ViewBag.MyItem = "This is some data";
            ViewData["AnotherItem"] = "\nThis is also some data";
            MyList2 = new List<int>() {1,2,3};
            ViewBag.Mylist2 = MyList2;
            return View(MyList2);
            
        }

        public IActionResult ListView() 
        {
            MyList = new List<string>() { "Testting", "Hi" , "My name is " };
            ViewBag.Mylist = MyList;
            return View(MyList);
        }
    }
}
