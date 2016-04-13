using AfterSki.Models.RideModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class FallingData
    {
        public class FallData
        {
            public int y { get; set; }
            public string label { get; set; }

        }
        public static IEnumerable<FallData> FallingHeightPerDay(string rideDate)
        {
            List<RideStatistic> fd = new List<RideStatistic>();
            RideStatisticDBContext rsdb = new RideStatisticDBContext();
            fd = rsdb.RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            var swipeDateArray = fd.Select(x => x.swipeTime).GroupBy(x => x.Hour).OrderBy(x => x.Key).Select(group =>
            new FallData { y = group.Count(), label = group.Key.ToString() })
            .ToArray();


            return swipeDateArray;

        }
    }
}
