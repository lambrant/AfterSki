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

        public static IEnumerable<VerticalAccPerDay> VerticalSumPerDay(string velocity )
        {
            List<RideStatistic> rsVel = new List<RideStatistic>();
            RideStatisticDBContext db = new RideStatisticDBContext();
            rsVel = db.RideStatistic.Where(v => v.swipeDate.Contains(velocity))                
                .ToList();

            var verticalArray = rsVel              
                .GroupBy(g => g.swipeTime)
                .Select(group =>
                new VerticalAccPerDay
                {
                    verticalY = group.Sum(s => s.height),
                    dayX = group.Key.ToString()
                }
                )
                .ToArray();
            return verticalArray;
        }
    }
}
