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
        ///<summary>
        ///Instansiates DContext to access the database
        /// </summary>
        RideStatisticDBContext db = new RideStatisticDBContext();
        public IActionResult Index()
        {

            JsonData jm = new JsonData();
            jm.getSkiData();

            return View();

        }

        public IActionResult Skidata(string dropdownDates)
        {
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


        public IActionResult VerticalSum(string sumDay)
        {
            var dateQRY = from w in db.RideStatistic
                           orderby w.swipeDate
                           select w.swipeDate;

            /// populates the dropdown
            var HeightList = new List<string>();
            HeightList.AddRange(dateQRY.Distinct());

            var height = from c in db.RideStatistic
                         select c;
            ViewData["sumDay"] = new SelectList(HeightList);
            if (!String.IsNullOrEmpty(sumDay))
            {
                height = height.Where(s => s.swipeDate.Contains(sumDay)); // search form
            }


            var graphSumVerticalArray = VerticalAccPerDay.VerticalSumPerDay(sumDay);

            return View(graphSumVerticalArray);
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}