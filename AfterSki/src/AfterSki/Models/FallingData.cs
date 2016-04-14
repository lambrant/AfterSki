using AfterSki.Models.RideModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterSki.Models
{
    public class FallingData
    {
        private RideStatisticDBContext _context;

        public FallingData(RideStatisticDBContext context)
        {
            _context = context;
        }
        public class FallData
        {
            public int y { get; set; }
            public string label { get; set; }

        }
        public static IEnumerable<FallData> FallingHeightPerDay(string rideDate)
        {
            List<RideStatistic> fd = new List<RideStatistic>();

            //_context.Database
            //fd = RideStatisticDBContext..RideStatistic.Where(u => u.swipeDate.Contains(rideDate)).ToList();

            var swipeDateArray = fd.Select(x => x.swipeTime).GroupBy(x => x.Hour).OrderBy(x => x.Key).Select(group =>
            new FallData { y = group.Count(), label = group.Key.ToString() })
            .ToArray();


            return swipeDateArray;

        }
    }
}
