using AfterSki.Models.RideModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class VerticalAccPerDay
    {


        public int verticalY { get; set; }
        public string dayX { get; set; }

        public static IEnumerable<VerticalAccPerDay> VerticalSumPerDay(string vert)
        {
            List<RideStatistic> rsVel = new List<RideStatistic>();
            RideStatisticDBContext db = new RideStatisticDBContext();
            rsVel = db.RideStatistic.Where(v => v.swipeDate.Contains(vert))         
                .ToList();

            var verticalArray = rsVel
                .Select(x => x.swipeTime)
                .OrderBy(o => o.TimeOfDay)
                .GroupBy(g => g.Hour)
                .Select(group =>
                new VerticalAccPerDay
                {
                    verticalY = group.Count(),
                    //verticalY = group.Sum(s => s.height),
                    dayX = group.Key.ToString()
                }
                )
                .ToArray();
            return verticalArray;
        }
    }
}
