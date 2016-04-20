using Microsoft.AspNet.Mvc;
using AfterSki.Models;
using Microsoft.SqlServer.Server;
using AfterSki.Models.RideModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;

namespace AfterSki.Controllers
{
    public class HomeController : Controller
    {
        private RideStatisticDBContext _context;

        public HomeController(RideStatisticDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            JsonData jm = new JsonData();
            jm.getSkiData();

            return View();

        }

        public IActionResult Skidata(string dropdownDates)
        {
            var dateQRY = from d in _context.RideStatistic orderby d.swipeDate select d.swipeDate;

            var dateList = new List<string>();
            dateList.AddRange(dateQRY.Distinct());

            var rides = from d in _context.RideStatistic select d;
            ViewData["dropdownDates"] = new SelectList(dateList);
            if (!string.IsNullOrEmpty(dropdownDates))
            {
                rides = rides.Where(r => r.swipeDate.Contains(dropdownDates));
            }
            var graphArray = WriteData.PopulateRidesPerDayArray(dropdownDates);

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
        public IActionResult VerticalDrop()
        {
            return View();
        }
    }
}