using Microsoft.AspNet.Mvc;
using AfterSki.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using AfterSki.ViewComponents;
using System.Threading.Tasks;

namespace AfterSki.Controllers
{
    public class HomeController : Controller
    {
        private RideStatisticDBContext _context;

        public HomeController(RideStatisticDBContext context)
        {
            _context = context;

        }
        ///<summary>
        ///Instansiates DContext to access the database
        /// </summary>

        public IActionResult Index()
        {
            JsonData jm = new JsonData();
            jm.getSkiData();
            DataImport di = new DataImport(_context);
            di.ListToDB();
            return View();
        }

        public IActionResult Skidata(string dropdownDates, string season)
        {
            ///<summary>
            ///Gets all the days in the database
            /// </summary>
            var dateQRY = from d in _context.RideStatistic
                          orderby d.swipeTime.Date
                          select d.swipeDate;

            ///<summary>
            ///Creates a list of all the dates
            /// </summary>
            var dateList = new List<string>();
            dateList.AddRange(dateQRY.Distinct());

            ///<summary>
            ///Puts all dates to a dropdown/Selectlist
            /// </summary>
            var rides = from d in _context.RideStatistic
                        select d;
            ViewData["dropdownDates"] = new SelectList(dateList);
            if (!string.IsNullOrEmpty(dropdownDates))
            {
                rides = rides.Where(r => r.swipeDate.Contains(dropdownDates));
            }
            var graphDayArray = WriteData.PopulateRidesPerDayArray(dropdownDates);

            return View(graphDayArray);
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