using AfterSki.Models.RideModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{

    public class StatsCounter //ViewModel
    {
        private RideStatisticDBContext _context;

        public StatsCounter(RideStatisticDBContext context)
        {
            _context = context;
        }

        public StatsCounter() : base()
        {
        }

        public string season { get; set; }
        public string totalMeters { get; set; }
        public string totalRides { get; set; }
        public string dayTime { get; set; }
        public string mostEffecticeHour { get; set; }
        public void TotalCount()
        {

            List<RideStatistic> countList = new List<RideStatistic>();
            List<ActiveSeason> seasonList = new List<ActiveSeason>();
            string error = "Error connecting to database";
            countList = _context.RideStatistic.ToList();
            seasonList = JsonData.activeSeasonList.ToList();

            if (seasonList == null || seasonList.GetEnumerator().MoveNext())
            {
                var seasonName = seasonList.Select(s => s.name)
                                    .FirstOrDefault();
                season = seasonName.ToString();
            }

            else
            {
                season = error;
            }

            if (countList == null || countList.GetEnumerator().MoveNext())
            {

                totalMeters = countList.Sum(x => x.height).ToString();
                totalRides = countList.Count().ToString();
                var getdate = countList
                              .OrderBy(f => f.swipeTime)
                              .Select(x => x.swipeTime)
                              .Last();
                dayTime = getdate.ToString();

                var streak = countList.Select(x => x.height)
                    .Max();
                mostEffecticeHour = streak.ToString();

            }
            else
            {
                totalMeters = error;
                totalRides = error;
                dayTime = error;
            }
        }
    }
}