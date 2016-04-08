using Microsoft.AspNet.Mvc;
using AfterSki.Models;
using Microsoft.SqlServer.Server;
using AfterSki.Models.RideModels;
namespace AfterSki.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            JsonData jm = new JsonData();
            jm.getSkiData();
            RidePrognosis rp = new RidePrognosis();
            rp.HeightPrognos(new System.DateTime(2016, 01, 05, 14, 20, 00));
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