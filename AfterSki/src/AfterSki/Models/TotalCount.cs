using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{

    public class GetCount //ViewModel
    {
        private RideStatisticDBContext _context;

        public GetCount(RideStatisticDBContext context)
        {
            _context = context;
        }
        public int totalMeters { get; set; }
        public int totalRides { get; set; }
        public string dayTime { get; set; }
        public int season { get; set; }

        public void InvokeGetCount()
        {
            totalMeters = _context.RideStatistic.Sum(x => x.height);
            totalRides = _context.RideStatistic.Count();
            var lastDate = _context.RideStatistic.OrderBy(f => f.swipeTime).Select(x => x.swipeTime).Last();
            dayTime = lastDate.ToString();
            var nowSeason = JsonData.activeSeasonList.ToList().OrderBy(o => o.seasonId).Select(s => s.seasonId).Last();
            season = nowSeason;
        }
    }
}