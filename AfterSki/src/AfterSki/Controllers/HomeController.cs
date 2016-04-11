using Microsoft.AspNet.Mvc;
using AfterSki.Models;
using Microsoft.SqlServer.Server;
using AfterSki.Models.RideModels;
using System.Linq;

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

            var graphArray = WriteData.PopulateRidesPerDayArray("Sön, 27 Mar");

            return View(graphArray);
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