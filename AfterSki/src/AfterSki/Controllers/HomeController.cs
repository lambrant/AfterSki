using Microsoft.AspNet.Mvc;
using AfterSki.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;
using System;

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

        public IActionResult Skidata(string dropdownDates)
        {
            ///<summary>
            ///Gets all the days in the database
            /// </summary>
            var dateQRY = from d in _context.RideStatistic
                       orderby d.swipeDate
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
            ///<sumamry>
            ///Calls the javascript that creates the chart 
            ///from date selected in the dropdown
            ///and puts the data corresponding to chosen date from dropdown 
            /// 
            /// </sumamry>

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