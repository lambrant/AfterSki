using Microsoft.AspNet.Mvc;
using AfterSki.Models;
using AfterSki.Models.RideModels;
using System.Linq;
using System.Collections.Generic;


namespace AfterSki.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            JsonData jm = new JsonData();
            jm.getSkiData();

            return View();
        }

        public IActionResult Skidata()
        {

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