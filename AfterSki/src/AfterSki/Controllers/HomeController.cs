using Microsoft.AspNet.Mvc;
using AfterSki.Models;
using Microsoft.SqlServer.Server;
using AfterSki.Models.RideModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;
using System;

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

        public IActionResult Skidata(string dropdownDates)
        {
            ///<summary>
            ///Instansiates DContext to access the database
            /// </summary>
            RideStatisticDBContext db = new RideStatisticDBContext();

            ///<summary>
            ///Gets all the days in the database
            /// </summary>
            var dateQRY = from d in db.RideStatistic
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
            var rides = from d in db.RideStatistic
                        select d;
            ViewData["dropdownDates"] = new SelectList(dateList);
            if (!string.IsNullOrEmpty(dropdownDates))
            {

                rides = rides.Where(r => r.swipeDate.Contains(dropdownDates));

            }
            //if (!string.IsNullOrEmpty(dropdownDates))
            //{
            //    rides = rides.Where(r => r.swipeDate == dropdownDates);
            //}

            var graphDayArray = WriteData.PopulateRidesPerDayArray(dropdownDates);
            ///<sumamry>
            ///Calls the javascript that creates the chart 
            ///from date selected in the dropdown
            ///and puts the data corresponding to chosen date from dropdown 
            /// 
            /// </sumamry>
            var graphDateArray = WriteData.PopulateRidesPerDateArray(dropdownDates);

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