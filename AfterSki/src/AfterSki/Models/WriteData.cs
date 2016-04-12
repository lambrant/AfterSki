using AfterSki.Models.RideModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class WriteData
    {
        public class Javaobject
        {
            public int y { get; set; }
        }

        public static IEnumerable<Javaobject> PopulateRidesPerDayArray(string rideDate)
        {
            List<RideStatistic> rs = new List<RideStatistic>();
            RideStatisticDBContext rsdb = new RideStatisticDBContext();
            rs = rsdb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();
            var swipeDateArray = rs.Select(x => x.swipeTime).GroupBy(x => x.Hour).Select(group =>
            new Javaobject{ y = group.Count() })
            .ToArray();
        

            return swipeDateArray;

        }
        public static IEnumerable<Javaobject> PopulateRidesPerDateArray(string groupDay)
        {
            List<RideStatistic> rsX = new List<RideStatistic>();
            RideStatisticDBContext rsdb = new RideStatisticDBContext();
            rsX = rsdb.RideStatistic.Where(u => u.swipeDate.Contains(groupDay)).ToList();
            var swipeDayArray = rsX.Select(x => x.swipeTime).GroupBy(x => x.TimeOfDay).Select(group =>
            new Javaobject { y = group.Count() })
            .ToArray();


            return swipeDayArray;

        }


    }
}
