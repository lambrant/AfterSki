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
            public string label { get; set; }
        }

        public static List<RideStatistic> rs = new List<RideStatistic>();
        public static RideStatisticDBContext rsdb = new RideStatisticDBContext();
        public static AfterSki.ViewModels.SkidataViewModel PopulateRidesPerDayArray(string rideDate)
        {
            rs = rsdb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            var A = new ViewModels.SkidataViewModel();

            A.graph1 = rs.Select(x => x.swipeTime).GroupBy(x => x.Hour).OrderBy( x => x.Key).Select(group =>
            new Javaobject{ y = group.Count(),label = group.Key.ToString() })
            .ToArray();

            A.graph2 = rs.GroupBy(x => x.swipeTime.Hour).OrderBy(x => x.Key).Select(group =>
            new Javaobject { y = group.Sum(i => i.height), label = group.Key.ToString() })
            .ToArray();

            return A;
        }
    }
}