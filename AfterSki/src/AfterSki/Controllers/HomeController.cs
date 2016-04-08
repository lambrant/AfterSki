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
            return View();
        }

        public IActionResult Skidata()
        {
           
            
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