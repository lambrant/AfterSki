using Microsoft.AspNet.Mvc;
using AfterSki.Models;
using Microsoft.SqlServer.Server;
using AfterSki.Models.RideModels;
using System.Linq;
using System;

namespace AfterSki.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            JsonData jm = new JsonData();
            jm.getSkiData();
            RidePrognosis rp = new RidePrognosis();
            rp.HeightPrognos();
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