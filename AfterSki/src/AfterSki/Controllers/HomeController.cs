﻿using Microsoft.AspNet.Mvc;
using AfterSki.Models;

namespace AfterSki.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            JsonData jm = new JsonData();
            jm.getSkiData();
            jm.ListToDB();
            //CreateCSV csv = new CreateCSV();
            //csv.ListToCsv();
            //ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}